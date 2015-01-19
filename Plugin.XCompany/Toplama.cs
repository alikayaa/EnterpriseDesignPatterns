using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.XCompany
{
    public class Toplama:ICommand
    {
        public string Name
        {
            get { return "Toplama İşlemi"; }
        }

        public double Execute(double arg1, double arg2)
        {
            return arg1 + arg2;
        }
    }
}
