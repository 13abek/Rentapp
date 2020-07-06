using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}