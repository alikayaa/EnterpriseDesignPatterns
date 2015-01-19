using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kriter listesi
            List<Kriter> kriterler = new List<Kriter>();
            // Id alanı 1 degerinden büyük olma kriteri
            Kriter kriter1 = Kriter.BelirliBirDegerdenBuyuk("Id", "1");
            // Adi alanı Ali ye eşit olma kriteri
            Kriter kriter2 = Kriter.DegerineEsit("Adi", "Ali");
            kriterler.Add(kriter1);
            kriterler.Add(kriter2);
            // Sorgulama nesnesi oluşturma
            Sorgu sorguNesnesi = new Sorgu(kriterler);
            // Sorgu çıktısını ekrana yazdırma
            Console.WriteLine(sorguNesnesi.WhereKosuluOlustur());

        }
    }
}
