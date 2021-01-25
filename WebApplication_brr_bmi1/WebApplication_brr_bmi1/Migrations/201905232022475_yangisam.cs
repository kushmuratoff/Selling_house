namespace WebApplication_brr_bmi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yangisam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xonadon", "Holati", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Xonadon", "Holati");
        }
    }
}
