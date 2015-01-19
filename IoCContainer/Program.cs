using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            IocContainer container = new IocContainer();
            container.Olustur<ILogger>(()=>new FileLogger());

            container.GeriDon<ILogger>().LogAt("deneme");


            IocContainer container2 = new IocContainer();
            container2.Olustur<ILogger>(() => new EmailLogger());

            container2.GeriDon<ILogger>().LogAt("deneme2");
            Console.ReadLine();

        }
    }
}
