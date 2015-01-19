using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVPSupervisingController
{
    public partial class Form1 : Form,IView,IModelObserver
    {
        private SayiIslemPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new SayiIslemPresenter(new SayiIslemModel(), this);
        }

        public event ViewHandler<IView> changed;

        public void sayiyiArttir(IModel model, ModelEventArgs e)
        {
            textBox1.Text = "" + e.newval;
        }

        public void sayiyiAzalt(IModel model, ModelEventArgs e)
        {
            textBox1.Text = "" + e.newval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.SayiyiArttir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presenter.SayiyiAzalt();
        }

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
