using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarEventsManager.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public DateTime DatePurchased { get; set; } = DateTime.Now;

        public int EventsId { get; set; }
        [ForeignKey("EventsId")]
        public Events Event { get; set; }

        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser User { get; set; }

        
    }
}