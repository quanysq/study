using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// 需要注意的是，只有ASP.NET Core线程中的未处理异常才会被异常筛选器处理
public class MyExceptionFilter : IAsyncExceptionFilter
{
    private readonly ILogger<MyExceptionFilter> logger;
    private readonly IHostEnvironment env;

    // 注入 ILogger 和 IHostEnvironment
    // IHostEnvironment 用于判断环境类型
    public MyExceptionFilter(
        ILogger<MyExceptionFilter> logger,
        IHostEnvironment env)
    {
        this.logger = logger;
        this.env = env;
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        Exception exception = context.Exception;
        logger.LogError(exception, "UnhandledException occured");
        string message;
        if (env.IsDevelopment())
        {
            // 如果是开发环境，打印所有的异常堆栈信息
            message = exception.ToString();
        }
        else
        {
            // 否则只打印简单信息
            message = "程序中出现未处理异常";
        }

        // 设置响应报文的内容
        ObjectResult result = new ObjectResult(new { code = 500, message = message });
        result.StatusCode = 500;
        context.Result = result;

        // 设置context.ExceptionHandled的值为true，让ASP.NET Core不再执行默认的异常响应逻辑
        context.ExceptionHandled = true;
        return Task.CompletedTask;
    }
}
