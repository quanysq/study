using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Transactions;

public class TransactionScopeFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {
        bool hasNotTransactionalAttribute = false;
        if (context.ActionDescriptor is ControllerActionDescriptor)
        {
            var actionDesc = (ControllerActionDescriptor)context.ActionDescriptor;
            //判断操作方法上是否标注了NotTransactionalAttribute
            hasNotTransactionalAttribute = actionDesc.MethodInfo.IsDefined(typeof(NotTransactionalAttribute));
        }

        //如果操作方法标注了NotTransactionalAttribute，直接执行操作方法
        if (hasNotTransactionalAttribute)
        {
            await next();
            return;
        }

        //如果操作方法没有标注NotTransactionalAttribute，启用事务
        using var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var result = await next();
        if (result.Exception == null)
        {
            txScope.Complete();
        }
    }
}
