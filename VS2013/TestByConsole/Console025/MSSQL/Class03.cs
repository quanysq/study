using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console025.MSSQL
{
  /// <summary>
  /// 使用Windows Authentication连接数据库
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      string conn = "Data Source=localhost;Initial Catalog=DBHelper;Integrated Security=True;";
      using (SqlConnection cn = new SqlConnection(conn))
      {
        cn.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = cn;
        com.CommandText = "SELECT * FROM UserInfo";
        object o = com.ExecuteScalar();
        Console.WriteLine("insert ok");
      }
    }
  }
}
