using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVPPassiveView
{
    public partial class Form1 : Form,IView
    {
        private SayiIslemPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new SayiIslemPresenter(new SayiIslemModel(), this);
        }

        public event ViewHandler<IView> changed;

        public void ChangeValue(int val)
        {
            textBox1.Text = val.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.presenter.SayiyiArttir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.presenter.SayiyiAzalt();
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
