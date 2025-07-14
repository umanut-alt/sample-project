using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepositoy : IOrderRepository
    {
        private InMemoryStorage<Order> _inMemoryStorage = new InMemoryStorage<Order>();
        public Order Get(Func<Order, bool> predicate)
        {
            return _inMemoryStorage.Get(predicate);
        }
        public Order Get(int id)
        {
            return _inMemoryStorage.Get(x => x.Id == id);
        }
        public Order Get(string name)
        {
            return _inMemoryStorage.Get(x=>x.Name == name);
        }
        public IEnumerable<Order> GetAll()
        { return _inMemoryStorage.GetAll(); }
        public Order Create(Order order)
        {
            order.Id = _inMemoryStorage.GetAll().Count() + 1;
            if (order == null) {
                throw new ArgumentNullException(nameof(order));
            }
            return _inMemoryStorage.Create(order);

        }
        public Order Update(Order updated)
        {
            var order = _inMemoryStorage.Get(x => x.Id == updated.Id);
            if (order != null)
            {
                var updatedProduct = _inMemoryStorage.Update(
                 p => p.Id == updated.Id,
                 p => {
                     p.Name = updated.Name;
                     p.TotalAmount = updated.TotalAmount;
                     p.OrderDate = updated.OrderDate;
                     p.ProductIds = updated.ProductIds;
                 });
            }
            return order;
        }
        public void DeleteAll()
        {
            _inMemoryStorage.DeleteAll();
        }
        public IEnumerable<Order> Get()
        {
            return _inMemoryStorage.GetAll();
        }
        public void Delete(Func<Order, bool> predicate)
        {
            _inMemoryStorage.Delete(predicate);
        }
    }
}
