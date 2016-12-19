using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console025.MSSQL
{
  /// <summary>
  /// 还原备份数据库
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      BackupRestoreHelp c = new BackupRestoreHelp();
      //c.BackUpDataBase();

      c.RestoreDatabase();
    }
  }
}
