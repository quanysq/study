using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace MiniWebAPI
{
    /// <summary>
    /// 从请求路径中分析出控制器的名字和操作方法的名字
    /// </summary>
    public class PathParser
    {
        public static (bool ok, string? controllerName, string? actionName) Parse(PathString pathString)
        {
            string? path = pathString.Value;
            if (path == null)
            {
                return (false, null, null);
            }

            //解析出来控制器和Action的名字
            var match = Regex.Match(path, "/([a-zA-Z0-9]+)/([a-zA-Z0-9]+)");
            if (!match.Success)
            {
                return (false, null, null);
            }
            string controllerName = match.Groups[1].Value;
            string actionName = match.Groups[2].Value;
            return (true, controllerName, actionName);
        }
    }
}
