using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public abstract class AbstractMapper
    {
        // Identity Map
        private Dictionary<int, DomainObject> loadedMap = new Dictionary<int, DomainObject>();
        // Her entity yüklenmesi alt sınıflarda kendisine göre özel olarak yaptırılır
        abstract protected void LoadEntity(DomainObject domainObject, DataRow row);
        // Her entity'nin dolduracağı tablo ismi
        abstract protected String TableName { get; }
        // Her entity'nin oluşturacağı Domain Objesi
        abstract protected DomainObject CreateDomainObject();


        // Genel Arama
        protected DomainObject AbstractFind(int Id)
        {
            DomainObject result = null;
            // Identity Map içerisinde bulursan geri döndür.
            if (loadedMap.ContainsKey(Id))
                result = loadedMap[Id];

            if (result != null) return result;
            DataRow row = FindRow(Id);
            if(row!= null) 
                return Load(row);
            else
                return null;
        }
        // Satır Yükleme
        protected DomainObject Load(DataRow row)
        {
            DomainObject result = null;
            int Id = (int)row["Id"];
            if (loadedMap.ContainsKey(Id)) return (DomainObject)loadedMap[Id];
            else
            {
                result = CreateDomainObject();
                result.ID = Id;
                AddIndentityMap(Id, result); ;
                LoadEntity(result, row);
                return result;
            }

            return result;

        }
        // Identity Map'e Ekle.
        protected void AddIndentityMap(int Id, DomainObject Entity)
        {
            if (!loadedMap.ContainsKey(Id))
                loadedMap.Add(Id, Entity);
        }
        // Satır Arama
        protected DataRow FindRow(int id)
        {
            String filter = String.Format("Id = {0}", id);
            DataRow[] results = table.Select(filter);
            return (results.Length == 0) ? null : results[0];
        }

        protected DataTable table
        {
            get { return dsh.Data.Tables[TableName]; }
        }
        public DataSetHolder dsh = new DataSetHolder();
        
    }
}