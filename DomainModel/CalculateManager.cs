using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel
{
    // Hesaplama yöneticisi
    public class CalculateManager
    {
        // Hesaplama ara yüzü
        private ICalculate _calculater;
        // Hesapla
        public int CalculateSummary(Calisan calisan)
        {
            // Çalışan yönetici ise yöneticiye göre hesapla
            if (calisan.isDirector)
            {
                _calculater = new DirectorCalculater();
            }
            // Normal çalışana göre hesapla
            else
            {
                _calculater = new PersonCalculater();
            }
            // Hesaplanan maaşı geri dön
            return _calculater.Calculate(calisan.Sallery);
        }
    }
}