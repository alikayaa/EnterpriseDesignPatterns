using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleTableInheritance
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
            Form1 _form = new Form1();
            UserMapper _mapper = new UserMapper();
            User _user = _mapper.Find(1);
            if (_user.isAdmin)
                _form.Text = _user.Title;
            else
                _form.Text = "Hoşgeldiniz.";
            
            Application.Run(_form);
        }
    }
}
