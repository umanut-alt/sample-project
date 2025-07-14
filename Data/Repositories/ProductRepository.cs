using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Data.Repositories
{
    [AutoRegister]
    //public class ProductRepository : IProductRepository
    //{
    //    private static readonly List<Product> _products = new List<Product>();

    //    public void Save(Product product)
    //    {
    //        InMemoryRepository.Save(product);
    //    }

    //    public void Update(Product updated)
    //    {
    //        var product = InMemoryRepository.Get(updated.Id); ;
    //        if (product == null) return;
    //        InMemoryRepository.Update(product.Id, updated);
    //    }
    //    public void Delete(Product product)
    //    {
    //        InMemoryRepository.Delete(product);
    //    }

    //    public Product Get(int id)
    //    {
    //        if(id <= 0) return null;
    //        return InMemoryRepository.Get(id);
    //    }

    //    public void DeleteAll()
    //    {
    //        InMemoryRepository.DeleteAll();
    //    }

    //    public IEnumerable<Product> Get(string searchString = null)
    //    {
    //        return InMemoryRepository.GetAll(searchString);
    //    }
    //}
    public class ProductRepositoy : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();
        private InMemoryStorage<Product> _inMemoryStorage = new InMemoryStorage<Product>();
        public Product Get(Func<Product, bool> predicate)
        {
            return _inMemoryStorage.Get(predicate);
        }
        public Product Get(int id)
        {
            return _inMemoryStorage.Get(x => x.Id == id);
        }
        public Product Get(string name)
        {
            return _inMemoryStorage.Get(x => x.Name == name);
        }
        public IEnumerable<Product> GetAll()
        { return _inMemoryStorage.GetAll(); }
        public Product Create(Product product)
        {
            product.Id = _inMemoryStorage.GetAll().Count() + 1;
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            return _inMemoryStorage.Create(product);
        }
        public Product Update(Product updated)
        {
            var product = _inMemoryStorage.Get(x => x.Id == updated.Id);
            if (product != null)
            {
                var updatedProduct = _inMemoryStorage.Update(
                 p => p.Id == updated.Id,
                 p => {
                     p.Name = updated.Name;
                     p.Price = updated.Price;
                 });
            }
            return product;
        }
        public void Delete(int id)
        {
            _inMemoryStorage.Delete(x => x.Id == id);
        }
        public void DeleteAll()
        {
            _inMemoryStorage.DeleteAll();
        }
        public IEnumerable<Product> Get()
        {
            return _inMemoryStorage.GetAll();
        }
        public Product Update(Func<Product, bool> predicate, Action<Product> updateAction)
        {

            var item = _products.FirstOrDefault(predicate);
            if (item != null)
            {
                updateAction(item);
            }
            return item;
        }
        public void Delete(Func<Product, bool> predicate)
        {
            _inMemoryStorage.Delete(predicate);
        }
    }
}
