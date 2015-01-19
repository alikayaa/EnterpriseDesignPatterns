using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ForeignKeyMapping
{
    public class KitapMapper:AbstractMapper
    {
        public Kitap Find(int Id)
        {
            return (Kitap)AbstractFind(Id);
        }
        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            string KitapAdi = res.GetString(1);
            int YazarId = res.GetInt32(2);
            YazarMapper YazarMapper = (YazarMapper)MapperRegistry.Mapper(typeof(YazarMapper));
            Yazar Yazar = YazarMapper.Find(YazarId);
            Kitap Kitap = new Kitap(Id, KitapAdi, Yazar);
            return Kitap;
        }

        protected override string findSql()
        {
            return "SELECT Id,Adi,YazarId FROM Kitap WHERE Id = ";
        }
    }
}