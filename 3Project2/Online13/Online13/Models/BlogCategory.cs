 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}