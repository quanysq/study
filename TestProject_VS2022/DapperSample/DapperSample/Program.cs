using DapperSample;
using DapperSample.Entities;
using DapperSample.Services;
using Microsoft.Extensions.Configuration;

// Singleton.Instance.ShowMsg();
OutInExample outInExample = new OutInExample();
outInExample.Main();

/*
ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var config = configBuilder.Build();

var productService = new ProductService(config);

// 插入一条记录
var product = new Product { Name = "Laptop", Price = 1200 };
productService.AddProduct(product);

// 获取所有记录
var products = productService.GetAllProducts();
foreach (var p in products)
{
    Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}");
}
*/
Console.ReadKey();