using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IInMemoryStorage<T>
    {
        T Get(Func<T, bool> predicate);
        T Create(T entity);
        void Delete(Func<T, bool> predicate);
        void DeleteAll();

    }
}
