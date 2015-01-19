using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependentMapping
{
    public class Rehber : DomainObject
    {
        private IList _kisiler = new ArrayList();
        private string _adi;

        public Rehber(string RehberAdi)
        {
            this._adi = RehberAdi;
        }

        public string RehberAdi
        {
            get { return this._adi; }
            set { this._adi = value; }
        }

        public IList Kisiler
        {
            get { return this._kisiler; }
            set { this._kisiler = new ArrayList(value); }
        }

        public void KisiEkle(Kisi kisi)
        {
            this._kisiler.Add(kisi);
        }

        public void KisiSil(Kisi kisi)
        {
            this._kisiler.Remove(kisi);
        }
    }
}