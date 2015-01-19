using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataMapping
{
    public class DomainObject
    {
        [MetaDataAttr("DbId")]
        public int Id { get; set; }
        [MetaDataAttr("DbName")]
        public string Name { get; set; }
    }
}
