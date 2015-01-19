using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCTest
{
    //View' daki değişikliklerden modelimizin de haberdar olması için
    // Gerekli eventi temsil eden delegate sınıfımız.
    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

    //değişen değerin son halini görmemiz için EventArgs sınıfından türeyen 
    //kendi eventimiz bu örnekte değişen tek bir tane değerimiz olduğu için 
    //tek bir değerin değişikliğiyle ilgileniyoruz.
    public class ViewEventArgs: EventArgs 
    {
        public int value;
        public ViewEventArgs(int v) { value = v; }
    }

    //her view sınıfının bağlı olduğu controller sınıfını set edebilmesi için
    //bir adet setController metodu olması gerekmektedir.
    //aynı şekilde view değiştiği zaman kendi tarafından invoke edilmesi gereken
    //changed delegate'i bulunmalıdır. Bu delege invoke edilmeye çalışıldığı 
    //zaman kendisinin temsil ettiği metod çalışacaktır. Bu metod' da view' in 
    //kendi controllerı içerisinde bulunmmaktadır ve model' de de gerekli değişikliğin
    //yapılmasını sağlar.
    public interface IView
    {
        event ViewHandler<IView> changed;
        void setController(IController cont);
    }
}
