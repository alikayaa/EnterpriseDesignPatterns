using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTableInheritance
{
    public class NormalUserMapper : AbstractMapper
    {
        public DomainObject LoadUser(int Id, params string[] userParams)
        {
            User _user = new User(Id);
            _user.Ad = userParams[0];
            return _user;
        }
        public override bool isAdmin
        {
            get { return false; }
        }

        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            throw new NotImplementedException();
        }
    }
}
