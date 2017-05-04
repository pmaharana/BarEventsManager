using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarEventsManager.Models;

namespace BarEventsManager.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Events> Events { get; set; }
        public Order ShoppingCart { get; set; }
    }
}