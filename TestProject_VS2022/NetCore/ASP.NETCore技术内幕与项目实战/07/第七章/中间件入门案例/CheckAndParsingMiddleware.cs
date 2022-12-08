using System.Text.Json;
using System.Text;

/// <summary>
/// 自定义中间类，要求如注释的 1~5 点
/// </summary>
public class CheckAndParsingMiddleware
{
    private readonly RequestDelegate next;

    // 1. 需要有一个构造方法
    // 2. 构造方法需要有一个 RequestDelegate 类型的参数，用于指向下一个中间件
    public CheckAndParsingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    // 3. 需要有一个名为 Invoke 或 InvokeAsync 的方法
    // 4. 此方法至少要有一个 HttpContext 类型参数
    // 5. 此方法的返回值必须是 Task 类型
    public async Task InvokeAsync(HttpContext context)
    {
        string pwd = context.Request.Query["password"];
        if (pwd == "123")
        {
            if (context.Request.HasJsonContentType())
            {
                var reqStream = context.Request.BodyReader.AsStream();
                var jsonObj = JsonSerializer.Deserialize<CheckAndParsingMiddlewareModel>(reqStream);

                //Stream reqStream = context.Request.Body;
                //byte[] buffer = new byte[context.Request.ContentLength!.Value];
                //await reqStream.ReadAsync(buffer, 0, buffer.Length);
                //var reqStr = Encoding.UTF8.GetString(buffer);
                //dynamic jsonObj = JsonSerializer.Deserialize<dynamic>(reqStr)!;

                //将数据存在Items中
                //HttpContext.Items在同一个请求中是共享的，可以用它在多个中间件之间来传递数据
                context.Items["BodyJson"] = jsonObj; 
            }
            // 把请求转给下一个中间件
            await next(context); 
        }
        else
        {
            context.Response.StatusCode = 401;
        }
    }
}

public class CheckAndParsingMiddlewareModel
{
    public int i { get; set; }
    public int j { get; set; }
}
