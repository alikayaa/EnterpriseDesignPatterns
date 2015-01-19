using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTableInheritance
{
    public class NormalUserMapper : AbstractUserMapper
    {

        public NormalUserMapper()
        {
                
        }
        public override bool isAdmin
        {
            get { return false; }
        }

        protected static string TABLENAME = "NormalKullanici";

        protected override DomainObject CreateDomainObject()
        {
            return new AdminUser();
        }

        protected override void Load(DomainObject domainObject)
        {
            base.Load(domainObject);
            DataRow row = FindRow(domainObject.ID, tableFor(TABLENAME));
            NormalUser _nUser = (NormalUser)domainObject;
            _nUser.Yoneticisi = (string)row["Takimi"];
        }

        public NormalUser Find(int Id, string TableName)
        {
            return (NormalUser)AbstractFind(Id, TableName);
        }
    }
}
