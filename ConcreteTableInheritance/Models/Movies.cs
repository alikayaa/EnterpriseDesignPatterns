using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Models
{
    // Film Entity’si (Tablo:Movies)
    public class Movies:Category
    {
        public string Aciklama { get; set; }
    }
}