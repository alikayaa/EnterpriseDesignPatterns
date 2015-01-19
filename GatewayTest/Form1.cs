using Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GatewayTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                GatewayCustomer gateway = new GatewayCustomer();
                long tcNo = long.Parse(txtTcNo.Text);
                Customer c = gateway.GetCustomerByTcNo(tcNo);
                MessageBox.Show(c.ToString());
            }
            catch
            {
                MessageBox.Show("TC kimlik no hatalıdır.");
            }
            
            
        }
    }
}
