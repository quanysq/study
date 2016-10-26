using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console000
{
  class Class4
  {
    public static void Execute(string[] args)
    {
      CopyFile(@"D:\Conf\111.zip", @"D:\111.zip", true);
      Console.WriteLine("Yes");
    }

    private static void CopyFile(string srcfile, string tgtfile, bool isoverwrite)
    {
      int trytime = 0;
      bool hascopy = false;
      while (!hascopy && trytime < 3)
      {
        trytime++;
        try
        {
          File.Copy(srcfile, tgtfile, isoverwrite);
          hascopy = true;
        }
        catch
        {
          hascopy = false;
          Console.WriteLine("[{3}] Copy file [{0}] To [{1}] failed. [try {2} times]", srcfile, tgtfile, trytime.ToString(), DateTime.Now.ToString());
          if (trytime < 3)
          {
            System.Threading.Thread.Sleep(1000 * trytime * 10);
          }
        }
      }
      if (!hascopy)
      {
        throw new Exception(string.Format("Copy file [{0}] To [{1}] failed.", srcfile, tgtfile));
      }
    }
  }
}
