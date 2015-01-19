using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SerializedBlob
{
    public class Page:DomainObject
    {
        private XmlDocument _xml;
        private string _xmlString;
        public Page(int Id):base(Id)
        {

        }

        public XmlDocument XML
        {
            get { return this._xml; }
        }

        public string XmlString
        {
            get { return this._xmlString; }
            set { this._xmlString = value; }
        }

        public void toXml()
        {
            _xml = new XmlDocument();
            _xml.LoadXml(this._xmlString);
        }
    }
}
