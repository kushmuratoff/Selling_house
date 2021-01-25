using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_brr_bmi1.Models
{
    public class Sahifa
    {
        public List<Xonadon> Xonadon { get; set; }
        public List<Yangilik> Yangilik { get; set; }
        public List<Xaridor> Xaridor { get; set; }
        public List<tulov> tulov { get; set; }

    }
}