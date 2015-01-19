using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCTest
{
    //Modelimizdeki değişikliklerden view' imizin de haberdar olması için
    //gerekli eventi temsil eden delegemiz.
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);

    //değişen değerin son halini görmemiz için EventArgs sınıfından türeyen 
    //kendi eventimiz bu örnekte değişen tek bir tane değerimiz olduğu için 
    //tek bir değerin değişikliğiyle ilgileniyoruz.
    public class ModelEventArgs : EventArgs
    {
        public int newval;
        public ModelEventArgs(int v) 
        { 
            newval = v; 
        }
    }

    //view' ımızın gerçeklemesini zorunlu kılacağımız arayüzümüz.
    //Bu, model değiştiği zaman fırlatılacak olan evente bakan metodumuz.
    //Bu sınıf doğrudan IView ara yüzünde de bulunabilirdi. Ancak liskov' un arayüz ayrım 
    //presibi gereği bunu ayırdık. Her view de aynı değer arttırma işlemi bulunmayabilir.
    public interface IModelObserver
    {
        void sayiyiArttir(IModel model, ModelEventArgs e);
        void sayiyiAzalt(IModel model, ModelEventArgs e);
    }

    //IModel arayüzümüzde model değiştiğinde uyarılması adına bir attach sınıfımız vardır.
    //Setvalue metodu ise kullanıcının, view' den değiştirdiği değerin model' de de 
    //değiştirilmesi gerekli olan metod.
    public interface IModel
    {
        void AboneOl(IModelObserver imo);
        void sayiyiArttir();
        void sayiyiAzalt();
        void setvalue(int v);
    }
}
