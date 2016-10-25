using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console029
{
  /// <summary>
  /// BindingList
  /// </summary>
  class C3
  {
    public static void Execute() 
    {
      BindingList<Student> stulist = new BindingList<Student>
      (
        new Student[]
        {
          new Student () { Name = "张三", Sex = "男", Zy = "会计" },
          new Student () { Name = "李四", Sex = "男", Zy = "会计" },
          new Student () { Name = "王五", Sex = "男", Zy = "会计" },
          new Student () { Name = "王丽", Sex = "女", Zy = "金融" }
        }
      );

      foreach (Student stu in stulist)
      {
        Console.WriteLine(stu.Name + ", " + stu.Sex + ", " + stu.Zy);
      }
    }
  }
}
