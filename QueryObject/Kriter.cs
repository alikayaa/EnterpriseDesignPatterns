using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryObject
{
    public class Kriter
    {
        // Sql Operatörü
        private string SqlOperator;
        // Tablo üzerindeki Alan Adı
        private string AlanAdi;
        // Değer
        private string Deger;

        // Yapıcı Metod
        public Kriter(string SqlOp, string Alan, string Deger)
        {
            this.SqlOperator = SqlOp;
            this.AlanAdi = Alan;
            this.Deger = Deger;
        }

        // Kayıtların bir alan üzerindeki Belirli bir değerden büyük olmasını sağlayacak kriter
        public static Kriter BelirliBirDegerdenBuyuk(string Alan, string Deger)
        {
            return new Kriter(">", Alan, Deger);
        }
        // Kayıtların bir alan üzeriden ki değere eşit olmasını sağlayacak kriter
        public static Kriter DegerineEsit(string Alan, string Deger)
        {
            return new Kriter("=", Alan, Deger);
        }
        // Kriter'in sql'e çevrilmesi
        public string SqlOlustur()
        {
            return this.AlanAdi + " " + this.SqlOperator + " " + this.Deger;
        }
    }

}

