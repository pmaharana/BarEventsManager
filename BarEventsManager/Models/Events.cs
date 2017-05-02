using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarEventsManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarEventsManager.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre WhyIsThereAGenre { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

    }
}