using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  /// <summary>
  /// JSON（DataContractJsonSerializer）
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      PersonJsonObj p = new PersonJsonObj();
      p.Name = "张三";
      p.Age = 28;
      p.LastLoginTime = DateTime.Now;

      string jsonString = JsonHelper.JsonSerializer<PersonJsonObj>(p);
      Console.WriteLine("JSON序列化：" + jsonString);

      string json = "{\"Age\":28,\"LastLoginTime\":\"2011-01-09 00:30:00\",\"Name\":\"张三\"}";
      PersonJsonObj pp = JsonHelper.JsonDeserialize<PersonJsonObj>(json);
      Console.WriteLine("JSON反序列化：" + pp.LastLoginTime);
    }
  }
}
