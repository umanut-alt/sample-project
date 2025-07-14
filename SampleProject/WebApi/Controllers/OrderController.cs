using BusinessEntities;
using Core.Services.Orders;
using Data.Repositories;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController   
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }
        // GET api/products
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder([FromBody] OrderModel model)
        {
            Order order = new Order { Name = model.Name, OrderDate = model.OrderDate, TotalAmount = model.TotalAmount, ProductIds = model.ProductIds };
            return Found(new OrderData(_createOrderService.Create(order)));
        }
        //Post api/Orders
        [Route("{orderId:int}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(int orderId, [FromBody] OrderModel model)
        {
            Order order = new Order { Id = orderId, Name = model.Name, OrderDate = model.OrderDate, TotalAmount = model.TotalAmount, ProductIds = model.ProductIds };
            var result = _updateOrderService.Update(order);
            if (result == null)
            {
                return DoesNotExist();
            }
            return Found(new OrderData(result));
        }

        [Route("{orderId:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(int orderId)
        {
            var order = _getOrderService.Get(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(orderId);
            return Found();
        }

        [Route("{orderId:int}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(int orderId)
        {
            var order = _getOrderService.Get(orderId);
            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders()
        {
            var Orders = _getOrderService.GetAll()
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(Orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }
    }
}