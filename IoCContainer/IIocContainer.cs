using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCContainer
{
    public interface IIocContainer
    {
        T GeriDon<T>();
        void Olustur<T>(Func<object> action);
    }
}
