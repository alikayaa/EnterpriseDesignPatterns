using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTableInheritance
{
    public class User : DomainObject
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool isAdmin { get; set; }
        public string Title { get; set; }
        public User(int Id):base(Id)
        {

        }
    }
}
