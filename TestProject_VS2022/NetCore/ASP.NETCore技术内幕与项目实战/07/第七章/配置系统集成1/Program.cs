using StackExchange.Redis;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureAppConfiguration((_, configBuilder) => {
    //读取用户机密文件中的sqlserver连接串
    string connStr = builder.Configuration.GetConnectionString("configServer");
    configBuilder.AddDbConfiguration(() => new SqlConnection(connStr));
});
//采用直接读取builder.Configuration的方式来读取配置
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddSingleton<IConnectionMultiplexer>(sp => {
    string connStr = builder.Configuration.GetValue<string>("Redis:ConnStr");
    return ConnectionMultiplexer.Connect(connStr);
}); 

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
