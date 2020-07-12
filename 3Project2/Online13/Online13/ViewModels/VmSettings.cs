using Online13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online13.ViewModels
{
    public class VmSettings
    {
        public Setting setting { get; set; }
        public List<SocialCompany> SocialCompanies { get; set; }
    }
}