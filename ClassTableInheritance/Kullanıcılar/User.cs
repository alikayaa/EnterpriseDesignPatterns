using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTableInheritance
{
    public class User:DomainObject
    {
        public string Name { get; set; }
        public User()
        {

        }
        public User(int Id):base(Id)
        {

        }
    }
}
