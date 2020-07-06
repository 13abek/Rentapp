using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Online13.Models
{
    public class SocialCompany
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(20)]
        [Required]
        public string Icon { get; set; }
        [MaxLength(150)]
        public string Link { get; set; }
        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}