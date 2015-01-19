using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPSupervisingController
{
    //View' daki değişikliklerden modelimizin de haberdar olması için
    // Gerekli eventi temsil eden delegate sınıfımız.
    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

    //değişen değerin son halini görmemiz için EventArgs sınıfından türeyen 
    //kendi eventimiz bu örnekte değişen tek bir tane değerimiz olduğu için 
    //tek bir değerin değişikliğiyle ilgileniyoruz.
    public class ViewEventArgs : EventArgs
    {
        public int value;
        public ViewEventArgs(int v) { value = v; }
    }

    public interface IView
    {
        event ViewHandler<IView> changed;
    }
}
