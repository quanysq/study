var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

//Map 引用请求，一个管道
app.Map("/test", async appbuilder => {
    //Use 中间件1
    appbuilder.Use(async (context, next) => {
        //前逻辑
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("1  Start<br/>");
        
        //执行下一个中间件
        await next.Invoke(); 

        //后逻辑
        await context.Response.WriteAsync("1  End<br/>");
    });
    //Use 中间件2
    appbuilder.Use(async (context, next) => {
        //前逻辑
        await context.Response.WriteAsync("2  Start<br/>");

        //执行最终业务操作方法，因为没有下一个中间件
        await next.Invoke(); 

        //后逻辑
        await context.Response.WriteAsync("2  End<br/>");
    });
    //Run 最终业务操作方法
    appbuilder.Run(async ctx => {
        await ctx.Response.WriteAsync("hello middleware <br/>");
    });

    /*
     * 执行顺序：
     * 中间件1 - 前逻辑
     * 中间件2 - 前逻辑
     * 最终业务操作方法
     * 中间件2 - 后逻辑
     * 中间件1 - 后逻辑
     * 输出
     */
});

app.Map("/testForCustomMiddleware", async appbuild => { 
    appbuild.UseMiddleware<CheckAndParsingMiddleware>();
    appbuild.Run(async ctx => {
        ctx.Response.ContentType = "text/html";
        ctx.Response.StatusCode = 200;
        var jsonObj = (CheckAndParsingMiddlewareModel)ctx.Items["BodyJson"];
        int i = jsonObj.i;
        int j = jsonObj.j;
        await ctx.Response.WriteAsync($"{i}+{j}={i+j}");
    });
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}