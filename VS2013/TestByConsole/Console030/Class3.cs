using System;
using System.Collections.Generic;
using System.Text;
using IBM.Data.DB2;

namespace Console030
{
  class C3
  {
    public static void Execute()
    {
      string db2connstr = "SERVER=127.0.0.1:50000;DATABASE=DB2Test;UID=yangsq;PWD=bdnacn;";
      System.Data.IDbConnection conn = new DB2Connection(db2connstr);
      conn.Open();
      Console.WriteLine("DB2 Open!");

      string sqlstr = "SELECT CLOBDATA FROM T001";
      System.Data.IDbCommand cmd = new DB2Command();
      cmd.Connection = conn;
      cmd.CommandText = sqlstr;
      System.Data.IDataReader dr = cmd.ExecuteReader();
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
