using Console006.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.DelegateFunc
{
  /// <summary>
  /// Func<T,TResult>
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      //类似委托功能  
      Func<InputArgs, Result> func = TsetFunction;
      Console.WriteLine("第一种方式：");
      Console.WriteLine(func(new InputArgs("zhangqs008", "123456")));

      Console.WriteLine("=============================================");

      Console.WriteLine("第二种方式：");
      CallMethod(func, new InputArgs("zhangqs008", "1234567")); //或者   
      CallMethod(TsetFunction, new InputArgs("zhangqs008", "1234567"));

      Console.WriteLine("=============================================");

      Console.WriteLine("第三种方式：");
      Func<string, string> convert = s=> s.ToUpper();  //该方法将小写字母转为大写
      string name = "Dakota";
      Console.WriteLine(convert(name));  

      Console.Read();  
    }

    static Result TsetFunction(InputArgs input)
    {
      Result result = new Result();
      result.Flag = String.Compare("zhangqs008", input.UserName, StringComparison.OrdinalIgnoreCase) == 0 &
          String.Compare("123456", input.Password, StringComparison.OrdinalIgnoreCase) == 0;
      result.Msg = "当前调用者：" + input.UserName;
      return result;
    }

    static void CallMethod<T>(Func<T, Result> func, T item)
    {
      Result result = func(item);
      Console.WriteLine(result.ToString());
    }
  }
  /*
   Func

    T

    此委托封装的方法的参数类型。

    TR

    此委托封装的方法的返回值类型。

    在使用 Func委托时，不必显式定义一个封装只有一个参数的方法的委托。以下示例简化了此代码，
    它所用的方法是实例化 Func委托，而不是显式定义一个新委托并将命名方法分配给该委托。
   
    Func是一种委托，这是在3.5里面新增的，2.0里面我们使用委托是用Delegate，Func位于System.Core命名空间下，
    使用委托可以提升效率，例如在反射中使用就可以弥补反射所损失的性能。

    Func<T,TResult> 的表现形式分为以下几种：
    1。Func<T,TResult>
    2。Func<T，T1,TResult>
    3。Func<T,T1,T2,TResult>
    4。Func<T,T1,T2,T3,TResult>
    5。Func<T,T1,T2,T3,T4,TResult>
    TResult表示 委托所返回值 所代表的类型， T,T1,T2,T3,T4表示委托所调用的方法的参数类型。
  */
}
