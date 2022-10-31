using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataLayer.Model;

namespace DataLayer
{
    public class NorthwindContext :DbContext
    {
        const string connectionString = "host=localhost;db=northwind;uid=postgres;pwd=paranormalA1";

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        //public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");

            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.customerId).HasColumnName("customerid");
            modelBuilder.Entity<Order>().Property(x => x.employeeId).HasColumnName("employeeid");
            modelBuilder.Entity<Order>().Property(x => x.orderDate).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.requiredDate).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.shippedDate).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(x => x.freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.shipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.shipAddress).HasColumnName("shipaddress");
            modelBuilder.Entity<Order>().Property(x => x.shipCity).HasColumnName("shipcity");
            modelBuilder.Entity<Order>().Property(x => x.shipPostalCode).HasColumnName("shippostalcode");
            modelBuilder.Entity<Order>().Property(x => x.shipcountry).HasColumnName("shipcountry");

            /*
            modelBuilder.Entity<Customer>().ToTable("customers");
            modelBuilder.Entity<Customer>().Property(x => x.id).HasColumnName("customerid");
            modelBuilder.Entity<Customer>().Property(x => x.companyName).HasColumnName("companyname");
            modelBuilder.Entity<Customer>().Property(x => x.contactName).HasColumnName("contactname");
            modelBuilder.Entity<Customer>().Property(x => x.contactTitle).HasColumnName("contacttitle");
            modelBuilder.Entity<Customer>().Property(x => x.address).HasColumnName("address");
            modelBuilder.Entity<Customer>().Property(x => x.city).HasColumnName("city");
            modelBuilder.Entity<Customer>().Property(x => x.postalCode).HasColumnName("postalcode");
            modelBuilder.Entity<Customer>().Property(x => x.country).HasColumnName("country");
            modelBuilder.Entity<Customer>().Property(x => x.phoneNumber).HasColumnName("phone");
            modelBuilder.Entity<Customer>().Property(x => x.fax).HasColumnName("fax");
            */
            
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(x => x.productId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(x => x.price).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(x => x.quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(x => x.discount).HasColumnName("discount");
            


        }
    }
}


