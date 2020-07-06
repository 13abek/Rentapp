﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online13.Models
{
    public class AboutSlider
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        [MaxLength(50)]
        public string Position { get; set; }

    }
}