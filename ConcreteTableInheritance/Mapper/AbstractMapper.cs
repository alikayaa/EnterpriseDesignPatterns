using ConcreteTableInheritance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConcreteTableInheritance.Mapper
{
    public abstract class AbstractMapper:Mapper
    {
        public AbstractMapper(Gateway gateway):base(gateway)
        {

        }

        // Genel Arama
        public DomainObject AbstractFind(int Id)
        {
            DataRow row = FindRow(Id);
            if (row == null) return null;
            else
            {
                DomainObject result = CreateDomainObject();
                // Identity Map içerisinde bulursan geri döndür.
                if (loadedMap.ContainsKey(Id))
                {
                    result = loadedMap[Id];
                    return result;
                }
                AddIndentityMap(result.ID, result);
                Load(result, row); return result;
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

        protected override void Load(DomainObject obj, DataRow row)
        {
            base.Load(obj, row);
            Category category = (Category)obj;
            category.Adi = row["Adi"].ToString();
        }

        public override string TableName
        {
            get { return "Kategori"; }
        }
        

    }
}