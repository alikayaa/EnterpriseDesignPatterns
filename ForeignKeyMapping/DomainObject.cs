using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForeignKeyMapping
{
    public abstract class DomainObject
    {
        private int ID;
        public DomainObject(int Id)
        {
            this.ID = Id;
        }
    }
}