using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Console003
{
  /// <summary>
  /// BinaryFormatter序列化、反序列化
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Book book = new Book("Day and Night", 30.0f, "Bruce");

      using (FileStream fs = new FileStream(@"d:\Book.dat", FileMode.Create))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, book);
      }

      book = null;

      using (FileStream fs = new FileStream(@"d:\book.dat", FileMode.Open))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        book = (Book)formatter.Deserialize(fs);//在这里大家要注意咯,他的返回值是object
      }
    }
  }

  [Serializable]
  public class Book
  {
    string name;
    float price;
    string author;

    public Book(string bname, float bprice, string bauthor)
    {
      name = bname;
      price = bprice;
      author = bauthor;
    }


  }
}
