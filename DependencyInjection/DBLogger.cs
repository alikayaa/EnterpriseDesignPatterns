using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    public class DBLogger:ILogger
    {
        public void LogAt(string text)
        {
            Console.WriteLine("-'"+text+"' değeri veri tabanına loglandı.");
        }
    }
}
