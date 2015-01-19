using RemoteFacade.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteFacade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            List<ProductDTO>  products = client.GetProducts().ToList();
            listBox1.DisplayMember = "ProductName";
            listBox1.ValueMember = "ProductId";
            listBox1.DataSource = products;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDTO product = (ProductDTO)listBox1.SelectedItem;
            label1.Text = "Product ID : " + product.ProductId;
            label2.Text = "Product Name : " + product.ProductName;
            label3.Text = "Category Id : " + product.ProductCategoryId;
            label4.Text = "Category Name : " + product.ProductCategoryName;
        }
    }
}
