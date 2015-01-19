using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repository
{
    public partial class Form1 : Form
    {
        public Repository<Kisi> repo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.RehberYukle();   
        }

        private List<Kisi> RehberKisileriYukle()
        {
            List<Kisi> Rehber = new List<Kisi>();
            Rehber.Add(new Kisi() { Id=1,KisiAdi="Ali",TelNo="533 333 33 33" });
            Rehber.Add(new Kisi() { Id=2,KisiAdi="Engin",TelNo="555 555 55 55"});
            Rehber.Add(new Kisi() { Id = 3, KisiAdi = "Selim", TelNo = "544 444 44 44" });
            return Rehber;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kisi kisi = new Kisi();
            kisi.KisiAdi = textBox1.Text;
            kisi.TelNo = textBox2.Text;
            repo.Ekle(kisi);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            this.RehberYukle();
            MessageBox.Show("Kişi Eklendi.");
        }

        private void RehberYukle()
        {
            repo = repo == null ? new Repository<Kisi>(this.RehberKisileriYukle()):repo;
            listBox1.DataSource = null;
            listBox1.DisplayMember = "KisiAdi";
            listBox1.DataSource = repo.TumunuGetir();
        }

    }
}
