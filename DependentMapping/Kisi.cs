using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependentMapping
{
    public class Kisi:DomainObject
    {
        private string _adi;
        private string _numarasi;

        public Kisi(string Adi,string Numarasi)
        {
            this._adi = Adi;
            this._numarasi = Numarasi;
        }

        public string Adi
        {
            get { return this._adi; }
            set { this._adi = value; }
        }

        public string Numarasi
        {
            get { return this._numarasi; }
            set { this._numarasi= value; }
        }
    }
}