using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Interfaces
{
    /// <summary>
    /// Hesap makinemiz için plug-in tabanlı olarak geliştireceğimiz 
    /// hesaplama fonksiyonlarımız için ApplicationDomain'ler arası contract'ımız.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Hesaplama fonksiyon adı
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 2 argümanlı hesaplama fonksiyonumuz için execute edecek metotumuz
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        double Execute(double arg1, double arg2);
    }
}
