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

//test af funktion 6 der henter info om produkuft med produkt ID

var productInfo = ds.GetProductById(33);

foreach (var info in productInfo)
{
    Console.WriteLine($"Product Name: {info.productName}, Unit Price: {info.price}, Category Name: {info.categoryName}");
}

//test af funktion 7 der finder produkter der matcher en substring

var productsMatching = ds.GetProductsContaining("Tofu");

foreach (var product in productsMatching)
{
    Console.WriteLine($"Product Name: {product.pruductName} Category Name: {product.categoryName}");
}

//test af funktion 8 der finder produktnavn og kategoriavn ud fra produkt id
var productAndCategoryName = ds.GetProductsByCategoryId(8);

foreach (var item in productAndCategoryName)
{
    Console.WriteLine($"Product name: {item.productName}, Category Name: {item.categoryName}, Price: {item.price}");
}

//test af funktion 9 der finger categoris med category id
Console.WriteLine(ds.GetCategorybyId(5));

//test 10 få alle kategorier
var categoriesAll = ds.GetCategories();

foreach (var category in categoriesAll)
{
    Console.WriteLine($"Category ID:  {category.Id}, Category Name: {category.Name}, Description: {category.Description}");
}

//test af funktion 11 der tilføjer en kategri
var newAddedCategory = ds.AddCategory("Toys","Dunno");

foreach (var item in newAddedCategory)
{
    Console.WriteLine($"Category ID:  {item.Id}, Category Name: {item.Name}, Description: {item.Description}");
}

//test af funktion 12 der opdaterer en kategori
Console.WriteLine(ds.UpdateCategory(10, "Kage", "Namme"));
Console.WriteLine(ds.UpdateCategory(10000, "Kage", "Namme")); //tester om false ved ikke fundet id

//test af funktion 13 der sletter en kategori
Console.WriteLine(ds.DeleteCategory(13));
Console.WriteLine(ds.DeleteCategory(10000)); //tester om false ved ikke fundet id

