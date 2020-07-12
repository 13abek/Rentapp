using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(60),Required]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(20), Required]
        public string UserName { get; set; }
        [MaxLength(250)]
        [Required]
        public string Password { get; set; }
        [MaxLength(30),Required]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}