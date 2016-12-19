using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 单个Select
  /// </summary>
  class C8
  {
    public static void Execute()
    {
      IEnumerable<Student> stulist = new BindingList<Student>
      (
        new Student[]
        {
          new Student () { Name = "张三", Sex = "男", Zy = "会计" },
          new Student () { Name = "李四", Sex = "男", Zy = "会计" },
          new Student () { Name = "王五", Sex = "男", Zy = "会计" },
          new Student () { Name = "王丽", Sex = "女", Zy = "金融" }
        }
      );

      IEnumerable<string> l = from item in stulist select item.Name;
      foreach (string li in l)
      {
        Console.WriteLine(li);
      }
      Console.WriteLine("===========");
      IEnumerable<string> ll = new List<string>(new string[] { "张三", "王五" });
      var ll3 = l.Except(ll);
      foreach (string li in ll3)
      {
        Console.WriteLine(li);
      }
    }
  }

  /*
   * List<T> 初始化方法：
   * 1 初始化集合器
   *   C#3.0开始，提供了初始化功能，但是并没有反应到ＩＬ代码中，在ＩＬ中，一样也是把个转化成ADD方法来调用
   *   List<int> l2 = new List<int>() { 1 ,2 ,3 ,4 ,5 };
   * 2 添加元素 AddRange() 本方法可以一次性添加一批对象
   *   List<Person> lists = new List<Person>(10);
   *   参数是一个必须可能跌代的对象,也可是数组  
   *   list.AddRange( new Person[] { new Person( "aladdin" ,20) , new Person("zhao",6)});
   * 3 构造传入批量参数 ,与AddRange效果一样
   *   List<Person> mylist = new List<Person>(new Person[] { new Person( "aladdin" ,20) , new Person("zhao",6)});
   */
}
