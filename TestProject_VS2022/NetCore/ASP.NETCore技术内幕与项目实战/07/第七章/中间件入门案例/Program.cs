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

//Map ��������һ���ܵ�
app.Map("/test", async appbuilder => {
    //Use �м��1
    appbuilder.Use(async (context, next) => {
        //ǰ�߼�
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("1  Start<br/>");
        
        //ִ����һ���м��
        await next.Invoke(); 

        //���߼�
        await context.Response.WriteAsync("1  End<br/>");
    });
    //Use �м��2
    appbuilder.Use(async (context, next) => {
        //ǰ�߼�
        await context.Response.WriteAsync("2  Start<br/>");

        //ִ������ҵ�������������Ϊû����һ���м��
        await next.Invoke(); 

        //���߼�
        await context.Response.WriteAsync("2  End<br/>");
    });
    //Run ����ҵ���������
    appbuilder.Run(async ctx => {
        await ctx.Response.WriteAsync("hello middleware <br/>");
    });

    /*
     * ִ��˳��
     * �м��1 - ǰ�߼�
     * �м��2 - ǰ�߼�
     * ����ҵ���������
     * �м��2 - ���߼�
     * �м��1 - ���߼�
     * ���
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