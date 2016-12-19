using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  [Serializable]
  class Book
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
