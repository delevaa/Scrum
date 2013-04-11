namespace ScrumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Members", new[] { "UserId" });
            DropIndex("dbo.Members", new[] { "ProjectId" });
            DropForeignKey("dbo.Members", "UserId", "dbo.User");
            DropForeignKey("dbo.Members", "ProjectId", "dbo.Project");
            DropTable("dbo.Members");
        }
    }
}
