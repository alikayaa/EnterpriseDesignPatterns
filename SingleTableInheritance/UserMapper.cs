using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTableInheritance
{
    public class  UserMapper : AbstractMapper
    {
        public AdminMapper _adminMapper = new AdminMapper();
        public NormalUserMapper _nUserMapper = new NormalUserMapper();

        public User Find(int Id)
        {
            return (User)AbstractFind(Id);
        }
        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            if (res.Read())
            {

                bool userIsAdmin = res.GetBoolean(2);
                if (userIsAdmin)
                    return _adminMapper.LoadUser(Id, res.GetString(1),res.GetString(3));
                else
                    return _nUserMapper.LoadUser(Id, res.GetString(1));
            }

            else
                return null;
        }

        public override bool isAdmin
        {
            get { return true; }
        }

    }
}
