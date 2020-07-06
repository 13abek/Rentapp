using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<EventRelSpeakers> eventRelSpeakers { get; set; }

    }
}