using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarEventsManager.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;

        public bool Fulfilled { get; set; } = false;

        public string CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Events> Event { get; set; } = new HashSet<Events>();

        [DisplayFormat(DataFormatString = "{0:C}")]
        [NotMapped]
        public double TotalPrice
        {
            get
            {
                return Event.Sum(s => s.Price);
            }
        }



    }
}