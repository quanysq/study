using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Console014
{
  /// <summary>
  /// 序列化和反序列化
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //C1.Execute();     //二进制
      //C2.Execute();     //SOAP
      C3.Execute();     //XML
      //C4.Execute();     //JSON(DataContractJsonSerializer)
      //C5.Execute();     //JSON(Newtonsoft.Json)
    }
  }

  
}
