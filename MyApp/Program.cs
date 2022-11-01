using System;
using DataLayer;
using DataLayer.Model;

var ds = new DataService();

//Test af funktion 1
Console.WriteLine(ds.GetOrderById(10500));

//Test af funktion 2 retuner liste fra ship name
var ordersByShip = ds.GetOrderByShip("North/South");

foreach (var order in ordersByShip)
{
    Console.WriteLine($"Order ID: {order.Id}, Ordered Date: {order.orderDate}, " +
        $"Shipped Date: {order.shippedDate}, Ship Name: {order.shipName}, City: {order.shipCity}");
}

//Test af funktion 3 der overloader GetShipBy
var ordersByShip2 = ds.GetOrderByShip();

foreach (var order in ordersByShip2)
{
    Console.WriteLine($"Order ID: {order.Id}, Ordered Date: {order.orderDate}, " +
        $"Shipped Date: {order.shippedDate}, Ship Name: {order.shipName}, City: {order.shipCity}");
}

//test af funktion 4 der henter order deails med order ID
var orderDetails = ds.OrderDetalisByOrderId(10751);

foreach (var item in orderDetails)
{
    Console.WriteLine($"Product Name: {item.name}, Unit Price: {item.price}, Quantity {item.quantity}");
}

//test af funktion 5 der henter order details med product ID

var orderDetails2 = ds.OrderDetailsByProductId(14);

foreach (var item in orderDetails2)
{
    Console.WriteLine($"Order ID: {item.orderId}, Product ID: {item.productId}, Unit Price: {item.price}, Quantity: {item.quantity}, " +
        $"Discount: {item.discount}, Order Date: {item.orderDate}");
}