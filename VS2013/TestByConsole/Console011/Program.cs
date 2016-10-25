using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console011
{
  /// <summary>
  /// 三种委托写法对比
  /// </summary>
  class Program
  {
    //委托声明 -- 定义一个签名:
    delegate double MathAction(double num);

    // 符合委托声明的常规方法
    static double Double(double input)
    {
      return input * 2;
    }

    static void Main(string[] args)
    {
      // 使用一个命名方法实例化委托类型
      /*
       * 写法一，需要写出专门委托的函数，还需要自定义委托
       **/
      MathAction ma = Double;//注意这里千万不可有Double（），否则就成了一个返回类型，是报错的，这里是制定函数的地址，给定的是函数的地址

      //调用委托
      double result1 = ma(4.5);

      //使用系统自定义委托实例化委托类型
      /*
       * 写法二，需要写出专门委托的函数，不需要自定义委托，使用系统委托
       **/
      Func<double, double> func = Double;

      //调用委托
      double result2 = func(4.5);

      //系统委托使用lamdba进行传递参数
      /*
       * 写法三，不需要写出专门委托的函数，还需要自定义委托
       **/
      Func<double, double> result = s => s * 2;//写法还可以换成lamdba语句块,适应多个参数的写法

      double result3 = result(4.5);

      Func<double, double> result4 = s =>
      {
        return s * 2;
      };

      Console.WriteLine(result1);
      Console.WriteLine(result3);
      Console.WriteLine(result2);
      Console.WriteLine(result4(4.5));
    }
  }

  /*
   从Func的委托中，我们可以看出，它简化了我们自己定义委托带来的繁琐，
   同时它更好的结合了Lamdba的使用。减少了自定义函数的作用。同时也是有缺点的，就是错误的出现不容易发现是那里。
   Action委托的使用与Func雷同，这里就不在说了。希望自己的总结可以对大家有所帮助。
   */
}
