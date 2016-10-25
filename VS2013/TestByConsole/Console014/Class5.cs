using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Console014
{
  /// <summary>
  /// JSON(Newtonsoft.Json)
  /// </summary>
  public class C5
  {
    public static void Execute()
    {
      List<Person> p = new List<Person>();
      p.Add(new Person() { Name = "A", Age = 18, LastLoginTime = DateTime.Now });
      p.Add(new Person() { Name = "B", Age = 20, LastLoginTime = DateTime.Now });
      p.Add(new Person() { Name = "C", Age = 38, LastLoginTime = DateTime.Now });
      string jsonPerson = JsonConvert.SerializeObject(p);
      Console.WriteLine(jsonPerson);

      string json = "{\"Age\":28,\"LastLoginTime\":\"2011-01-09 00:30:00\",\"Name\":\"张三\"}";
      Person pp = JsonConvert.DeserializeObject<Person>(json);
      Console.WriteLine("JSON反序列化：" + pp.LastLoginTime);
    }

    public class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
      public DateTime LastLoginTime { get; set; }
    }
  }
}
