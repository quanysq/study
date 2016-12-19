using Console006.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 行转列
  /// </summary>
  class C12
  {
    public static void Execute()
    {
      List<Student> stulist = new List<Student>()
      {
        new Student () { Name = "张三", Sex = "男", Zy = "会计" },
        new Student () { Name = "王丽", Sex = "女", Zy = "会计" },
        new Student () { Name = "张三", Sex = "男", Zy = "计算机" },
        new Student () { Name = "王丽", Sex = "女", Zy = "金融" },
        new Student () { Name = "Zhangsi", Sex = "男", Zy = "计算机" },
        new Student () { Name = "zhangsi", Sex = "男", Zy = "金融" }
      };
      var list1 = (from stu in stulist group stu by new { stu.Name, stu.Sex } into m select new { Name = m.Key.Name, Sex = m.Key.Sex, Zy = string.Join(",", m.Select(n => n.Zy)) }).ToList();
      foreach (var l in list1)
      {
        Console.WriteLine(l.Name + " # " + l.Sex + " # " + l.Zy);
      }
      Console.WriteLine("=====");
      var list2 = (from stu in stulist group stu by new { CName = stu.Name.ToLower() } into m select new { Name = m.Key.CName, UName = m.Max(n => n.Name), Zy = string.Join(",", m.Select(n => n.Zy)) }).ToList();
      foreach (var l in list2)
      {
        Console.WriteLine(l.Name + " # " + l.UName + " # " + l.Zy);
      }
    }
  }
}
