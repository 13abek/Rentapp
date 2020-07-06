namespace Online13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsaIDupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SocialCompanies", "Setting_Id", "dbo.Settings");
            DropIndex("dbo.SocialCompanies", new[] { "Setting_Id" });
            RenameColumn(table: "dbo.SocialCompanies", name: "Setting_Id", newName: "SettingId");
            AlterColumn("dbo.SocialCompanies", "SettingId", c => c.Int(nullable: false));
            CreateIndex("dbo.SocialCompanies", "SettingId");
            AddForeignKey("dbo.SocialCompanies", "SettingId", "dbo.Settings", "Id", cascadeDelete: true);
            DropColumn("dbo.SocialCompanies", "SettingsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialCompanies", "SettingsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SocialCompanies", "SettingId", "dbo.Settings");
            DropIndex("dbo.SocialCompanies", new[] { "SettingId" });
            AlterColumn("dbo.SocialCompanies", "SettingId", c => c.Int());
            RenameColumn(table: "dbo.SocialCompanies", name: "SettingId", newName: "Setting_Id");
            CreateIndex("dbo.SocialCompanies", "Setting_Id");
            AddForeignKey("dbo.SocialCompanies", "Setting_Id", "dbo.Settings", "Id");
        }
    }
}
