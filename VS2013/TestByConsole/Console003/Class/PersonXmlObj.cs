using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  class PersonXmlObj
  {

    public string Name;//姓名

    public bool Sex;//性别，是否是男

    public PersonXmlObj() { }//必须提供无参构造器，否则XmlSerializer将出错

    public PersonXmlObj(string name, bool sex)
    {

      this.Name = name;

      this.Sex = sex;

    }

    public override string ToString()
    {

      return "姓名：" + this.Name + "\t性别：" + (this.Sex ? "男" : "女");

    }

  }

  class ProgrammerXmlObj : PersonXmlObj
  {

    public string Language;//编程语言

    public ProgrammerXmlObj() { }//必须提供无参构造器，否则XmlSerializer将出错

    public ProgrammerXmlObj(string name, bool sex, string language)
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
