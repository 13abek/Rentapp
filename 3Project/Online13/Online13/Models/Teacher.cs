using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Column(TypeName ="nText")]
        public string Content { get; set; }
        [Required]
        public int language { get; set; }
        [Required]
        public int TeamLeader { get; set; }
        [Required]
        public int Development { get; set; }
        [Required]
        public int Design { get; set; }
        [Required]
        public int Innoation { get; set; }
        [Required]
        public int Communication { get; set; }
        [MaxLength(30)]
        [Required]
        public string mail { get; set; }
        [MaxLength(30)]
        [Required]
        public string Phone { get; set; }
        [MaxLength(30)]
        [Required]
        public string skpe { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
      
        public List<SocialTeacher> SocialTeachers { get; set; }


    }
}