using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Models
{
    // Base Domain Model Object Sınıfı
    public abstract class DomainObject
    {
        // Id
        public int ID { get; set; }
        public DomainObject()
        {

        }
        public DomainObject(int Id)
        {
            this.ID = Id;
        }
    }
}