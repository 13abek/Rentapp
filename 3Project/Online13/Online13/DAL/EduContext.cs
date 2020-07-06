using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Online13.Models;

namespace Online13.DAL
{
    public class EduContext:DbContext
    {
        public EduContext() : base("EduContexCS")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutSlider> AboutSliders { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<pageAdmin> pageAdmins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRelSpeakers> eventRelSpeakers { get; set; }
        public DbSet<EventCategory> eventCategories { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<IntroImage> IntroImages { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialCompany> SocialCompanies { get; set; }
        public DbSet<SocialTeacher> SocialTeachers { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherContactData> TeacherContactDatas { get; set; }
        public DbSet<User> Users { get; set; }




    }
}