using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClassTableInheritance
{
    public abstract class AbstractMapper
    {
        // Identity Map
        private Dictionary<int, DomainObject> loadedMap = new Dictionary<int, DomainObject>();
        // Entity Tiplerini belirleme
        public abstract bool isAdmin { get; }
        // Her bir entity için tablo adı vermek zorunludur. Bu sınıfta base sınıfın tablo adı verilir.
        protected static string TABLENAME = "Kullanici";
        // Genel Arama
        protected DomainObject AbstractFind(int Id,string TableName)
        {
            // Root Kayıt
            DataRow row = FindRow(Id, TableName);
            if (row == null) return null;
            // Veriyi çeken mapper'a  özel sonuç nesnesi oluşturulur.
            DomainObject result = CreateDomainObject();
            // Identity Map içerisinde bulursan geri döndür.
            if (loadedMap.ContainsKey(Id))
            {
                result = loadedMap[Id];
                return result;
            }
            // Root kayıttaki Id ile diğer tablodaki kayıt birbirine bağlanır.
            result.ID = Id;
            // Çağıran Soyut Mapper sınıfındaki Load bu kayıt ile çalıştırılır.
            Load(result);
            // Identity Map'e sonuç eklenir.
            AddIndentityMap(Id, result);
            return result;
        }

        // Identity Map'e Ekle.
        protected void AddIndentityMap(int Id, DomainObject Entity)
        {
            if (!loadedMap.ContainsKey(Id))
                loadedMap.Add(Id, Entity);
        }

        private string findSql()
        {
            return "SELECT * FROM Kullanici WHERE Id = {0}";
        }

        protected abstract void Load(DomainObject domainObject);

        protected DataTable tableFor(string name)
        {
            return gateway.Data.Tables[name];
        }
        
        protected DataRow FindRow(int id, DataTable table)
        {
            String filter = String.Format("Id = {0}", id);
            DataRow[] results = table.Select(filter);
            return (results.Length == 0) ? null : results[0];
        }
        
        protected DataRow FindRow(int id, String tablename)
        {
            return FindRow(id, tableFor(tablename));
        }


        protected abstract DomainObject CreateDomainObject();

        public Gateway gateway = new Gateway();
    }
}