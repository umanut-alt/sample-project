using System;

namespace BusinessEntities
{
    public class Product
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private decimal? _price { get; set; }
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public decimal? Price
        {
            get => _price;
            set => _price = value;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }
        public void SetPrice(decimal? price)
        {
            if (price == 0 || price == null)
            {
                throw new ArgumentNullException("price was not provided.");
            }
            _price = price;
        }
    }
}
