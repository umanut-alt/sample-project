using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductData 
    {
        public ProductData(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = (decimal)product.Price;
        }
        public int Id {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}