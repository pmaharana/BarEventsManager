using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarEventsManager.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarEventsManager.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime? EventDate { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? EndTime { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre WhyIsThereAGenre { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [NotMapped]
        public Guid TrackerId { get; set; } = Guid.NewGuid();

        public ICollection<Order> Orders { get; set; }
    }
}