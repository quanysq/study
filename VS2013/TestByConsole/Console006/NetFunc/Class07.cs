using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.NetFunc
{
  class C7
  {
    public static void Execute()
    {
      Uri uriAddress = new Uri("http://www.aiaide.com:8080/Home/index.htm?a=1&b=2#search");
      //Uri uriAddress = new Uri("https://localhost/bdna/ux/index");
      Console.WriteLine(uriAddress.Scheme);
      Console.WriteLine(uriAddress.Authority);
      Console.WriteLine(uriAddress.Host);
      Console.WriteLine(uriAddress.Port);
      Console.WriteLine(uriAddress.AbsolutePath);
      Console.WriteLine(uriAddress.Query);
      Console.WriteLine(uriAddress.Fragment);
      //通过UriPartial枚举获取指定的部分
      Console.WriteLine(uriAddress.GetLeftPart(UriPartial.Path));
      //获取整个URI
      Console.WriteLine(uriAddress.AbsoluteUri);
      /*
       * Output:
       * http
       * www.aiaide.com:8080
       * www.aiaide.com
       * 8080
       * /Home/index.htm
       * ?a=1&b=2
       * #search
       * http://www.aiaide.com:8080/Home/index.htm
       * http://www.aiaide.com:8080/Home/index.htm?a=1&b=2#search
       */
    }
  }
}
