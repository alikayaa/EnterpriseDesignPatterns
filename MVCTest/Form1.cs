using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MVCTest
{
    //Form sınıfımız aslında bizim view' imizdir. IView' den türemiştir. Aynı zamanda
    //IModelObserver arayüzünden de türeyerek kendisine ait model sınıfının 
    //değişimlerini takip etmektedir.
    public partial class Form1 : Form, IView, IModelObserver
    {
        //View ımız içerisinde Controller bulunmalıdır. Yani kendi controllerını 
        //tanımalıdır.
        IController controller;
        //gerekli değişiklik durumunda invoke edilecek olan delege sınıfmız.
        public event ViewHandler<IView> changed;


        // View burada kendi controller sınıfını dependency injection la 
        //dışarıdan alıyor.
        public void setController(IController cont)
        {
            controller = cont;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        //kullanıcı sayıyı arttır tuşuna bastığı anda controller sınıfının sayıyıArttir metodu
        //çalıştırılır. Başka da hiçbir şey yapılmaz geri kalan işlemler halledilir.
        private void button1_Click(object sender, EventArgs e)
        {
            controller.SayiyiArttir();
        }

        //kullanıcı sayıyı azalt tuşuna bastığı anda controller sınıfının SayiyiAzalt metodu
        //çalıştırılır. Başka da hiçbir şey yapılmaz geri kalan işlemler halledilir.
        private void button2_Click(object sender, EventArgs e)
        {
            controller.SayiyiAzalt();
        }

        //Bu event IModelObserver arayüzünün gerçeklenmesidir. 
        //Model' deki veri değiştiğinde bu event yakalanmış olur. 
        public void sayiyiArttir(IModel m, ModelEventArgs e)
        {
            textBox1.Text = "" + e.newval;
        }

        public void sayiyiAzalt(IModel model, ModelEventArgs e)
        {
            textBox1.Text = "" + e.newval;
        }


        //bu metod çalışması demek kullanıcının textBox' daki değeri değiştirmesi demektir.
        //View' e ait olan changed delegesi invoke edilerek çağırılır. Controllerda sınıfı 
        //aracılığıyla, model sınıfı bu evente abone olmuştur.
        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                changed.Invoke(this, new ViewEventArgs(int.Parse(textBox1.Text)));
            }
            catch (Exception)
            {
                MessageBox.Show("Gerçerli bir sayı giriniz");
            }
        }
    }
}
