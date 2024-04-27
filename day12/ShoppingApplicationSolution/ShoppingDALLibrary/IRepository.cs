using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepository<K, T>
    {
        Task<T> Add(T item);
        Task<ICollection<T>> GetAll();
        Task<T> GetByKey(K key);
        Task<T> Update(T item);
        Task<T> Delete(K key);
    }
}
