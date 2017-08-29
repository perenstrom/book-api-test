using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Repository
{
    public interface IRepository<T>
    {
        List<T> All();
        T Find(int id);
        void Create(T item);
        void Update(int id, T item);
        void Remove(int id);
    }
}
