using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Console006.ReflectFunc
{
  /// <summary>
  /// 获取接口的所有方法
  /// </summary>
  public class C4
  {
    public static void Execute()
    {
      Assembly ass = Assembly.Load("Console038");
      foreach (Type t in ass.GetTypes())
      {
        if (t.GetInterface("ILMSService") != null)
        {
          foreach (MethodInfo mi in t.GetMethods())
          {
            Console.WriteLine(mi.Name);
            /*
            ParameterInfo[] paramsInfo = mi.GetParameters();
            foreach (ParameterInfo pi in paramsInfo)
            {
              Console.WriteLine("  ParameterInfo:" + pi.Name + ", " + pi.ParameterType);
            }*/
          }
        }
      }
      Console.WriteLine("===================================================");
      Type type = typeof(ILMSService);
      Console.WriteLine(type.GetMethods().Length);
      foreach (MethodInfo mi in type.GetMethods())
      {
        Console.WriteLine(mi.Name);
      }
    }
  }
}
