using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Models
{
    // Bilgisayar Entity’si (Tablo:Computer)
    public class Computer:Category
    {
        public string EkranTipi { get; set; }
        public string Depolama{ get; set; }        
    }
}