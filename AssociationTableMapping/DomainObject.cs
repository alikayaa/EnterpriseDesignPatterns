using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public abstract class DomainObject
    {
        private int _id;
        
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