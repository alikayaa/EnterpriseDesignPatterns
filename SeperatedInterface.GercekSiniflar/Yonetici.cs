using SeperatedInterface.Arayuz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeperatedInterface.GercekSiniflar
{
    public class Yonetici:IPersonel
    {
        public int PersonelMaasiHesapla()
        {
            //burada yönetici maaşı hesaplanıyor
            return 150;
        }
    }
}
