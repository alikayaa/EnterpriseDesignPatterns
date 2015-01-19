using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCTest
{
    public class SayiIslemController:IController
    {
        IView view;
        IModel model;
        // IController arayüzünden türeyen controller sınıfımız kendi içerisinde
        // model ve view nesnelerinden birer referans bulundurur.
        //Yapıcı metpdun içerisinde gerçek örnekler dışarıdan alınır. 
        //Dışarıdan alınan örneğe bu controller sınıfı atanır.
        //model değiştiğinde view' in tetiklenmesi için ilgili modele view abone olur.
        //view değiştiğinde modelin de değişmesi için bu defada view' ın changed eventine 
        //abone olur. Bu sayede model ve view arasındaki senkronizasyonu controller sınıfı
        //aracılığıyla sağlamış bulunuyoruz.
        public SayiIslemController(IView v, IModel m)
        {
            view = v;
            model = m;
            view.setController(this);
            model.AboneOl((IModelObserver)view);
            view.changed += new ViewHandler<IView>(this.view_changed);
        }

        //kullanıcı textbox' daki değeri değiştirdiğinde view' den fırlatılacak olan event' e
        //abone olan metodumuz. Model sınıfımızdaki değerimizi değiştiriyoruz.
        public void view_changed(IView v, ViewEventArgs e)
        {
            model.setvalue(e.value);
        }

        // This does the actual work of getting the model do the work
        //modeldeki sayıyı arttıran metod kontroller tarafından çağırılır.
        //sayı arttırıldıktan sonra modelde bir event fırlatılır. View' da bu evente 
        //abone olduğu için gerekli eventi yakalar.
        public void SayiyiArttir()
        {
            model.sayiyiArttir();
        }


        public void SayiyiAzalt()
        {
            model.sayiyiAzalt();
        }
    }
}
