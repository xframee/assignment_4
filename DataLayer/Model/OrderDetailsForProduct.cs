using System;
namespace DataLayer.Model
{
    public class OrderDetailsForProduct
    {
        public int orderId { get; set; }
        public int productId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }
        public DateOnly orderDate { get; set; }
    }
}

