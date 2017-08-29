using System.Collections.Generic;
using System.Linq;
using BookApi.Models;

namespace BookApi.Repository
{
    public class Repository<T> : IRepository<T> where T : Item
    {
        internal List<T> _items = new List<T>();
        public List<T> All()
        {
            return _items;
        }

        public T Find(int id)
        {
            return _items.FirstOrDefault(p => p.Id == id);
        }

        public void Create(T item)
        {
            _items.Add(item);
        }

        public void Update(int id, T item)
        {
            var index = _items.FindIndex(p => p.Id == id);
            _items[index] = item;
        }

        public void Remove(int id)
        {
            _items.RemoveAll(item => item.Id == id);
        }
    }
}
