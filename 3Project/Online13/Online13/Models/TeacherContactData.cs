using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class TeacherContactData
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string UpperTitle { get; set; }
        [MaxLength(20)]
        public string FirstTitle { get; set; }
        [MaxLength(20)]
        public string SecondTitle { get; set; }
        [MaxLength(20)]
        public string ThirdTitle { get; set; }
    }
}