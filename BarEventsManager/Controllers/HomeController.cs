using BarEventsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BarEventsManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var eventsFromCache = HttpRuntime.Cache["eventlist"];
            if (eventsFromCache == null)
            {
            var data = db.Events.Include(e => e.Venue).Include(e => e.WhyIsThereAGenre).ToList();
                //add the list to cache
                HttpRuntime.Cache.Add(
                    "eventList",
                    data,
                    null,
                    DateTime.Now.AddDays(3),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High,
                    null);
                eventsFromCache = HttpRuntime.Cache["eventList"];
            }

            return View(eventsFromCache);
        }

        [HttpPost]
       public ActionResult Search(string needle)
        {
            var results = db.Events.Include(e => e.Venue).Include(e => e.WhyIsThereAGenre)
                .Where(w => w.Title.Contains(needle) || w.Description.Contains(needle))
                .ToList();
            return PartialView("_ListOfEvents", results);
        }
    }
}