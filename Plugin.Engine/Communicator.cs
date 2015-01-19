using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Engine
{
    /// <summary>
    /// Plug-in'lerimizi serialize hale getirecek class'ımız.
    /// </summary>
    public class Communicator : MarshalByRefObject, ICommand
    {
        /// <summary>
        /// Command türündeki gerçek nesnemiz.
        /// </summary>
        private ICommand command;
        public Communicator(ICommand command)
        {
            this.command = command;
        }
        /// <summary>
        /// Hesaplama fonksiyon adı
        /// </summary>
        public string Name { get { return this.command.Name; } }
        
        /// <summary>
        /// 2 argümanlı hesaplama fonksiyonumuz için execute edecek metotumuz
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public double Execute(double arg1, double arg2)
        {
            return this.command.Execute(arg1, arg2);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
