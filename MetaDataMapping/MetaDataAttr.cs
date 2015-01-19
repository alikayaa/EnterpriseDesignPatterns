using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataMapping
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class MetaDataAttr:Attribute
    {
        public string ColumnName { get; set; }
        public MetaDataAttr()
        {

        }

        public MetaDataAttr(string ColumnName)
        {
            this.ColumnName = ColumnName;
        }
    }
}
