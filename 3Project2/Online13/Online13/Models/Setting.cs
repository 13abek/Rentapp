using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Setting
    {
        public int Id { get; set; }
         [MaxLength(150)]
        public string Logo { get; set; }
        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }
        [MaxLength(35)]
        [Required]
        public string AddressStreet { get; set; }
        [MaxLength(35)]
        [Required]
        public string AddressCity { get; set; }
        [MaxLength(35)]
        [Required]
        public string FirstPhone { get; set; }
        [MaxLength(30)]
        [Required]
        public string SecondPhone { get; set; }
        [MaxLength(35)]
        [Required]
        public string FirstEmail { get; set; }
        [MaxLength(35)]
        [Required]
        public string SecondEmail { get; set; }
        [MaxLength(500)]
        [Required]
        public string FooterContent { get; set; }
        [MaxLength(20)]
        [Required]
        public string CopyRight { get; set; }
        [MaxLength(150)]
        public string BgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }
        public List<SocialCompany> socialCompanies { get; set; }
    

    }
}