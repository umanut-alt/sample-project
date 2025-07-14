using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class InMemoryStorage<T> : IInMemoryStorage<T> where T : class
    {
        public static InMemoryStorage<T> _inMemoryStorage;
        private static readonly List<T> _entities = new List<T>();
        public IEnumerable<T> GetAll() => _entities;
        public T Get(Func<T, bool> predicate) => _entities.FirstOrDefault(predicate);
        public T Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);
            return entity;
        }
        public T Update(Func<T, bool> predicate, Action<T> updateAction)
        {
            var entity = _entities.FirstOrDefault(predicate);
            if (entity != null)
            {
                updateAction(entity);
            }
            return entity;
        }
        public void Delete(Func<T, bool> predicate)
        {
            var entity = _entities.FirstOrDefault(predicate);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }
        public void DeleteAll()
            { _entities.Clear(); }
        public bool Exists(Func<T, bool> predicate) => _entities.Any(predicate);

    }
}
