using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    public interface IRepository<T>
    {
        T FindById(int id);
        List<T> GetAll();
        T Add(T item);
        T Update(T item, int id);
        void Delete(int id);

    }
}
