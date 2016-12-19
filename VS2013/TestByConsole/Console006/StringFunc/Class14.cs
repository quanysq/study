using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 方法参数值被改变
  /// </summary>
  class C14
  {
    public static void Execute()
    {
      test(SearchOption.AllDirectories);
      testprams("d");
    }

    static void test(SearchOption searchoption)
    {
      searchoption = SearchOption.TopDirectoryOnly;
      Console.WriteLine(searchoption);
    }

    static void testprams(string pwd)
    {
      pwd = pwd + "abc";
      Console.WriteLine(pwd);
    }
  }
}
