using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(500)]
        public string InputContent { get; set; }
        [Column(TypeName = "nText")]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MimeMapping-dd}",
            ApplyFormatInEditMode =true)]
        public DateTime Starts { get; set; }
        [MaxLength(20)]
        public string Duration { get; set; }
        [MaxLength(20)]
        public string ClassDuration { get; set; }
        [MaxLength(20)]
        [Required]
        public string SkillLevel { get; set; }
        [MaxLength(10)]
        [Required]
        public string Language { get; set; }
        public int StudentCount { get; set; }
        [MaxLength(20)]
        public string Assesments { get; set; }
        [Required]
        public int Price { get; set; }
        public int CourseCategoryId { get; set; }
        public CourseCategory CourseCategory { get; set; }
        

    }
}