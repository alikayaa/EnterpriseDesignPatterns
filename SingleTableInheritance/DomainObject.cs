using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleTableInheritance
{
    public abstract class DomainObject
    {
        private int _id;
        public DomainObject(int Id)
        {
            this._id = Id;
        }
        public int ID
        {

            get
            {
                return this._id;
            }

            set
            {

                this._id = value;
            }
        }
    }
}