using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// IndexOf
  /// </summary>
  class C19
  {
    public static void Execute()
    {
      string version = "5.1.121.11459";
      int index = version.IndexOf('.', 4);
      string val = version.Substring(index+1);
      Console.WriteLine(val);
      //Result: 11459
    }

    /*
     * String.IndexOf (value, [startIndex], [count])  
     * 例如str1.IndexOf('a',5,2)
     * 从str1字符串中的第5个字符开始，到第（5+2）=7位结束，查找在这个里面‘a'的位置
     * 若str1 = 'adskvlajeg',则str1.IndexOf('a',5,2)=6
     * 注：索引是从0开始的；
     * indexof() ：在字符串中从前向后定位字符和字符串；所有的返回值都是指在字符串的绝对位置，如为空则为- 1
     */
  }
}
