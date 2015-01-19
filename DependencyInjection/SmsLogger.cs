using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    public class SmsLogger:ILogger
    {
        public void LogAt(string text)
        {
            Console.WriteLine("-'" + text + "' değeri sms atıldı.");
        }
    }
}
