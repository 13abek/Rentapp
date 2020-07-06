using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Notice
    {
        public int Id { get; set; }
        [MaxLength(300)]
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}