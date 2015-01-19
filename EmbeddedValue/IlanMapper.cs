using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmbeddedValue
{
    public class IlanMapper:AbstractMapper
    {
        public Ilan Find(int Id)
        {

            return (Ilan)AbstractFind(Id);
        }
        protected override string findSql()
        {
            return "SELECT * FROM Ilanlar WHERE Id = {0}";
        }

        protected override DomainObject LoadEntity(int Id, SqlDataReader res)
        {
            Ilan ilan = new Ilan(Id);
            if (res.Read())
            {
                string kur = res.GetString(4);
                int ilanFiyat = res.GetInt32(3);
                DateTime basTarih = res.GetDateTime(1);
                DateTime bitTarih = res.GetDateTime(2);
                IlanSuresi _ilanSuresi = new IlanSuresi(basTarih,bitTarih);
                Fiyat _ilanFiyat = new Fiyat(ilanFiyat,kur);
                ilan.IlanAdi = res.GetString(5);
                ilan.IlanFiyat = _ilanFiyat;
                ilan.IlanSuresi = _ilanSuresi;
            }
            return ilan;
        }
    }
}