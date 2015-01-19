using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MVCTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            //View, model ve Controller sınıflarını kendimiz oluşturuyoruz.
            //Daha sonra da view' imizi Application.Run metodunu kullanarak başlatıyoruz.
            IView view = new Form1();
            IModel mdl = new SayiIslemModel();
            IController cnt = new SayiIslemController(view,mdl);
            Application.Run((Form)view);
        }
    }
}
