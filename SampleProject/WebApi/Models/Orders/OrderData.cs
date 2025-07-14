using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Orders
{
    public class OrderData
    {
        public OrderData(Order order)
        {
            Id = order.Id;
            Name = order.Name;
            TotalAmount = (decimal)order.TotalAmount;
            OrderDate = (DateTime)order.OrderDate;
            ProductIds = (List<int>)order.ProductIds;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<int> ProductIds { get; set; }
    }
}