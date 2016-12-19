using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;

namespace Console005.NVelocity
{
  /// <summary>
  /// NVelocity模板引擎
  /// </summary>
  class C1
  {
    public static void Execute(string[] args)
    {
      System.Text.StringBuilder builder = new System.Text.StringBuilder();
      builder.Append("#foreach($u in $ListUsers)\r\n" +
          "#beforeall\r\n" +
          "<table border=\"0\" cellpadding=\"10\" cellspacing=\"10\">" +
          "<tr><td>Name</td><td>Sex</td><td>City</td></tr>" +
          "#each\r\n" +
          "<tr>" +
          "<td>$u.Name</td>" +
          "<td>$u.Sex</td>" +
          "<td>$u.City</td>" +
          "</tr>" +
          "#afterall\r\n" +
          "</table>" +
          "#nodata\r\n" +
          "暂无用户资料\r\n" +
          "#end");

      List<User> listUsers = new List<User>();
      listUsers.Add(new User { Name = "张三", Sex = "男", City = "广东" });
      listUsers.Add(new User { Name = "李四", Sex = "男", City = "湖南" });
      listUsers.Add(new User { Name = "王五", Sex = "女", City = "湖北" });

      VelocityEngine vltEngine = new VelocityEngine();
      vltEngine.Init();

      VelocityContext vltContext = new VelocityContext();
      vltContext.Put("PageTitle", "字符串模板例子");
      vltContext.Put("ListUsers", listUsers);

      System.IO.StringWriter vltWriter = new System.IO.StringWriter();
      vltEngine.Evaluate(vltContext, vltWriter, null, builder.ToString());

      Console.Write(vltWriter.GetStringBuilder().ToString());
    }
  }

  class User
  {
    public string Name { get; set; }
    public string Sex { get; set; }
    public string City { get; set; }
  }
}
