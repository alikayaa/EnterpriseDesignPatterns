using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForeignKeyMapping
{
    public class Kitap:DomainObject
    {
        private string _adi;
        private Yazar _yazar;
        public Kitap(int Id,string Adi,Yazar Yazar):base(Id)
        {
            this._adi = Adi;
            this._yazar = Yazar;
        }
        public string Adi
        {
            get
            {
                return this._adi;
            }

            set
            {
                this._adi = value;
            }

        }
        public Yazar Yazar
        {
            get
            {
                return this._yazar;
            }

            set
            {
                this._yazar = value;
            }

        }
    }
}