using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DependentMapping
{
    public class RehberMapper : AbstractMapper
    {
        public Rehber Find(int Id)
        {
            return (Rehber)AbstractFind(Id);
        }
        protected override string findSql()
        {
            return "SELECT R.Id,R.Adi,K.Adi,K.Numarasi FROM Rehber R,Kisi K WHERE R.Id = K.RehberId AND R.ID = {0}";
        }

        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            Rehber rehber = new Rehber(string.Empty);
            while (res.Read())
            {
                rehber.RehberAdi = res.GetString(1);
                rehber.KisiEkle(new Kisi(res.GetString(2), res.GetString(3)));
            }
            return rehber;
        }

    }
}