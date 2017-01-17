using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.Class
{
  public class Student2
  {
    public Student2(int studentId, bool sex, String name, String address)
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
  public class StudentListEquality : IEqualityComparer<Student2>
  {
    public bool Equals(Student2 x, Student2 y)
    {
      return x.StudentId == y.StudentId;
    }

    public int GetHashCode(Student2 obj)
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
