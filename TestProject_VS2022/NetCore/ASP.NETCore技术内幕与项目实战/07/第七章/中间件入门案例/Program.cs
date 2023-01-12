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
        // 如果在一个中间件中使用ctx.Response.WriteAsync向客户端发送响应，
        // 就不能再执行next.Invoke把请求转到其他中间件了
        // 因为其他中间件中有可能对Response进行了更改，比如修改响应状态码、修改报文头或者向响应报文中写入其他数据，
        // 这样就会造成响应报文体被损坏的问题
        // 所以这里在向报文体中写入内容后，又执行next.Invoke是不推荐的行为
        // 只是为了演示而已
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
    // 使用自定义的中间件
    appbuild.UseMiddleware<CheckAndParsingMiddleware>();

    // 执行
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