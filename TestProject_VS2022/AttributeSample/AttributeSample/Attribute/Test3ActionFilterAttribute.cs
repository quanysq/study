using Microsoft.AspNetCore.Mvc.Filters;

namespace AttributeSample
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class Test3ActionFilterAttribute: Attribute, IActionFilter
    {
        private string _myName;
        public Test3ActionFilterAttribute(string myName)
        {
            _myName = myName;
        }
        /// <summary>
        /// 在控制器执行之前调用
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _myName += " before";
        }

        /// <summary>
        /// 在控制器执行之后调用
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _myName += " after";
        }
    }
}
