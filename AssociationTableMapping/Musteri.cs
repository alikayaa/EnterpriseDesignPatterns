using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public class Musteri:DomainObject
    {
        private string _adi;
        private IList _urunler = new ArrayList();
        
        public IList Urunler
        {
            get { return this._urunler; }
            set { this._urunler = new ArrayList(value); }
        }

        public string Adi
        {
            get { return this._adi; }
            set { this._adi = value; }
        }

        public void UrunEkle(Urun urun)
        {
            this._urunler.Add(urun);
        }

        public void UrunSil(Urun urun)
        {
            this._urunler.Remove(urun);
        }
    }
}