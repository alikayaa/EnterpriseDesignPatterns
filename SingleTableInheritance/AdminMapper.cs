using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTableInheritance
{
    public class AdminMapper : AbstractMapper
    {
        public  DomainObject LoadUser(int Id, params string[] userParams)
        {
            User _user = new User(Id);
            _user.Ad = userParams[0];
            _user.isAdmin = true;
            _user.Title = userParams[1];
            return _user;
        }
        public override bool isAdmin
        {
            get { return true; }
        }

        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            throw new NotImplementedException();
        }
    }
}
