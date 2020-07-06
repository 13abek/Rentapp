using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Position
    {
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}