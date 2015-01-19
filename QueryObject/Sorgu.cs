using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryObject
{
    public class Sorgu
    {
        // Kriter listesi
        private List<Kriter> kriterler = new List<Kriter>();
        // Yapıcı metod
        public Sorgu(List<Kriter> kriterler)
        {
            this.kriterler = kriterler;
        }
        // Where Sql çıktı oluşturucu
        public string WhereKosuluOlustur()
        {
            StringBuilder whereSql = new StringBuilder();
            whereSql.Append("WHERE ");
            int i = 0;
            foreach (Kriter kriter in kriterler)
            {
                whereSql.Append(kriter.SqlOlustur());
                if (i++ != kriterler.Count - 1)
                    whereSql.Append(" AND ");

            }
            return whereSql.ToString();
        }
    }
}
