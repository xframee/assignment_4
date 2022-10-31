using EF;
using Microsoft.EntityFrameworkCore;

using var db = new NorthwindContext();

/*foreach (var category in db.Categories.Where(x => x.Name.Contains("Co")))
{
    Console.WriteLine(category.Name);
}


foreach (var product in db.Products.Include(x => x.Category).Take(5))
{
    Console.WriteLine($"Productname: {product.Name}, Category: {product.Category.Name}");
}


var cat = new Category { Id = 101, Name = "Test" }; //tilføj til database
db.Categories.Add(cat);

var cat = db.Categories.Find(101); //Tilføj beskrivelse til en ting i database
cat.Description = "sejkatete";

var cat = db.Categories.Find(101); //Slet fra databsen
db.Categories.Remove(cat);
*/

var cat = db.Categories.Find(103); //Slet fra databsen
db.Categories.Remove(cat);

foreach (var category in db.Categories)
{
    Console.WriteLine(category.Name);
}

db.SaveChanges();
