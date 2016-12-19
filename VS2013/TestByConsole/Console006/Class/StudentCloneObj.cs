using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.Class
{
  class StudentCloneObj: ICloneable
  {
    public string StuName { get; set; }
    public int Age { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }

  class Enrollment : ICloneable
  {
    public List<StudentCloneObj> studentlist = new List<StudentCloneObj>();

    public Enrollment() { }

    //提供实现深拷贝的私有实例创建构造函数
    private Enrollment(List<StudentCloneObj> students)
    {
      foreach (StudentCloneObj stu in students)
      {
        studentlist.Add((StudentCloneObj)stu.Clone());
      }
    }

    public void ShowEnrollmentInfo()
    {
      foreach (StudentCloneObj stu in studentlist)
      {
        Console.WriteLine("Name: {0}, Age: {1}", stu.StuName, stu.Age);
      }
    }

    public object Clone()
    {
      return new Enrollment(studentlist);
    }
  }
}
