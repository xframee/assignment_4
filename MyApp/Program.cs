using System;
using DataLayer;
using DataLayer.Model;

var ds = new DataService();

Console.WriteLine(ds.GetOrderById(10500));