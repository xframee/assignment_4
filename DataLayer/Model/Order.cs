using System;

namespace DataLayer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string customerId { get; set; }
        public int employeeId { get; set; }
        public DateOnly orderDate { get; set; }
        public DateOnly requiredDate { get; set; }
        public DateOnly? shippedDate { get; set; }
        public int freight { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string? shipPostalCode { get; set; }
        public string shipcountry { get; set; }

        public OrderDetails OrderDetails { get; set; }
    }
}

