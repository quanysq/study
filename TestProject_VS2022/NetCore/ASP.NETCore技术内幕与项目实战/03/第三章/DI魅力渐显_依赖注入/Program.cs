using DI魅力渐显_依赖注入;
// 1. 引用依赖注入命名空间
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

// 2. 创建用于注册服务的容器
ServiceCollection services = new ServiceCollection();

// 3.1 注入 IDbConnection 服务（范围）
services.AddScoped<IDbConnection>(sp => {
    string connStr = "Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
    var conn = new SqlConnection(connStr);
    conn.Open();
    return conn;
});

// 3.2 注入 IUserDAO 和 IUserBiz 服务（范围）
// ----把UserDAO注册为IUserDAO服务的实现类
// ----实现类的参数也会一起注入
services.AddScoped<IUserDAO, UserDAO>();
services.AddScoped<IUserBiz, UserBiz>();

// 4. 使用
// 调用IServiceCollection的BuildServiceProvider方法创建一个ServiceProvider对象
using (ServiceProvider sp = services.BuildServiceProvider())
{
    // 调用 GetRequiredService 方法获取服务
    var userBiz = sp.GetRequiredService<IUserBiz>();
    bool b = userBiz.CheckLogin("jacky", "123456");
    Console.WriteLine(b);
}