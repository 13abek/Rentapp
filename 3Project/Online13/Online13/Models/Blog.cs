 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(50)]
        public string ByAuthor { get; set; }
        public DateTime AddedDate { get; set; }
        [Column(TypeName ="nText")]
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}