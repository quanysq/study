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
      LDAP.C1.Execute();

      Console.ReadKey();
    }
  }
}
