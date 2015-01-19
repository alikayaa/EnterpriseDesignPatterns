using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForeignKeyMapping
{
    public class MapperRegistry
    {
        public static AbstractMapper Mapper(Type type)
        {
            return (AbstractMapper)Activator.CreateInstance(type);
        }
    }
}