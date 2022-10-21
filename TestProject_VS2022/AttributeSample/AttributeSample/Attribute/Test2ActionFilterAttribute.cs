using Microsoft.AspNetCore.Mvc.Filters;

namespace AttributeSample
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class Test2ActionFilterAttribute: Attribute, IActionFilter
    {
        private ILogger<Test2ActionFilterAttribute> _logger;
        
        public Test2ActionFilterAttribute(ILogger<Test2ActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 在控制器执行之前调用
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("在控制器执行之前调用...");
        }

        /// <summary>
        /// 在控制器执行之后调用
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("在控制器执行之后调用...");
        }
    }
}
