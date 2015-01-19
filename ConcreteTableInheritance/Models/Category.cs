using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Models
{
    public abstract class Category : DomainObject
    {
        // Ortak Alan
        public string Adi { get; set; }
    }
}