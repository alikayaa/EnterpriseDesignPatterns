using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    //bütün mapper metodlarımızı aynı interface den türetiyoruz.
    public interface IDataMapper<T>
    {
        int Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
