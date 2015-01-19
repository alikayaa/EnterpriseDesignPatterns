using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public class Urun : DomainObject
    {
        private string _adi;
        private IList _musteriler = new ArrayList();
        
        public IList Musteriler
        {
            get { return this._musteriler; }
            set { this._musteriler = new ArrayList(value); }
        }
        public string Adi
        {
            get { return this._adi; }
            set { this._adi = value; }
        }

        
        public void MusteriEkle(Musteri musteri)
        {
            this._musteriler.Add(musteri);
        }

        public void MusteriSil(Musteri musteri)
        {
            this._musteriler.Remove(musteri);
        }
    }
}