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
            var data = db.Events.Include(e => e.Venue).Include(e => e.WhyIsThereAGenre).ToList();
            return View(data);
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