using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainObject domainObject = new DomainObject();
            MetaDataWithReflection metaDataMapper = new MetaDataWithReflection();
            metaDataMapper.Map(domainObject);

            Console.Read();
        }
    }
}
