using System;

namespace DataLayer.Model
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }

        public int orderId { get; set; }
        public Order order { get; set; }

        public Product Product { get; set; }
    }
}
