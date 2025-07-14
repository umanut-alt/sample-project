using BusinessEntities;
using Core.Services.Products;
using Data.Repositories;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductController(ICreateProductService createProductService, IDeleteProductService deleteProductService, IGetProductService getProductService, IUpdateProductService updateProductService)
        {
            _createProductService = createProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        // GET api/products
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct( [FromBody] ProductModel model)
        {
            Product product = new Product { Name = model.Name, Price = model.Price };
            var Product = _createProductService.Create(product);
            return Found(new ProductData(Product));
        }

        [Route("{productId:int}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateProduct(int ProductId, [FromBody] ProductModel model)
        {
            Product product = new Product { Id = ProductId, Name = model.Name, Price = model.Price };
            var Product = _getProductService.GetProduct(product.Id);
            if (Product == null)
            {
                return DoesNotExist();
            }
            _updateProductService.Update(product);
            return Found(new ProductData(Product));
        }

        [Route("{productId:int}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int ProductId)
        {
            var Product = _getProductService.GetProduct(ProductId);
            if (Product == null)
            {
                return DoesNotExist();
            }
            _deleteProductService.Delete(Product.Id);
            return Found();
        }

        [Route("{productId:int}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(int ProductId)
        {
            var Product = _getProductService.GetProduct(ProductId);
            return Found(new ProductData(Product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts( string searchString = null)
        {
            var Products = _getProductService.GetAll();
            return Found(Products);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllProducts()
        {
            _deleteProductService.DeleteAll();
            return Found();
        }
    }

}