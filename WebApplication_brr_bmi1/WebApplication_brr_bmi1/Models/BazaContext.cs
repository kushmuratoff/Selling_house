using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication_brr_bmi1.Models;

namespace WebApplication_brr_bmi1.Models
{
    public class BazaContext : DbContext
    {
        public DbSet<Viloyat> Viloyat { get; set; }
        public DbSet<Tuman> Tuman { get; set; }
        public DbSet<Uy> Uy { get; set; }
        public DbSet<Xonadon> Xonadon { get; set; }
        public DbSet<tulov> tulov { get; set; }
        public DbSet<Xaridor> Xaridor { get; set; }

        public DbSet<sotuv> sotuv { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Valyuta> Valyuta { get; set; }
        public DbSet<Yangilik> Yangilik { get; set; }
        public DbSet<Uyturi> Uyturi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
    public class BazaInit : DropCreateDatabaseIfModelChanges<BazaContext>
    {
        protected override void Seed(BazaContext context)
        {

            context.tulov.Add(new tulov { Tulov_turi = "Naqd" });
            base.Seed(context);
        }
    }
}