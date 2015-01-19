using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTableInheritance.Mapper
{
    public class UserMapper : AbstractUserMapper
    {
        AdminMapper _adminMapper = new AdminMapper();
        NormalUserMapper _userMapper = new NormalUserMapper();
        public User Find(int Id)
        {
            DataRow row = FindRow(Id, tableFor(TABLENAME));
            if (row == null) return null;
            else
            {
                // Base Tablodaki Flag Alan
                bool userIsAdmin = (bool)row["isAdmin"];
                // Kullanıcı Tipine Göre Yönlendirme
                if (userIsAdmin)
                {
                    _adminMapper.gateway.Data = this.gateway.Data;
                    return _adminMapper.Find(Id);
                }
                else
                {
                    _userMapper.gateway.Data = this.gateway.Data;
                    return _userMapper.Find(Id);
                }

                throw new Exception("unknown type");
            }
        }
        protected static String TABLENAME = "Kullanici";
    }
}
