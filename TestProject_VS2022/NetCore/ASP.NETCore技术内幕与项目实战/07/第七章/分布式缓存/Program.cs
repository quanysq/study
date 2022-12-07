using Zack.ASPNETCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注册分布式缓存服务
builder.Services.AddStackExchangeRedisCache(options => {
    // 配置 Redis 连接串
    options.Configuration = "127.0.0.1:16379,allowadmin=true";

    // 配置缓存Key前缀，避免和其它程序冲突，因为Redis可能其它程序也在使用
    options.InstanceName = "yzk_";
});

//注册自定义的分布式缓存服务帮助接口
builder.Services.AddScoped<IDistributedCacheHelper, DistributedCacheHelper>();

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
