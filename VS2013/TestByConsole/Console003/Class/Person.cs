using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  [Serializable]  //必须添加序列化特性
  class Person
  {

    private string Name;//姓名

    private bool Sex;//性别，是否是男

    public Person(string name, bool sex)
    {

      this.Name = name;

      this.Sex = sex;

    }

    public override string ToString()
    {

      return "姓名：" + this.Name + "\t性别：" + (this.Sex ? "男" : "女");

    }

  }

  [Serializable]  //必须添加序列化特性
  class Programmer : Person
  {

    private string Language;//编程语言

    public Programmer(string name, bool sex, string language)
      : base(name, sex)
    {

      this.Language = language;

    }

    public override string ToString()
    {
      return base.ToString() + "\t编程语言：" + this.Language;
    }
  }
}
