using System;
using System.Collections.Generic;

namespace ECommerceApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
