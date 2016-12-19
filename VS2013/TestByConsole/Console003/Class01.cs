using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  /// <summary>
  /// 二进制 1
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      Book book = new Book("Day and Night", 30.0f, "Bruce");

      using (FileStream fs = new FileStream(@"d:\Book.dat", FileMode.Create))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, book);    //将对象序列化为一个文件
      }

      book = null;

      using (FileStream fs = new FileStream(@"d:\book.dat", FileMode.Open))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        book = (Book)formatter.Deserialize(fs);//反序化为一个对象，在这里大家要注意咯,他的返回值是object
      }
    }
  }

}
