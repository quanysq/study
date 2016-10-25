using System;
using System.Collections.Generic;
using System.Text;
using IBM.Data.DB2;

namespace Console030
{
  /// <summary>
  /// 使用 DB2 .NET Data Provider，需要编译成2.0才行
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      string db2connstr = "SERVER=127.0.0.1:50000;DATABASE=DB2Test;UID=yangsq;PWD=bdnacn;";
      DB2Connection conn = new DB2Connection(db2connstr);
      conn.Open();
      Console.WriteLine("DB2 Open!");

      string sqlstr = "SELECT CLOBDATA FROM T001";
      DB2Command cmd = new DB2Command(sqlstr, conn);
      DB2DataReader dr = cmd.ExecuteReader();
      while (dr.Read())
      {
        object cellvalue = dr[0];
        Console.WriteLine(cellvalue.ToString());
      }

      conn.Close();
      conn = null;
    }
  }
}
