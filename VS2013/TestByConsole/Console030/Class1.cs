using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Console030
{
  /// <summary>
  /// OleDbConnection
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      //string db2connstr = "Provider=DB2OLEDB;Network Transport Library=TCPIP;Network Address=127.0.0.1;Initial Catalog=DB2Test;Package Collection=DB2;Default Schema=Schema;User ID=yangsq;Password=bdnacn;Network Port=50000;";
      string db2connstr = "Provider=IBMDADB2.DB2COPY1;Data Source=DB2Test;UID=yangsq;PWD=bdnacn;";
      OleDbConnection conn = new OleDbConnection(db2connstr);
      try
      {
        conn.Open();
        Console.WriteLine("DB2 Open!");

        string sqlstr = "SELECT CLOBDATA FROM T001";
        OleDbCommand cmd = new OleDbCommand(sqlstr, conn);
        OleDbDataReader dr = cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
          object cellvalue = dr[0];
          Console.WriteLine(cellvalue.ToString());

          //if (cellvalue != DBNull.Value)
          //{
          //  i++;
          //  Console.WriteLine(i);
          //  Console.WriteLine(cellvalue.ToString());
          //}
        }
      }
      catch (Exception ex)
      {
        throw (ex);
      }
      finally
      {
        conn.Close();
        conn = null;
      }
    }
  }
}
