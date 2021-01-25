namespace WebApplication_brr_bmi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yangilik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sarlovha = c.String(),
                        Rasm1 = c.String(),
                        Batafsil = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yangilik");
        }
    }
}
