using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializedBlob
{
    public class PageMapper : AbstractMapper
    {
        public Page Find(int Id)
        {
            return (Page)AbstractFind(Id);
        }

        protected override string findSql()
        {
            return "SELECT * FROM Page WHERE Id = {0}";
        }

        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            Page _generatePage = new Page(Id);
            if (res.Read())
            {
                _generatePage.XmlString = res.GetString(1);
            }
            _generatePage.toXml();
            return _generatePage;
        }
    }
}
