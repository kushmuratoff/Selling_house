namespace WebApplication_brr_bmi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assalom1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xonadon", "UyturiId", c => c.Int());
            CreateIndex("dbo.Xonadon", "UyturiId");
            AddForeignKey("dbo.Xonadon", "UyturiId", "dbo.Uyturi", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Xonadon", "UyturiId", "dbo.Uyturi");
            DropIndex("dbo.Xonadon", new[] { "UyturiId" });
            DropColumn("dbo.Xonadon", "UyturiId");
        }
    }
}
