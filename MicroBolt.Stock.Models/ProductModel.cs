using System;

namespace MicroBolt.Stock.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
