using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTableInheritance
{
    public class  AbstractUserMapper : AbstractMapper
    {
        public User Find(int Id)
        {
            return (User)AbstractFind(Id,TABLENAME);
        }

        protected override void Load(DomainObject obj)
        {
            DataRow row = FindRow(obj.ID, tableFor(TABLENAME));
            User user = (User)obj;
            user.Name = (String)row["Ad"];
        }


        public override bool isAdmin
        {
            get { return true; }
        }
        protected static string TABLENAME = "Kullanici";

        protected override DomainObject CreateDomainObject()
        {
            return new User();
        }
    }
}
