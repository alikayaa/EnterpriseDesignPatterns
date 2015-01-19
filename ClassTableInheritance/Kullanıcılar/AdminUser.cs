using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTableInheritance
{
    public class AdminUser:User
    {
        public bool IsAddUser { get; set; }
        public bool IsDeleteUser { get; set; }
        public bool IsUpdateUser { get; set; }
    }
}
