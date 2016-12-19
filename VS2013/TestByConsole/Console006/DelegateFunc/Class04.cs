using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.DelegateFunc
{
  /// <summary>
  /// 把委托作为一个方法的参数
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      Test_Call_MyDelegate(10, delegate(int j) { return j.ToString(); });

      //或者下面的方式
      //Test_Call_MyDelegate(10, DoDelegate);
    }

    delegate string MyDelegate(int fortime);

    static void Test_Call_MyDelegate(int maxtime, MyDelegate mydelegate)
    {
      for (int i = 0; i < maxtime; i++)
      {
        Console.WriteLine(mydelegate(i));
      }
    }

    static string DoDelegate(int input)
    {
      return input.ToString();
    }
  }
}
