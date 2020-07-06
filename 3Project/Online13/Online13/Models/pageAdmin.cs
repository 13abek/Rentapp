using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Online13.Models
{
    public class pageAdmin
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(30)]
        [Required]
        public string AdminName { get; set; }
        [MaxLength(250)]
        [Required]
        public string Password { get; set; }
    }
}