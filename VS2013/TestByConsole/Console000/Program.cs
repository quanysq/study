using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Console000
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(0xFFFFFFFF);
      UInt32 crc = 0 ^ 0xFFFFFFFF;
      Console.WriteLine(crc);
    }
  }


  

  
}
