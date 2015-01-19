using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenEntity
{
    //kendi kontrollerimizi oluştururken DaiControlBase kontrol sınıfından
    //türetiriz. Yeni yeni kontroller oluşturabiliriz.
    //her bir kontrolün gerçek tiplere dönüştürüleceği builder nesnelerini
    //tanımlamamız gerekmektedir.
    [Serializable]
    public class DaiTextBox:DaiControlBase
    {
    }
}
