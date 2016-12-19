using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  /// <summary>
  /// JSON(Newtonsoft.Json)
  /// </summary>
  class C6
  {
    public static void Execute()
    {
      List<PersonJsonObj> p = new List<PersonJsonObj>();
      p.Add(new PersonJsonObj() { Name = "A", Age = 18, LastLoginTime = DateTime.Now });
      p.Add(new PersonJsonObj() { Name = "B", Age = 20, LastLoginTime = DateTime.Now });
      p.Add(new PersonJsonObj() { Name = "C", Age = 38, LastLoginTime = DateTime.Now });
      string jsonPerson = JsonConvert.SerializeObject(p);
      Console.WriteLine(jsonPerson);

      string json = "{\"Age\":28,\"LastLoginTime\":\"2011-01-09 00:30:00\",\"Name\":\"张三\"}";
      PersonJsonObj pp = JsonConvert.DeserializeObject<PersonJsonObj>(json);
      Console.WriteLine("JSON反序列化：" + pp.LastLoginTime);
    }
  }
}
