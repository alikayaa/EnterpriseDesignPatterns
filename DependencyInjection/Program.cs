using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager logManager = new LogManager(new DBLogger());//birinci teknik
            logManager.LogAt("Birinci yöntem DI");

            logManager.Logger = new EmailLogger(); //ikinci teknik
            logManager.LogAt("İkinci yöntem DI");

            logManager.SetLogger(new FileLogger()); //üçüncü teknik
            logManager.LogAt("Üçüncü yöntem DI");

            Console.ReadLine();

        }
    }
}
