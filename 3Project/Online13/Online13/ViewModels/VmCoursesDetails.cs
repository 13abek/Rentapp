using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online13.Models;
using Online13.DAL;


namespace Online13.ViewModels
{
    public class VmCoursesDetails
    {
        public Course Course { get; set; }
        public List<CourseCategory> courseCategories { get; set; }

        public Poster poster { get; set; }
    }
}