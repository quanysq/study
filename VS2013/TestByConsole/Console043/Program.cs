using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console043
{
  class Program
  {
    static void Main(string[] args)
    {
      BackupRestoreHelp c = new BackupRestoreHelp();
      //c.BackUpDataBase();

      c.RestoreDatabase();
    }
  }
}
