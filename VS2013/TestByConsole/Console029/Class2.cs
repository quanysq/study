using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console029
{
  /// <summary>
  /// 联合查询
  /// </summary>
  class C2
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

      Console.WriteLine("stulist count: [{0}]", stulist.Count().ToString());

      IEnumerable<string> namelist = new List<string>(new string[] { "张三", "王五" });

      Console.WriteLine("equals: ");
      var l = from item in stulist join nitem in namelist on item.Name equals nitem select item;
      foreach (Student li in l)
      {
        Console.WriteLine(li.Name + ", " + li.Sex + ", " + li.Zy);
      }

      Console.WriteLine("==================");

      Console.WriteLine("not equals(结果不正确): ");
      var ll = from item in stulist
               from nitem in namelist 
               where item.Name != nitem
               select item;
      foreach (Student li in ll)
      {
        Console.WriteLine(li.Name + ", " + li.Sex + ", " + li.Zy);
      }
    }
  }
}
