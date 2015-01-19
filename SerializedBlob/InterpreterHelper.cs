using SerializedBlob.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SerializedBlob
{
    public class InterpreterHelper
    {
        private Context _context;
        public InterpreterHelper()
        {
            this._context = new Context();
        }

        public Form GenerateScreen(XmlDocument xml)
        {
            IExpression _interpreter = null;
            string fileName = null;

            try
            {
                XmlNode _formNode = xml.SelectSingleNode("/Form");
                _context.ScreenOutputData.Text = _formNode.Attributes["Title"].Value;
                _context.ScreenOutputData.Name = _formNode.Attributes["Name"].Value;
                _context.ScreenOutputData.Size = new System.Drawing.Size(Convert.ToInt32(_formNode.Attributes["Width"].Value), Convert.ToInt32(_formNode.Attributes["Height"].Value));

                XmlNodeList xnList = xml.SelectNodes("/Form/Controls/Control");
                foreach (XmlNode _xn in xnList)
                {
                    _context.ControlInput = _xn;
                    if (_xn.Attributes["Type"].Value == "Label")
                        _interpreter = new LabelInterpreter();
                    if (_xn.Attributes["Type"].Value == "Textbox")
                        _interpreter = new TextboxInterpreter();
                    if (_xn.Attributes["Type"].Value == "Password")
                        _interpreter = new TextboxInterpreter();
                    if (_xn.Attributes["Type"].Value == "Button")
                        _interpreter = new ButtonInterpreter();

                    _interpreter.BuildControl(_context);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return this._context.ScreenOutputData;
        }
    }
}
