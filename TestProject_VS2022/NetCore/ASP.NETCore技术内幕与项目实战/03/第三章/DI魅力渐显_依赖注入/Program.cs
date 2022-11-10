using DI魅力渐显_依赖注入;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

ServiceCollection services = new ServiceCollection();
// 组装服务
services.AddScoped<IDbConnection>(sp => {
    string connStr = "Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
    var conn = new SqlConnection(connStr);
    conn.Open();
    return conn;
});
// ----把UserDAO注册为IUserDAO服务的实现类
services.AddScoped<IUserDAO, UserDAO>();
services.AddScoped<IUserBiz, UserBiz>();

using (ServiceProvider sp = services.BuildServiceProvider())
{
    var userBiz = sp.GetRequiredService<IUserBiz>();
    bool b = userBiz.CheckLogin("jacky", "123456");
    Console.WriteLine(b);
}