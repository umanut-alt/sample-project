using BusinessEntities;
using System.Collections.Generic;


namespace Data.Repositories
{
    //public interface IProductRepository : IInMemoryRepository<Product>
    //{
    //    Product Get(int id);
    //    IEnumerable<Product> Get(string searchString = null);
    //    void DeleteAll();
    //}

    public interface IProductRepository : IInMemoryStorage<Product>
    {
        Product Get(int id);
        Product Get(string name);
        IEnumerable<Product> GetAll();
        Product Update(Product product);
    }
}
