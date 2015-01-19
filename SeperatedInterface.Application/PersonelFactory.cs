using SeperatedInterface.Arayuz;
using SeperatedInterface.GercekSiniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SeperatedInterface.Application
{
    public class PersonelFactory
    {
        public IPersonel GetPersonel(PersonelEnum personeltipi)
        {
            switch (personeltipi)
            {
                case PersonelEnum.Yonetici:
                    return new Yonetici();
                case PersonelEnum.Muhendis:
                    return new Muhendis();
                case PersonelEnum.Teknisyen:
                    return new Teknisyen();
                default:
                    throw new Exception("Ssitem belirtilen tipi bulamadı");
                    break;
            }
        }
    }
}
