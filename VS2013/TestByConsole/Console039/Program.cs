using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console039
{
  class Program
  {
    static void Main(string[] args)
    {
      Enrollment SourceEnrollment = new Enrollment();
      SourceEnrollment.studentlist.Add(new Student() { StuName = "张三", Age = 20 });
      SourceEnrollment.studentlist.Add(new Student() { StuName = "李三", Age = 20 });

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

  class Student: ICloneable
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
    public List<Student> studentlist = new List<Student>();

    public Enrollment() { }

    //提供实现深拷贝的私有实例创建构造函数
    private Enrollment(List<Student> students)
    {
      foreach (Student stu in students)
      {
        studentlist.Add((Student)stu.Clone());
      }
    }

    public void ShowEnrollmentInfo()
    {
      foreach (Student stu in studentlist)
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
