namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Agenda", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Agenda", new[] { "Name" });
        }
    }
}
