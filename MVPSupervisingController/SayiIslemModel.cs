using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPSupervisingController
{
    public class SayiIslemModel : IModel
    {
        public event ModelHandler<SayiIslemModel> changed;
        int value;

        // model' de saklanan veri ilk aşamada 0' a atanıyor.
        public SayiIslemModel()
        {
            value = 0;
        }

        //modeldeki verinin değişebilmesine olanak sağlayan metod
        public void setvalue(int v)
        {
            value = v;
        }

        //IModelObserver arayüzünü implemete eden view sınıflarımız modelimize
        //abone olabilir.  Böylece, değer değiştiğinde hepsi notify edilebilir.
        public void AboneOl(IModelObserver imo)
        {
            changed += new ModelHandler<SayiIslemModel>(imo.sayiyiArttir);
        }

        //burada değer arttırma işlemi geldiği anda değer arttırılmalı ve değerin son hali
        //view tarafından da güncellenmesi için abone olan bütün view' ler güncellenmelidir.
        public void sayiyiArttir()
        {
            value++;
            changed.Invoke(this, new ModelEventArgs(value));
        }

        //burada değer azaltma işlemi geldiği anda değer azaltılmalı ve değerin son hali
        //view tarafından da güncellenmesi için abone olan bütün view' ler güncellenmelidir.
        public void sayiyiAzalt()
        {
            value--;
            changed.Invoke(this, new ModelEventArgs(value));
        }
    }
}
