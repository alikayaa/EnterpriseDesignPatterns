using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCContainer
{
    public class IocContainer:IIocContainer
    {
        private static readonly Dictionary<Type, Func<object>> list = new Dictionary<Type, Func<object>>();

        public T GeriDon<T>()
        {
            return (T)list[typeof(T)]();
        }

        public void Olustur<T>(Func<object> action)
        {
            if (list.ContainsKey(typeof(T)))//varsa sil yeniden oluştur.
                list.Remove(typeof(T));
            list.Add(typeof(T), action);
        }
    }
}
