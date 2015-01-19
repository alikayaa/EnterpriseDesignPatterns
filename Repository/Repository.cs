using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    // Generic Repository
    public class Repository<T> where T : class
    {
        internal List<T> data = new List<T>();

        public Repository(List<T> data)
        {
            this.data = data;
        }

        public virtual List<T> TumunuGetir()
        {
            return data;
        }

        public virtual void Sil(T Entity)
        {
            data.Remove(Entity);
        }

        public virtual void Ekle(T Entity)
        {
            data.Add(Entity);
        }

        public virtual List<T> KriterlereGoreGetir(Func<T, bool> predicate)
        {
            return data.Where(predicate).ToList();
        }
    }
}
