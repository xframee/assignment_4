using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataLayer;

public class DataService
{
    public IList<Category> GetCategories()
    {
        using var db = new NorthwindContext();

        return db.Categories.ToList();
    }

    public string GetOrderById(int Id)
    {
        var result = "";

        using var db = new NorthwindContext();

        var orders = db.Orders
            .Include(x => x.OrderDetails)
            .Include(x => x.OrderDetails.Product)
            .Include(x => x.OrderDetails.Product.Category)
            .Where(x => x.Id == Id)
            .ToList();

        if (!orders.Any())
        {
            return ($"Couldnt find an order with ID: {Id}"); 
        }

        foreach (var order in orders)
        {
            result = ($"Order ID: {order.Id}, Customer ID: {order.customerId}, Employee ID: {order.employeeId}, Order Date: {order.orderDate}, " +
            $"Redquired Date: {order.requiredDate}, Shipped Date: {order.shippedDate}, Freight: {order.freight}, Shipe Name: {order.shipName}, " +
            $"Ship Adress: {order.shipAddress}, Ship City: {order.shipCity}, Ship Postal Code: {order.shipPostalCode}, " +
            $"Ship Country: {order.shipcountry}, Product ID: {order.OrderDetails.productId}, Unit Price: {order.OrderDetails.price}, " +
            $"Discount: {order.OrderDetails.discount}, Product Name: {order.OrderDetails.Product.Name}, " +
            $"Category Name: {order.OrderDetails.Product.Category.Name}");
        }

        return result;
    }

    public IList<Order> GetOrderByShip (string ship)
    {
        using var db = new NorthwindContext();

        return db.Orders
            .Where(x => x.shipName.Equals(ship))
            .ToList();
    }

    public IList<Order> GetOrderByShip()
    {
        using var db = new NorthwindContext();

        return db.Orders.ToList();
    }

    public List<OrderDetailClass> OrderDetalisByOrderId (int Id)
    {
        using var db = new NorthwindContext();

        var orderDetailsQuery = db.OrderDetails
            .Include(x => x.Product)
            .Where(x => x.Id == Id)
            .Select(group => new OrderDetailClass
            {
                name = group.Product.Name,
                price = group.price,
                quantity = group.quantity
            });
        return orderDetailsQuery.ToList();
    }

    public List<OrderDetailsForProduct> OrderDetailsByProductId (int Id)
    {
        using var db = new NorthwindContext();

        var orderDetailsQuery = db.Orders
            .Include(x => x.OrderDetails)
            .Where(x => x.OrderDetails.productId == Id)
            .Select(group => new OrderDetailsForProduct
            {
                orderId = group.Id,
                productId = group.OrderDetails.productId,
                price = group.OrderDetails.price,
                quantity = group.OrderDetails.quantity,
                discount = group.OrderDetails.discount,
                orderDate = group.orderDate
            });
        return orderDetailsQuery.ToList();
    }
}

