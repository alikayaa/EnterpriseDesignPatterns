using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedValue
{
    public class IlanSuresi
    {
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }

        public IlanSuresi(DateTime basTarih,DateTime bitTarih)
        {
            Baslangic = basTarih;
            Bitis = bitTarih;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}",this.Baslangic.ToShortDateString(),this.Bitis.ToShortDateString());
        }
    }
}