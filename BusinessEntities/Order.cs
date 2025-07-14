using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace BusinessEntities
{
    public class Order
    {
        private List<int> _productIds { get; set; } = new List<int>();
        private int _id { get; set; }
        private string _name { get; set; } = string.Empty;
        private decimal? _totalAmount { get; set; }
        private DateTime _orderDate { get; set; }
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public decimal? TotalAmount
        {
            get => _totalAmount;
            set => _totalAmount = value;
        }
        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }
        public IEnumerable<int> ProductIds
        {
            get => _productIds;
            set => _productIds.Initialize(value);
        }
        public void SetProductIds(IEnumerable<int> productIds) => _productIds = productIds.ToList();

        public void SetTotalAmount(decimal? totalAmount)
        {
            if (totalAmount == null)
            {
                throw new ArgumentNullException("TotalAmount was not provided.");
            }
            _totalAmount = totalAmount;
        }
        public void SetOrderDate(DateTime orderDate)
        { _orderDate = orderDate; }
    }
}
