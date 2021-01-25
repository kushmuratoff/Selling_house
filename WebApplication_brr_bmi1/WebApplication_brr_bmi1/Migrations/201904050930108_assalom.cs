namespace WebApplication_brr_bmi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assalom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uyturi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uyturi");
        }
    }
}
