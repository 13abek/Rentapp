using Online13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online13.ViewModels
{
    public class VmBlogSingle
    {
        public Blog blog { get; set; }

        public List<BlogCategory> blogCategories { get; set; }

    }
}