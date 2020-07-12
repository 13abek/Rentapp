using Online13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online13.ViewModels
{
    public class VmAbout
    {
        public About  About { get; set; }
        public List<Teacher> Teachers { get; set; }
        public pageAdmin Admin { get; set; }
        public List<AboutSlider> aboutSliders { get; set; }
        public List<Notice> Notices { get; set; }
        public Setting setting { get; set; }
    }
}