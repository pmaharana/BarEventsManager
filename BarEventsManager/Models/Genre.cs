using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarEventsManager.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Events> Events { get; set; } = new HashSet<Events>();

    }
}