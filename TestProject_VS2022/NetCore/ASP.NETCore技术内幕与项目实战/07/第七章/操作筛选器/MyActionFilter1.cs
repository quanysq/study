using Microsoft.AspNetCore.Mvc.Filters;

public class MyActionFilter1 : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {
        //next之前的代码是在操作方法执行之前要执行的代码
        Console.WriteLine("MyActionFilter 1:开始执行");

        //用next来执行下一个操作筛选器，
        //如果这是最后一个操作筛选器，它就会执行实际的操作方法
        //next的返回值是操作方法的执行结果，返回值是ActionExecutedContext类型的。
        //如果操作方法执行的时候出现了未处理异常，
        //那么ActionExecutedContext的Exception属性就是异常对象，
        //ActionExecutedContext的Result属性就是操作方法的执行结果。
        ActionExecutedContext r = await next();
        
        //next之后的代码则是在操作方法执行之后要执行的代码
        if (r.Exception != null)
        {
            Console.WriteLine("MyActionFilter 1:执行失败");
        }
        else
        {
            Console.WriteLine("MyActionFilter 1:执行成功");
        }
    }
}
