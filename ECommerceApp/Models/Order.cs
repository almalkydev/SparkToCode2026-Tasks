using System;
using System.Collections.Generic;

namespace ECommerceApp
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
        public Review Review { get; set; }
    }
}
