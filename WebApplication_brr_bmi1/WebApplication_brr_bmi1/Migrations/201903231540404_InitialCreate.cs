namespace WebApplication_brr_bmi1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        RolesId = c.Int(),
                        XaridorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RolesId)
                .ForeignKey("dbo.Xaridor", t => t.XaridorId)
                .Index(t => t.RolesId)
                .Index(t => t.XaridorId);
            
            CreateTable(
                "dbo.Xaridor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Familiya = c.String(),
                        Ismi = c.String(),
                        Sharif = c.String(),
                        tug_yili = c.DateTime(),
                        Pas_ser = c.String(),
                        Millati = c.String(),
                        TumanId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tuman", t => t.TumanId)
                .Index(t => t.TumanId);
            
            CreateTable(
                "dbo.sotuv",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        XaridorId = c.Int(),
                        XonadonId = c.Int(),
                        tulovId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tulov", t => t.tulovId)
                .ForeignKey("dbo.Xaridor", t => t.XaridorId)
                .ForeignKey("dbo.Xonadon", t => t.XonadonId)
                .Index(t => t.XaridorId)
                .Index(t => t.XonadonId)
                .Index(t => t.tulovId);
            
            CreateTable(
                "dbo.tulov",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tulov_turi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Xonadon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Xonalar_soni = c.Int(nullable: false),
                        Nechnchi_qavat = c.Int(nullable: false),
                        Narxi = c.String(),
                        Malumot = c.String(),
                        UyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uy", t => t.UyId)
                .Index(t => t.UyId);
            
            CreateTable(
                "dbo.Uy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manzil = c.String(),
                        TumanId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tuman", t => t.TumanId)
                .Index(t => t.TumanId);
            
            CreateTable(
                "dbo.Tuman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tuman_nomi = c.String(),
                        ViloyatId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Viloyat", t => t.ViloyatId)
                .Index(t => t.ViloyatId);
            
            CreateTable(
                "dbo.Viloyat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Viloyat_nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "XaridorId", "dbo.Xaridor");
            DropForeignKey("dbo.Xonadon", "UyId", "dbo.Uy");
            DropForeignKey("dbo.Xaridor", "TumanId", "dbo.Tuman");
            DropForeignKey("dbo.Tuman", "ViloyatId", "dbo.Viloyat");
            DropForeignKey("dbo.Uy", "TumanId", "dbo.Tuman");
            DropForeignKey("dbo.sotuv", "XonadonId", "dbo.Xonadon");
            DropForeignKey("dbo.sotuv", "XaridorId", "dbo.Xaridor");
            DropForeignKey("dbo.sotuv", "tulovId", "dbo.tulov");
            DropForeignKey("dbo.Users", "RolesId", "dbo.Roles");
            DropIndex("dbo.Tuman", new[] { "ViloyatId" });
            DropIndex("dbo.Uy", new[] { "TumanId" });
            DropIndex("dbo.Xonadon", new[] { "UyId" });
            DropIndex("dbo.sotuv", new[] { "tulovId" });
            DropIndex("dbo.sotuv", new[] { "XonadonId" });
            DropIndex("dbo.sotuv", new[] { "XaridorId" });
            DropIndex("dbo.Xaridor", new[] { "TumanId" });
            DropIndex("dbo.Users", new[] { "XaridorId" });
            DropIndex("dbo.Users", new[] { "RolesId" });
            DropTable("dbo.Viloyat");
            DropTable("dbo.Tuman");
            DropTable("dbo.Uy");
            DropTable("dbo.Xonadon");
            DropTable("dbo.tulov");
            DropTable("dbo.sotuv");
            DropTable("dbo.Xaridor");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
