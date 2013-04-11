namespace ScrumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Car",
            //    c => new
            //        {
            //            CarID = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Manufacturer = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.CarID);
            
            //CreateTable(
            //    "dbo.Project",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Description = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Project_User",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Role = c.String(maxLength: 50),
            //            UserId = c.Int(),
            //            ProjectId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Project", t => t.ProjectId)
            //    .ForeignKey("dbo.User", t => t.UserId)
            //    .Index(t => t.ProjectId)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.User",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Username = c.String(nullable: false, maxLength: 50),
            //            Password = c.String(nullable: false, maxLength: 50),
            //            Name = c.String(maxLength: 50),
            //            Surname = c.String(maxLength: 50),
            //            Email = c.String(maxLength: 50),
            //            isAdmin = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Sprint",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            DateFrom = c.DateTime(nullable: false),
            //            DateTo = c.DateTime(nullable: false),
            //            Velocity = c.Int(),
            //            Status = c.Boolean(),
            //            ProjectId = c.Int(),
            //            StoryId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Project", t => t.ProjectId)
            //    .ForeignKey("dbo.Story", t => t.StoryId)
            //    .Index(t => t.ProjectId)
            //    .Index(t => t.StoryId);
            
            //CreateTable(
            //    "dbo.Story",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Description = c.String(),
            //            Tests = c.String(),
            //            Priority = c.String(nullable: false, maxLength: 10, fixedLength: true),
            //            BusinessValue = c.Double(nullable: false),
            //            Status = c.String(nullable: false, maxLength: 10, fixedLength: true),
            //            Notes = c.String(),
            //            Points = c.Double(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.sysdiagrams",
            //    c => new
            //        {
            //            diagram_id = c.Int(nullable: false, identity: true),
            //            name = c.String(nullable: false, maxLength: 128),
            //            principal_id = c.Int(nullable: false),
            //            version = c.Int(),
            //            definition = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Sprint", new[] { "StoryId" });
            //DropIndex("dbo.Sprint", new[] { "ProjectId" });
            //DropIndex("dbo.Project_User", new[] { "UserId" });
            //DropIndex("dbo.Project_User", new[] { "ProjectId" });
            //DropForeignKey("dbo.Sprint", "StoryId", "dbo.Story");
            //DropForeignKey("dbo.Sprint", "ProjectId", "dbo.Project");
            //DropForeignKey("dbo.Project_User", "UserId", "dbo.User");
            //DropForeignKey("dbo.Project_User", "ProjectId", "dbo.Project");
            //DropTable("dbo.sysdiagrams");
            //DropTable("dbo.Story");
            //DropTable("dbo.Sprint");
            //DropTable("dbo.User");
            //DropTable("dbo.Project_User");
            //DropTable("dbo.Project");
            //DropTable("dbo.Car");
        }
    }
}
