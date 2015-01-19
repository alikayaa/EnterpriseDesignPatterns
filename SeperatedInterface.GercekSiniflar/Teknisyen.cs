using SeperatedInterface.Arayuz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeperatedInterface.GercekSiniflar
{
    public class Teknisyen:IPersonel
    {
        public int PersonelMaasiHesapla()
        {
            //burada teknisyen maaşını hesaplanması algoritması hesaplanıyor
            return 50;
        }
    }
}
