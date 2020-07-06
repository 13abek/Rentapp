using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Online13.Models
{
    public class About
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Column(TypeName ="ntext")]
        [Required]
        public string Content { get; set; }
        [MaxLength(30)]
        public string VideoTitle { get; set; }
        [MaxLength(150)]
        public string VideoLink { get; set; }
        [MaxLength(150)]
        public string VideBgImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase VideBGImageFile { get; set; }
        [MaxLength(30)]
        public string NoticeTitle { get; set; }

    }
}