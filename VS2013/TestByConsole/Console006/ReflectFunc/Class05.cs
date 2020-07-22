using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console006.ReflectFunc
{
  /// <summary>
  /// 调试 DP call UC method (Remoting)
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      string file = @"C:\Program Files\BDNA\Data Platform\Bin\BDNA.NormalizeBI.Interface.dll";
      Assembly interfaceAssembly = Assembly.UnsafeLoadFrom(file);
      var AssemblyTypeName = "BDNA.NormalizeBI.Interface.IAppService";
      var iTheInterface = interfaceAssembly.GetType(AssemblyTypeName);
      string ServiceURL = "tcp://127.0.0.1:8084/NormalizeBIUpdateServer/AppService";
      object remotingService = Activator.GetObject(iTheInterface, ServiceURL);
      var MethodName = "TestConnection";
      MethodInfo m = iTheInterface.GetMethod(MethodName);
      List<object> ParamsList = new List<object>();
      ParamsList.Add("DPUC1");
      ParamsList.Add("Simple.0");
      var o = m.Invoke(remotingService, ParamsList.ToArray());

      Console.WriteLine("OK! Result: [{0}]", o.ToString());
    }
  }
}
