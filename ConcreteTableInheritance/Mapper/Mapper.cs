using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public abstract class Mapper
    {
        // Identity Map
        public Dictionary<int, DomainObject> loadedMap = new Dictionary<int, DomainObject>();
        // Data gateway
        public Gateway Gateway;
        // Yapıcı Metod
        public Mapper(Gateway gateway)
        {
            this.Gateway = gateway;
        }
        // Veri
        public DataTable table
        {
            get { return Gateway.Data.Tables[TableName]; }
        }
        // Entity'e Özel Tablo Adı
        abstract public string TableName { get; }

        // Genel Arama
        public DomainObject AbstractFind(int Id)
        {
            // Satırı bul
            DataRow row = FindRow(Id);
            if (row == null) return null;
            else
            {
                // Entity nesnesi oluştur.
                DomainObject result = CreateDomainObject();
                // Identity Map içerisinde bulursan geri döndür.
                if (loadedMap.ContainsKey(Id))
                {
                    result = loadedMap[Id];
                    return result;
                }
                // Nesneyi yükle.
                Load(result, row);
                // Identity Field'e Ekle.
                AddIndentityMap(result.ID, result);
                return result;
            }
        }

        private DataRow FindRow(int id)
        {
            string filter = string.Format("Id = {0}", id);
            DataRow[] results = table.Select(filter);
            if (results.Length == 0)
                return null;
            else return results[0];
        }

        protected abstract DomainObject CreateDomainObject();

        protected virtual void Load(DomainObject obj, DataRow row)
        {
            obj.ID = (int)row["Id"];
        }

        // Identity Map'e Ekle.
        protected void AddIndentityMap(int Id, DomainObject Entity)
        {
            if (!loadedMap.ContainsKey(Id))
                loadedMap.Add(Id, Entity);
        }
    }
}