using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 注册 FluentValidation 服务
//builder.Services.AddFluentValidation(fv =>
//{
//    // 旧的写法，已经被抛弃
//    // 用Assembly.GetExecutingAssembly获取入口项目的程序集
//    // RegisterValidatorsFromAssembly方法用于把指定程序集中所有实现了IValidator接口的数据校验类注册到依赖注入容器中
//    // 如果数据校验类位于多个程序集中，可以调用RegisterValidatorsFromAssemblies来指定这些程序集进行注册
//    Assembly assembly = Assembly.GetExecutingAssembly();
//    fv.RegisterValidatorsFromAssembly(assembly);
//});
Assembly assembly = Assembly.GetExecutingAssembly();
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(assembly);
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
