using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(30)]
        [Required]
        public string UpperTitle { get; set; }
        [MaxLength(30)]
        [Required]
        public string FirstTitle { get; set; }
        [MaxLength(30)]
        [Required]
        public string SecondTitle { get; set; }
    }
}