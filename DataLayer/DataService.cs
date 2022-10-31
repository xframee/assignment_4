using DataLayer.Model;

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

        var orders = db.Orders.Where(x => x.orderId == Id).ToList();

        if (!orders.Any())
        {
            return ($"Couldnt find and order with ID: {Id}"); 
        }

        foreach (var order in orders)
        {
            result = ($"Order ID: {order.orderId}, Customer ID: {order.customerId}, Employee ID: {order.employeeId}, Order Date: {order.orderDate}, " +
            $"Redquired Date: {order.requiredDate}, Shipped Date: {order.shippedDate}, Freight: {order.freight}, Shipe Name: {order.shipName}, " +
            $"Ship Adress: {order.shipAddress}, Ship City: {order.shipCity}, Ship Postal Code: {order.shipPostalCode}, " +
            $"Ship Country: {order.shipcountry}");
        }

        return result;
    }
}

