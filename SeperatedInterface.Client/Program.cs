using SeperatedInterface.Application;
using SeperatedInterface.Arayuz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeperatedInterface.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonelFactory factory=new PersonelFactory();

            foreach (PersonelEnum item in Enum.GetValues(typeof(PersonelEnum)))
            {
                IPersonel personel = factory.GetPersonel(item);
                Console.Write(item.ToString() + ": ");
                Console.Write(personel.PersonelMaasiHesapla().ToString());
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
