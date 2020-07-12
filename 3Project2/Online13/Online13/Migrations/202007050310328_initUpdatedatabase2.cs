namespace Online13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initUpdatedatabase2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        VideoTitle = c.String(maxLength: 30),
                        VideoLink = c.String(maxLength: 150),
                        VideBgImage = c.String(maxLength: 150),
                        NoticeTitle = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AboutSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        FullName = c.String(maxLength: 50),
                        Content = c.String(maxLength: 500),
                        Position = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Image = c.String(maxLength: 150),
                        ByAuthor = c.String(maxLength: 50),
                        AddedDate = c.DateTime(nullable: false),
                        Content = c.String(storeType: "ntext"),
                        ViewCount = c.Int(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .Index(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        UpperTitle = c.String(nullable: false, maxLength: 30),
                        FirstTitle = c.String(nullable: false, maxLength: 30),
                        SecondTitle = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(maxLength: 150),
                        InputContent = c.String(maxLength: 500),
                        Content = c.String(storeType: "ntext"),
                        Starts = c.DateTime(nullable: false),
                        Duration = c.String(maxLength: 20),
                        ClassDuration = c.String(maxLength: 20),
                        SkillLevel = c.String(nullable: false, maxLength: 20),
                        Language = c.String(nullable: false, maxLength: 10),
                        StudentCount = c.Int(nullable: false),
                        Assesments = c.String(maxLength: 20),
                        Price = c.Int(nullable: false),
                        CourseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategoryId, cascadeDelete: true)
                .Index(t => t.CourseCategoryId);
            
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        Image = c.String(maxLength: 150),
                        StarsTime = c.String(nullable: false, maxLength: 30),
                        EndTime = c.String(nullable: false, maxLength: 30),
                        Venue = c.String(),
                        Content = c.String(storeType: "ntext"),
                        AddedDate = c.DateTime(nullable: false),
                        EventCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCategories", t => t.EventCategoryId, cascadeDelete: true)
                .Index(t => t.EventCategoryId);
            
            CreateTable(
                "dbo.EventRelSpeakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        SpeakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.SpeakerId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        Content = c.String(storeType: "ntext"),
                        language = c.Int(nullable: false),
                        TeamLeader = c.Int(nullable: false),
                        Development = c.Int(nullable: false),
                        Design = c.Int(nullable: false),
                        Innoation = c.Int(nullable: false),
                        Communication = c.Int(nullable: false),
                        mail = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 30),
                        skpe = c.String(nullable: false, maxLength: 30),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.SocialTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 30),
                        Link = c.String(maxLength: 150),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.IntroImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Page = c.String(nullable: false, maxLength: 20),
                        Title = c.String(maxLength: 50),
                        Image = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 300),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.pageAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 50),
                        AdminName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Page = c.String(nullable: false, maxLength: 20),
                        Title = c.String(maxLength: 50),
                        Image = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 150),
                        AddressStreet = c.String(nullable: false, maxLength: 35),
                        AddressCity = c.String(nullable: false, maxLength: 35),
                        FirstPhone = c.String(nullable: false, maxLength: 35),
                        SecondPhone = c.String(nullable: false, maxLength: 30),
                        FirstEmail = c.String(nullable: false, maxLength: 35),
                        SecondEmail = c.String(nullable: false, maxLength: 35),
                        FooterContent = c.String(nullable: false, maxLength: 500),
                        CopyRight = c.String(nullable: false, maxLength: 20),
                        BgImage = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Icon = c.String(nullable: false, maxLength: 20),
                        Link = c.String(maxLength: 150),
                        SettingsId = c.Int(nullable: false),
                        Setting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Settings", t => t.Setting_Id)
                .Index(t => t.Setting_Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherContactDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UpperTitle = c.String(maxLength: 20),
                        FirstTitle = c.String(maxLength: 20),
                        SecondTitle = c.String(maxLength: 20),
                        ThirdTitle = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 60),
                        Image = c.String(maxLength: 150),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(maxLength: 30),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialCompanies", "Setting_Id", "dbo.Settings");
            DropForeignKey("dbo.SocialTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Speakers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.EventRelSpeakers", "SpeakerId", "dbo.Speakers");
            DropForeignKey("dbo.EventRelSpeakers", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "EventCategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.Courses", "CourseCategoryId", "dbo.CourseCategories");
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.SocialCompanies", new[] { "Setting_Id" });
            DropIndex("dbo.SocialTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropIndex("dbo.Speakers", new[] { "PositionId" });
            DropIndex("dbo.EventRelSpeakers", new[] { "SpeakerId" });
            DropIndex("dbo.EventRelSpeakers", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "EventCategoryId" });
            DropIndex("dbo.Courses", new[] { "CourseCategoryId" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.TeacherContactDatas");
            DropTable("dbo.Subscribes");
            DropTable("dbo.SocialCompanies");
            DropTable("dbo.Settings");
            DropTable("dbo.Posters");
            DropTable("dbo.pageAdmins");
            DropTable("dbo.Notices");
            DropTable("dbo.IntroImages");
            DropTable("dbo.SocialTeachers");
            DropTable("dbo.Teachers");
            DropTable("dbo.Positions");
            DropTable("dbo.Speakers");
            DropTable("dbo.EventRelSpeakers");
            DropTable("dbo.Events");
            DropTable("dbo.EventCategories");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Contacts");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Applications");
            DropTable("dbo.AboutSliders");
            DropTable("dbo.Abouts");
        }
    }
}
