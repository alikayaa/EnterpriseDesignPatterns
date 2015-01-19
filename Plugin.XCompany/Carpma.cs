using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.XCompany
{
    public class Carpma:ICommand
    {
        public string Name
        {
            get { return "Çarpma İşlemi"; }
        }

        public double Execute(double arg1, double arg2)
        {
            return arg1 * arg2;
        }
    }
}
