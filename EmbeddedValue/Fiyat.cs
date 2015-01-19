using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedValue
{
    public class Fiyat
    {
        public int IlanFiyat { get; set; }
        public string Kur { get; set; }
        public Fiyat(int Fiyat,string Kur)
        {
            this.IlanFiyat = Fiyat;
            this.Kur = Kur;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",this.IlanFiyat,this.Kur);
        }
    }
}