﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console005
{
  /// <summary>
  /// 域操作
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //LDAP.C3.Execute();
      //SharpZipLib.C1.Execute();
      //CustomLog.C01.Execute();
      //IIS.C3.Execute(args);
      //ZipStorer.C1.Execute();
      IIS.C4.Execute(args);

      Console.ReadKey();
    }
  }
}
