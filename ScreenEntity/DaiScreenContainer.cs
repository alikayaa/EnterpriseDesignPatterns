using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Serialization;

namespace ScreenEntity
{
    //bu sınıfımızda gelen xml path değerine göre ilgili
    //dosya okunur DaiForm nesnesine convert edilir.
    //ve xml'in nesneye çevirilmiş hali geriye dönülür.
    public class DaiScreenContainer
    {
        public static DaiForm Get(string xmlPath)
        {
            XmlDocument xDocument = new XmlDocument();
            xDocument.Load(xmlPath);

            return SerializationHelper.DeserializeObject<DaiForm>(xDocument.OuterXml);
        }
    }
}
