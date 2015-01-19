using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ForeignKeyMapping
{
    public class YazarMapper : AbstractMapper
    {

        public Yazar Find(int Id)
        {
            return (Yazar)AbstractFind(Id);
        }

        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            string YazarAdi = res.GetString(1);
            Yazar yazar = new Yazar(Id, YazarAdi);
            return yazar;
        }

        protected override string findSql()
        {
            return "SELECT Id,Adi FROM Yazar WHERE Id = ";
        }

    }
}