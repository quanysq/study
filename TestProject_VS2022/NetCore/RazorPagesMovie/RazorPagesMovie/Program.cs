using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region 启用各种中间件
// 将 HTTP 请求重定向到 HTTPS
app.UseHttpsRedirection();

// 使能够提供 HTML、CSS、映像和 JavaScript 等静态文件
app.UseStaticFiles();

// 向中间件管道添加路由匹配
app.UseRouting();

// 授权用户访问安全资源
app.UseAuthorization();

// 为 Razor Pages 配置终结点路由
app.MapRazorPages();
#endregion

app.Run();  // 运行应用
