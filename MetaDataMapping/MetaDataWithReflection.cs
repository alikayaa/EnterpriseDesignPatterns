using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataMapping
{
    public class MetaDataWithReflection
    {
        // Mapping
        public void Map(DomainObject domainObject)
        {
            // Domain Object'ler özellikleri
            // Domain Object üzerindeki tüm property'ler çekilir.
            string metaDataString = string.Empty;
            Type entityType = domainObject.GetType();
            foreach (var property in entityType.GetProperties())
            {
                var metaData = property.GetCustomAttributes(typeof(MetaDataAttr), false).FirstOrDefault();
                Console.WriteLine("Veri tabanı Mapper Alan Adı : {0} - Nesne Üzerindeki Adı : {1}",((MetaDataAttr)metaData).ColumnName,property.Name);
            }
            
        }
    }
}
