using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCase
{
    class Program
    {
        static void Main(string[] args)
        {
            UnknownCustomer unknownCustomer = new UnknownCustomer();

            //bizim customer nesnesiyle iş yapan metodumuz olacaktır. Ama bu metodun içerisinde 
            //null kontrolü yapılmak istenmiyor. Böyle bir durumda Customer istenen parametreye
            //UnknownCustomer objesini de gönderebiliriz. Böylelikle uygulamada ekstradan 
            //kontrol yapmak zorunda kalmayız.
            Customer c = (UnknownCustomer)unknownCustomer;

            Console.WriteLine(c.ToString());
            Console.ReadLine();


        }
    }
}
