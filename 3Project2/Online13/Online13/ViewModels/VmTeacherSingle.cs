using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online13.Models;
using Online13.DAL;

namespace Online13.ViewModels
{
    public class VmTeacherSingle
    {
        public Teacher Teacher { get; set; }

        public TeacherContactData  TeacherContactData { get; set; }
    }
}