using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerializedBlob
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
            PageMapper _mapper = new PageMapper();
            Page _page = _mapper.Find(2);
            InterpreterHelper _helper = new InterpreterHelper();
            Application.Run(_helper.GenerateScreen(_page.XML));
        }
    }
}
