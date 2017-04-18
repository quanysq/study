using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Console025.SQLite
{
  public class C1
  {

    public static void Execute()
    {
      SQLiteConnection conn = null;
      SQLiteCommand cmd1    = null;
      SQLiteCommand cmd2    = null;
      SQLiteDataAdapter dr  = null;
      DataTable dt          = new DataTable();
      try
      {
        string dbPath = string.Format(@"Data Source = {0}\{1}", AppDomain.CurrentDomain.BaseDirectory, @"SQLite\sqlitest.db");
        conn = new SQLiteConnection(dbPath);
        conn.Open();
        Console.WriteLine("Conect SQLite successful!");

        Console.WriteLine("");
        cmd1 = new SQLiteCommand(conn);
        cmd1.CommandText = "INSERT INTO UserInfo(UserName, CreateDate) VALUES('Jacky', datetime('now', 'localtime'))";
        cmd1.ExecuteNonQuery();
        Console.WriteLine("Insert data successful on SQLite!");

        Console.WriteLine("");
        cmd1.CommandText = "select last_insert_rowid()";
        string newID = Convert.ToString(cmd1.ExecuteScalar());
        Console.WriteLine("last_insert_rowid is [{0}]", newID);

        Console.WriteLine("");
        cmd1.CommandText = string.Format("UPDATE UserInfo SET UserName='Jacky1' where UserID={0}", newID);
        cmd1.ExecuteNonQuery();
        Console.WriteLine("Update data successful on SQLite!");

        Console.WriteLine("");
        cmd1.CommandText = "DELETE FROM UserInfo WHERE UserID=9";
        cmd1.ExecuteNonQuery();
        Console.WriteLine("Delete data successful on SQLite!");

        Console.WriteLine("");
        cmd2 = new SQLiteCommand(conn);
        cmd2.CommandText = "select * from userinfo";
        dr = new SQLiteDataAdapter(cmd2);
        dr.Fill(dt);
        foreach (DataRow dataRow in dt.Rows)
        {
          Console.WriteLine(dataRow["UserID"].ToString() + "   " + dataRow["UserName"].ToString() + "   " + dataRow["CreateDate"].ToString());
        }
        Console.WriteLine("Query data successful on SQLite!");
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dt != null )  dt.Dispose();
        if (dr != null)   dr.Dispose();
        if (cmd2 != null) cmd2.Dispose();
        if (cmd1 != null) cmd1.Dispose();
        if (conn != null) conn.Dispose();
      }
    }
  }
}
