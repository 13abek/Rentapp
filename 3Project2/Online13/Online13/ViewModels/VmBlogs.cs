using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online13.DAL;
using Online13.Models;


namespace Online13.ViewModels
{
    public class VmBlogs
    {
        public List<Blog> Blogs { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }

    }
}