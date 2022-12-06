var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//注意，如果项目启用了CORS，请确保app.UseCors写到app.UseResponseCaching之前。
//app.UseCors();

//启用服务器端响应缓存中间件
//要写在 app.MapControllers() 之前
//服务器端响应缓存存在很多限制和安全风险，不建议启用“响应缓存中间件”
//app.UseResponseCaching(); 

app.MapControllers();

app.Run();
