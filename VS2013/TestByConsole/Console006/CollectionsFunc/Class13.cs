using Console006.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// List之Union(),Intersect(),Except()
  /// </summary>
  class C13
  {
    public static void Execute()
    {
      IList<Student2> oneStudents = new List<Student2>();
      oneStudents.Add(new Student2(1, false, "小新1", "徐汇"));
      oneStudents.Add(new Student2(2, false, "小新2", "闵行"));
      oneStudents.Add(new Student2(3, false, "小新3", "嘉定"));
      oneStudents.Add(new Student2(4, false, "小新4", "闸北"));

      IList<Student2> twoStudents = new List<Student2>();
      twoStudents.Add(new Student2(5, false, "小新5", "贵州"));
      twoStudents.Add(new Student2(6, false, "小新6", "湖北"));
      twoStudents.Add(new Student2(7, false, "小新7", "山东"));
      twoStudents.Add(new Student2(8, false, "小新8", "西藏"));

      IList<Student2> threeStudents = new List<Student2>();
      threeStudents.Add(new Student2(1, false, "小新1", "徐汇"));
      threeStudents.Add(new Student2(2, false, "小新2", "闵行"));
      var bingji = oneStudents.Union(twoStudents, new StudentListEquality()).ToList();//并（全）集   
      var jiaoji = oneStudents.Intersect(threeStudents, new StudentListEquality()).ToList();//交集   
      var chaji = oneStudents.Except(threeStudents, new StudentListEquality()).ToList();//差集  

      Console.WriteLine();
      Console.WriteLine("以下是并集的结果");
      bingji.ForEach(x =>
      {
        Console.WriteLine(x.StudentId.ToString() + "    " + x.Sex.ToString() + "   " + x.Name.ToString() + " " + x.Address.ToString());

      });
      Console.WriteLine();
      Console.WriteLine("以下是交集的结果");
      jiaoji.ForEach(x =>
      {
        Console.WriteLine(x.StudentId.ToString() + "    " + x.Sex.ToString() + "   " + x.Name.ToString() + " " + x.Address.ToString());

      });

      Console.WriteLine();
      Console.WriteLine("以下是差集的结果");
      chaji.ForEach(x =>
      {
        Console.WriteLine(x.StudentId.ToString() + "    " + x.Sex.ToString() + "   " + x.Name.ToString() + " " + x.Address.ToString());

      });
    }
  }
}
