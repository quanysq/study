using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestToolsExample
{
  public class ClsBLL
  {
    public string Hellow()
    {
      return "Hello, My Boy!";
    }

    public int Add(int x, int y)
    {
      return x + y;
    }

    public int Div(int x, int y)
    {
      return x/y;
    }

    public void NoReturnMethod()
    {
      int x = 0;
      int y = 10 / x;
      int z = y + 10;
    }

    public DataTable TestDB()
    {
      DataTable dt = new DataTable();
      string connstr = "Data Source=192.168.8.96;DataBase=TUS51Test;user=sa;password=Simple.0;Max Pool Size=50;Min Pool Size=5;Pooling=true;Connection Lifetime=30;";
      using (SqlConnection cn = new SqlConnection(connstr))
      {
        cn.Open();

        SqlCommand cmd = new SqlCommand("SELECT ID FROM FILE_LIST WHERE GENERATE_ID=723", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        da.Dispose();
        cmd.Dispose();
      }
      return dt;
    }
  }
}
