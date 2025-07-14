using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IInMemoryStorage<Order>
    {
        Order Get(int id);
        Order Get(string name);
        IEnumerable<Order> GetAll();
        Order Update(Order order);
    }
}
