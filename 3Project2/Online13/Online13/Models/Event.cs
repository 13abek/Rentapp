using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Event
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(30)]
        [Required]
        public string StarsTime { get; set; }
        [MaxLength(30)]
        [Required]
        public string EndTime { get; set; }
        public string Venue { get; set; }
        [Column(TypeName ="nText")]
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public List<EventRelSpeakers> EventRelSpeakers { get; set; }

    }
}