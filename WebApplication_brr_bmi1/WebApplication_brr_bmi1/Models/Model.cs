using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_brr_bmi1.Models
{
    public class Viloyat
    {
        public int Id { get; set; }
        public string Viloyat_nomi { get; set; }
        public ICollection<Tuman> Tumanlar { get; set; }

    }
    public class Tuman
    {
        public int Id { get; set; }
        public string Tuman_nomi { get; set; }
        public int? ViloyatId { get; set; }
        public Viloyat Viloyat { get; set; }
        public ICollection<Xaridor> Xaridorlar { get; set; }
        public ICollection<Uy> Uylar { get; set; }

    }
    public class Uy
    {
        public int Id { get; set; }

        public string Manzil { get; set; }
        public int? TumanId { get; set; }
        public Tuman Tuman { get; set; }
        public ICollection<Xonadon> Xonadonlar { get; set; }
    }
    public class Xonadon
    {
        public int Id { get; set; }
        public int Xonalar_soni { get; set; }
        public int Nechnchi_qavat { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }

        public int? UyId { get; set; }
        public Uy Uy { get; set; }
        public int? UyturiId{get;set;}
        public Uyturi Uyturi{get;set;}
        public int Holati { get; set; }
        public ICollection<sotuv> Sotuv { get; set; }

    }
    public class tulov
    {
        public int Id { get; set; }
        public string Tulov_turi { get; set; }
        public ICollection<sotuv> Sotuv { get; set; }

    }
    public class Xaridor
    {
        public int Id { get; set; }
        public string Familiya { get; set; }
        public string Ismi { get; set; }
        public string Sharif { get; set; }
        public DateTime? tug_yili { get; set; }
        public string Pas_ser { get; set; }
        public string Millati { get; set; }
        public int? TumanId { get; set; }
        public Tuman Tuman { get; set; }
        public ICollection<sotuv> Sotuv { get; set; }
        public ICollection<Users> Userslar { get; set; }

    }

    public class sotuv
    {
        public int Id { get; set; }
        public int? XaridorId { get; set; }
        public Xaridor Xaridor { get; set; }
        public int? XonadonId { get; set; }
        public Xonadon Xonadon { get; set; }
        public int? tulovId { get; set; }
        public tulov tulov { get; set; }

    }
    public class Roles
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public ICollection<Users> Userslar { get; set; }

    }
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RolesId { get; set; }
        public Roles Roles { get; set; }
        public int? XaridorId { get; set; }
        public Xaridor Xaridor { get; set; }
    }
    public class Valyuta 
    {
    public int Id { get;set;}
    public double Summa { get; set; }
    public string Nomi { get; set; }
    }
    public class Yangilik
    {
        public int Id { get; set; }
        public string Sarlovha { get; set; }
        public string Rasm1 { get; set; }
        public string Batafsil { get; set; }
    }
    public class Uyturi
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public ICollection<Xonadon> Xonadonlar { get; set; }
        
    }
}