using Console006.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// 深拷贝
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      Enrollment SourceEnrollment = new Enrollment();
      SourceEnrollment.studentlist.Add(new StudentCloneObj() { StuName = "张三", Age = 20 });
      SourceEnrollment.studentlist.Add(new StudentCloneObj() { StuName = "李三", Age = 20 });

      //深拷贝对象
      Enrollment CloneEnrollment = SourceEnrollment.Clone() as Enrollment;

      SourceEnrollment.ShowEnrollmentInfo();
      Console.WriteLine("=============================");
      CloneEnrollment.ShowEnrollmentInfo();

      CloneEnrollment.studentlist[0].StuName = "赵六";
      CloneEnrollment.studentlist[1].StuName = "赵七";

      Console.WriteLine((new string('~', 20)));

      SourceEnrollment.ShowEnrollmentInfo();
      Console.WriteLine("=============================");
      CloneEnrollment.ShowEnrollmentInfo();
    }
  }
}
