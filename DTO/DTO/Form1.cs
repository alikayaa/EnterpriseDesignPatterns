using DTO.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validation;

namespace DTO
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
            List<ProductDTO> products = client.GetProducts().ToList();
            List<ProductDTO> validProducts = new List<ProductDTO>();
            ValidationManager validation = new ValidationManager();
            foreach (ProductDTO pr in products)
            {
                if (validation.IsValid<ProductDTO>(pr))
                    validProducts.Add(pr);
            }
            listBox1.DisplayMember = "ProductName";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = validProducts;
        }
    }
}
