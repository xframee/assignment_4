using System;

namespace DataLayer.Model
{
    public class OrderDetails
    {
        public int orderId { get; set; }
        public int productId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }

        public Order order { get; set; }
    }
}
