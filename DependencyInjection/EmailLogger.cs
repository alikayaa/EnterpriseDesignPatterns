using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    public class EmailLogger:ILogger
    {
        public void LogAt(string text)
        {
            Console.WriteLine("-'" + text + "' değeri email atıldı.");
        }
    }
}
