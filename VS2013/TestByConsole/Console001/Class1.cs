using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
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

      using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
      {
        sw.Write(filenote);
      }
    }
  }
}
