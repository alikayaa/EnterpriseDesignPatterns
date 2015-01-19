using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DependentMapping
{
    public abstract class AbstractMapper
    {
        // Identity Map
        private Dictionary<int, DomainObject> loadedMap = new Dictionary<int, DomainObject>();
        // Her entity'nin kendine göre oluşturacağı Sql sorgusu
        abstract protected string findSql();
        // Her entity yüklenmesi alt sınıflarda kendisine göre özel olarak yaptırılır
        abstract protected DomainObject LoadEntity(int Id, SqlDataReader res);
        // Genel Arama
        protected DomainObject AbstractFind(int Id)
        {
            DomainObject result = null;
            // Identity Map içerisinde bulursan geri döndür.
            if (loadedMap.ContainsKey(Id))
                result = loadedMap[Id];

            if (result != null) return result;
            // Bulamazsan veri tabanından getir.
            SqlConnection conn = new SqlConnection(@"Data Source=WINDOZE\SQLEXPRESS;Initial Catalog=DAI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            SqlCommand comm = new SqlCommand(string.Format(findSql(),Id), conn);
            var res = comm.ExecuteReader();
            // Veri Yükle
            result = LoadEntity(Id,res);
            AddIndentityMap(Id, result);
            conn.Close();
            return result;
        }

        // Identity Map'e Ekle.
        protected void AddIndentityMap(int Id, DomainObject Entity)
        {
            if (!loadedMap.ContainsKey(Id))
                loadedMap.Add(Id, Entity);
        }
    }
}