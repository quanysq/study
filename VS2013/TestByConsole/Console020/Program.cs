using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console020
{
  class Program
  {
    static void Main(string[] args)
    {
      Test_Call_MyDelegate(10, delegate(int j) { return j.ToString(); });

      //或者下面的方式
      //Test_Call_MyDelegate(10, DoDelegate);
    }

    public delegate string MyDelegate(int fortime);

    static void Test_Call_MyDelegate(int maxtime, MyDelegate mydelegate)
    {
      for (int i = 0; i < maxtime; i++)
      {
        Console.WriteLine(mydelegate(i));
      }
    }

    static string DoDelegate(int input)
    {
      return input.ToString();
    }

  }
}
