using SeperatedInterface.Arayuz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeperatedInterface.GercekSiniflar
{
    public class Muhendis:IPersonel
    {
        public int PersonelMaasiHesapla()
        {
            //burada mühendis maaşının hesaplanması algoritması bulunuyor.
            return 100;
        }
    }
}
