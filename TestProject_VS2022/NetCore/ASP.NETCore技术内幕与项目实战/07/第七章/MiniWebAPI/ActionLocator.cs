using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MiniWebAPI
{
    /// <summary>
    /// 根据控制器的名字以及控制器方法名字来定位操作方法
    /// </summary>
    public class ActionLocator
    {
        private Dictionary<string, MethodInfo> data = new(StringComparer.OrdinalIgnoreCase);

        private static bool IsControllerType(Type t)
        {
            var result = t.IsClass && !t.IsAbstract && t.Name.EndsWith("Controller");
            return result;
        }

        public ActionLocator(
            IServiceCollection services, 
            Assembly assemblyWeb)
        {
            var controllerTypes = assemblyWeb.GetTypes().Where(IsControllerType);
            foreach (var ctrlType in controllerTypes)
            {
                services.AddScoped(ctrlType);

                //去掉结尾的Controller
                int index = ctrlType.Name.LastIndexOf("Controller");
                string controllerName = ctrlType.Name.Substring(0, index);
                var methods = ctrlType.GetMethods(BindingFlags.Public|BindingFlags.Instance);
                foreach (var method in methods)
                {
                    string actionName = method.Name;
                    data[$"{controllerName}.{actionName}"] = method;
                }
            }
        }

        public MethodInfo? LocateActionMethod(string controllerName, string actionName)
        {
            string key = $"{controllerName}.{actionName}";
            data.TryGetValue(key, out MethodInfo? method);
            return method;
        }
    }
}
