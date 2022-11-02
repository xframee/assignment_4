using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataLayer;

public class DataService
{

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

    public List<ProductStruct> GetProductById (int Id)
    {
        using var db = new NorthwindContext();

        var productDetailsQuery = db.Products
            .Include(x => x.Category)
            .Where(x => x.Id == Id)
            .Select(group => new ProductStruct
            {
                productName = group.Name,
                price = group.price,
                categoryName = group.Category.Name
            });
        return productDetailsQuery.ToList();
    }

    public List<ProductInfoStruct> GetProductsContaining(string subString)
    {
        using var db = new NorthwindContext();

        var productsQuery = db.Products
            .Include(x => x.Category)
            .Where(x => x.Name.Contains(subString))
            .Select(group => new ProductInfoStruct
            {
                pruductName = group.Name,
                categoryName = group.Category.Name
            });
        return productsQuery.ToList();
    }

    public List<ProductStruct> GetProductsByCategoryId (int Id)
    {
        using var db = new NorthwindContext();

        var productDetailsQuery = db.Products
            .Include(x => x.Category)
            .Where(x => x.Category.Id == Id)
            .Select(group => new ProductStruct
            {
                productName = group.Name,
                price = group.price,
                categoryName = group.Category.Name
            });
        return productDetailsQuery.ToList();
    }

    public string GetCategorybyId (int Id)
    {
        using var db = new NorthwindContext();

        string result = "";

        var categories = db.Categories
            .Where(x => x.Id == Id)
            .ToList();

        if (!categories.Any())
        {
            return null;
        }

        foreach (var item in categories)
        {
            result = ($"Category Name: {item.Name}");
        }
        return result;
    }

    public IList<Category> GetCategories()
    {
        using var db = new NorthwindContext();

        return db.Categories.ToList();
    }

    public IList<Category> AddCategory(string name, string description)
    {
        using var db = new NorthwindContext();

        var listofIds = db.Categories
            .OrderBy(x => x.Id)
            .Select(x => x.Id)
            .ToList();

        var lastId = listofIds.Last();
        var newId = lastId + 1;

        var cat = new Category { Id = newId, Name = name, Description = description };
        db.Categories.Add(cat);
        db.SaveChanges();

        return db.Categories
            .Where(x => x.Id == newId)
            .ToList();
    }

    public bool UpdateCategory (int id, string name, string description)
    {
        using var db = new NorthwindContext();

        var cat = db.Categories.Find(id);

        if (cat == null)
        {
            return false;
        }

        cat.Name = name;
        cat.Description = description;
        db.SaveChanges();
        return true;
    }

    public bool DeleteCategory (int id)
    {
        using var db = new NorthwindContext();

        var cat = db.Categories.Find(id);

        if (cat == null)
        {
            return false;
        }

        db.Categories.Remove(cat);
        db.SaveChanges();
        return true;
    }
}