using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registry
{
    //bir registery sınıf yazılarak bu konfigürasyon değerleri
    //bir Hashtable içerisinde tutulur ve bu şekilde erişilir.
    public class Registry
    {
        protected Hashtable registry = null;
        protected static Registry instance = null;

        private Registry()
        {
            registry = new Hashtable();
        }

        public static void addToRegistry(Object key, Object value)
        {
            if (instance == null)
            {
                instance = new Registry();
            }
            instance.registry.Add(key, value);
        }

        public static Object getFromRegistry(Object key)
        {
            if (instance == null)
            {
                instance = new Registry();
            }
            return instance.registry[key];
        }

    }
}
