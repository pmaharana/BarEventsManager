using BarEventsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BarEventsManager.CacheServices;
using BarEventsManager.ViewModels;

namespace BarEventsManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private string eventCacheKey = CacheKeys.Events();

        public ActionResult Index()
        {
            var eventsFromCache = HttpRuntime.Cache[eventCacheKey] as IEnumerable<Events>;
            if (eventsFromCache == null)
            {
            var data = db.Events
                    .Include(e => e.Venue)
                    .Include(e => e.WhyIsThereAGenre).ToList();
                //add the list to cache
                HttpRuntime.Cache.Add(
                    eventCacheKey,
                    data,
                    null,
                    DateTime.Now.AddDays(3),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High,
                    null);
                eventsFromCache = HttpRuntime.Cache[eventCacheKey] as IEnumerable<Events>;
            }

            var vm = new HomePageViewModel
            {
                Events = eventsFromCache,
                ShoppingCart = Session["cart"] as Order ?? new Order()
            };

            return View(vm);
        }

       [HttpPost]
       public ActionResult Search(string needle)
        {
            var results = db.Events.Include(e => e.Venue).Include(e => e.WhyIsThereAGenre)
                .Where(w => w.Title.Contains(needle) || w.Description.Contains(needle))
                .ToList();
            return PartialView("_ListOfEvents", results);
        }

        [HttpPut]
        public ActionResult ShoppingCart(int id)
        {
            var cart = Session["cart"] as Order;
            if (cart == null)
            {
                cart = new Order()
                {
                    Fulfilled = false,
                    TimeCreated = DateTime.Now

                };
            }
            var ticketToAdd = db.Events.Include(e => e.Venue)
                .Include(e => e.WhyIsThereAGenre)
                .FirstOrDefault(f => f.Id == id);
            cart.Event.Add(ticketToAdd);
            Session["cart"] = cart;
            return PartialView("_shoppingCart", cart);
        }
    }
}