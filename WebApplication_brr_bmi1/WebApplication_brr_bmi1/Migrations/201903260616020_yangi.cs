namespace WebApplication_brr_bmi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yangi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Valyuta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Summa = c.Double(nullable: false),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Valyuta");
        }
    }
}
