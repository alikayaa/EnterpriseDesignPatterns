using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForeignKeyMapping
{
    public class Yazar:DomainObject
    {
        private string _adi;
        public Yazar(int Id, string Adi)
            : base(Id)
        {
            this._adi = Adi;

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
    }
}