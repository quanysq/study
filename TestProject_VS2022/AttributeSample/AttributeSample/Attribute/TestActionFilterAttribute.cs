using Microsoft.AspNetCore.Mvc.Filters;

namespace AttributeSample
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TestActionFilterAttribute: ActionFilterAttribute
    {
        private ILogger<TestActionFilterAttribute> _logger;
        
        public TestActionFilterAttribute(ILogger<TestActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 在控制器执行之前调用
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("在控制器执行之前调用...");
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 在控制器执行之后调用
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("在控制器执行之后调用...");
            base.OnActionExecuted(context);
        }
    }
}
