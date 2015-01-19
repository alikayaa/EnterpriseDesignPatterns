using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTableInheritance
{
    public class AdminMapper : AbstractUserMapper
    {

        public AdminMapper()
        {

        }
     
        public override bool isAdmin
        {
            get { return true; }
        }

       
        protected static string TABLENAME = "YoneticiKullanici";


        protected override DomainObject CreateDomainObject()
        {
            return new AdminUser();
        }

        protected override void Load(DomainObject domainObject)
        {
            // Base'i çağır( Base Constructor çağır.)
            base.Load(domainObject);
            // Kendi özel tablomda kaydı ara.
            DataRow row = FindRow(domainObject.ID, tableFor(TABLENAME));
            // Alanları doldur.
            AdminUser _adminUser = (AdminUser)domainObject;
            _adminUser.IsAddUser = (bool)row["IsAddUser"];
            _adminUser.IsDeleteUser = (bool)row["IsDeleteUser"];
            _adminUser.IsUpdateUser = (bool)row["IsUpdateUser"];
        }

        public AdminUser Find(int Id, string TableName)
        {
            return (AdminUser)AbstractFind(Id, TableName);
        }
    }
}
