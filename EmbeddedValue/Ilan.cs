using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedValue
{
    public class Ilan:DomainObject
    {
        public Fiyat IlanFiyat { get; set; }
        public IlanSuresi IlanSuresi { get; set; }
        public string IlanAdi { get; set; }
        public Ilan(int Id):base(Id)
        {

        }
    }
}