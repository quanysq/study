using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 比较版本号
  /// </summary>
  class C18
  {
    public static void Execute()
    {
      Version v1 = new Version("5.0.0");
      Version v2 = new Version("5.1.0");
      Version v3 = new Version("5.2.0");
      Version v4 = new Version("5.0.0");

      Console.WriteLine("v2.CompareTo(v1): {0}", v2.CompareTo(v1)); 
      Console.WriteLine("v3.CompareTo(v2): {0}", v3.CompareTo(v2));
      Console.WriteLine("v1.CompareTo(v3): {0}", v1.CompareTo(v3));
      Console.WriteLine("v1.CompareTo(v4): {0}", v1.CompareTo(v4));

      /*
       * v2.CompareTo(v1): 1    v2 > v2 => 1   
       * v3.CompareTo(v2): 1    v3 > v2 => 1
       * v1.CompareTo(v3): -1   v1 < v3 => -1
       * v1.CompareTo(v4): 0    v1 = v4 => 0
       */ 
    }
  }
}
