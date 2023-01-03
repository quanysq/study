using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IServiceCollection services = builder.Services;

// 注册托管服务
services.AddHostedService<ExplortStatisticBgService>();

// 注入数据库上下文
services.AddDbContext<TestDbContext>(options => {
    string connStr = builder.Configuration.GetConnectionString("Default")!;
    options.UseSqlServer(connStr);
});

// 数据保护服务注入
// ----数据保护提供了一个简单、基于非对称加密改进的加密API用于确保Web应用敏感数据的安全存储
// ----不需要开发人员自行生成密钥，它会根据当前应用的运行环境，生成该应用独有的一个私钥
services.AddDataProtection();

// 注入 Identity 框架的一些重要的基础配置
// 如果没有这个，下面的注入 UserManager 等服务会有问题，程序无法编译
services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});

// 注入 UserManager、RoleManager 等Identity 框架服务
var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), services);
idBuilder.AddEntityFrameworkStores<TestDbContext>()
    .AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
