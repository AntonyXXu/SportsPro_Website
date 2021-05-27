using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Models
{
    // Repository interface to add, upate, delete, save changes in the database
    // Used for individual tables
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> List(QueryOptions<T> options);

        int Count { get; }

        // overloaded Get() method
        T Get(QueryOptions<T> options);
        T Get(int id);
        T Get(string id);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Save();
    }
}
