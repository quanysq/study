using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// StreamReader
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      string filepath = @"d:\abc.txt";
      string filenote = "";

      using (StreamReader sr = new StreamReader(filepath, Encoding.ASCII))
      {
        filenote = sr.ReadToEnd();
      }
    }
  }
}
