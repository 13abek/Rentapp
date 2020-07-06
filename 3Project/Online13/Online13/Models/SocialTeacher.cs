using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class SocialTeacher
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        [Required]
        public string Icon { get; set; }
        [MaxLength(150)]
        public string Link { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}