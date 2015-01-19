using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Models
{
    // Telefon Entity'si(Tablo:Phone)
    public class Phone:Category
    {
        public string FourG { get; set; }
        public string EkranGenisligi { get; set; }
        public string Aciklama { get; set; }
    }
}