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
            return ($"Couldnt find and order with ID: {Id}"); 
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
}

