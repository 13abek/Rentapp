using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online13.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        [MaxLength]
        [Required]
        public string Name { get; set; }
        public List<Event> Events { get; set; }
    }
}