using Plugin.Interfaces;
using Plugin.Starter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.ApplicationWinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // PlugInDomain plug-inlerimizi ilgili application domain'de
            //instance'larını üretip bize geriye dönüyor.
            List<ICommand> cmdList = PlugInDomain.Start();
            //bizde bunları listBox' a ekliyoruz.
            lstCommands.Items.AddRange(cmdList.ToArray());
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (lstCommands.SelectedItem != null)
            {
                var cmd = lstCommands.SelectedItem as ICommand;
                var arg1 = Convert.ToDouble(txtSayi1.Text);
                var arg2 = Convert.ToDouble(txtSayi2.Text);
                var result = cmd.Execute(arg1, arg2);

                MessageBox.Show(string.Format("Sonuç: {0}", result));
            }
        }
    }
}
