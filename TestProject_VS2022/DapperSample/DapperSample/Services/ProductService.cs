using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using DapperSample.Entities;

namespace DapperSample.Services
{
    public class ProductService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 依赖注入配置接口
        /// </summary>
        /// <param name="configuration"></param>
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 使用 Dapper 查询数据例子
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            var connStr = _configuration.GetConnectionString("Default");
            using var connection = new SqlConnection(connStr);
            connection.Open();
            var sql = "SELECT * FROM Product";
            var products = connection.Query<Product>(sql);
            return products;
        }

        /// <summary>
        /// 使用 Dapper 添加数据例子
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            var connStr = _configuration.GetConnectionString("Default");
            using var connection = new SqlConnection(connStr);
            connection.Open();
            var sql = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            connection.Execute(sql, product);
        }
    }

    /// <summary>
    /// 简化后的单例模式
    /// </summary>
    public sealed class Singleton
    {
        // 定义一个静态成员
        private static readonly Singleton instance = new Singleton();

        // 定义一个静态构造函数
        static Singleton() { }

        // 定义一个私有构造函数
        private Singleton() { }

        // 定义一个静态属性
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void ShowMsg()
        {
            Console.WriteLine("这是单例模式");
        }
    }
}
