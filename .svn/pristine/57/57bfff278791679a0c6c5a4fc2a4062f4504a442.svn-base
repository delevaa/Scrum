namespace ScrumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Story", "ProjectId", c => c.Int());
            AddForeignKey("dbo.Story", "ProjectId", "dbo.Project", "Id");
            CreateIndex("dbo.Story", "ProjectId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Story", new[] { "ProjectId" });
            DropForeignKey("dbo.Story", "ProjectId", "dbo.Project");
            DropColumn("dbo.Story", "ProjectId");
        }
    }
}
