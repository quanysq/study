using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.RandomFunc
{
  /// <summary>
  /// This索引器
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      // 声明一个Course类的实例
      var course = new Course();

      // 使用索引器访问实例成员
      // 赋值
      course[0] = 95;
      course[1] = 100;
      course[2] = 80;
      // 取值
      Console.WriteLine("语文:{0}，数学:{1}，英语:{2}", course[0], course[1], course[2]);

      course["Chinese", 10] = 80;
      Console.WriteLine("语文:{0}", course["Chinese", 0]);

      Console.ReadKey();
    }
  }
  /*
  索引器和属性的比较

　　1.相同点

　　　　1).索引和属性都不用分配内存位置来存储。

　　　　2).索引和属性都是为类的其它成员提供访问控制的。

　　　　3).索引和属性都有get访问器和set访问器，它们可以同时声明两个访问器，也可以只声明其中一个。

　　2.不同点

　　　　1).属性通常表示单独的数据成员，而索引表示多个数据成员。

　　　　2).属性既可以声明为实例属性，也可以声明为静态属性，而索引不能声明为静态的。　

　　　　3).属性有简洁的自动实现属性，而索引必须声明完整。

　　　　4).get访问器：属性的 get 访问器没有参数，索引器的 get 访问器具有与索引器相同的形参表。　

　　　　5).set访问器：属性的 set 访问器包含隐式 value 参数。除了值参数外，索引器的 set 访问器还具有与索引器相同的形参表。 
  */
}
