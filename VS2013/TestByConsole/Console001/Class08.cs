using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 获取环境变量值
  /// </summary>
  class C8
  {
    public static void Execute()
    {
      string sPath = Environment.GetEnvironmentVariable("BMS_HOME");
      Console.WriteLine(sPath);
    }
  }
}
