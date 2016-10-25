using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console031
{
  class Program
  {
    static void Main(string[] args)
    {
      IList<Student> oneStudents = new List<Student>();
      oneStudents.Add(new Student(1, false, "小新1", "徐汇"));
      oneStudents.Add(new Student(2, false, "小新2", "闵行"));
      oneStudents.Add(new Student(3, false, "小新3", "嘉定"));
      oneStudents.Add(new Student(4, false, "小新4", "闸北"));

      IList<Student> twoStudents = new List<Student>();
      twoStudents.Add(new Student(5, false, "小新5", "贵州"));
      twoStudents.Add(new Student(6, false, "小新6", "湖北"));
      twoStudents.Add(new Student(7, false, "小新7", "山东"));
      twoStudents.Add(new Student(8, false, "小新8", "西藏"));

      IList<Student> threeStudents = new List<Student>();
      threeStudents.Add(new Student(1, false, "小新1", "徐汇"));
      threeStudents.Add(new Student(2, false, "小新2", "闵行"));
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

  public class Student
  {
    public Student(int studentId, bool sex, String name, String address)
    {
      this.StudentId = studentId;
      this.Sex = sex;
      this.Name = name;
      this.Address = address;
    }
    public int StudentId { get; set; }
    public bool Sex { get; set; }
    public String Name { get; set; }
    public String Address { get; set; }

  }
  public class StudentListEquality : IEqualityComparer<Student>
  {
    public bool Equals(Student x, Student y)
    {
      return x.StudentId == y.StudentId;
    }

    public int GetHashCode(Student obj)
    {
      if (obj == null)
      {
        return 0;
      }
      else
      {
        return obj.ToString().GetHashCode();
      }
    }
  } 
}
