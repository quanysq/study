using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console025.MSSQL
{
  class C4
  {
    /// <summary>
    /// 判断DataReader已经到了结尾
    /// </summary>
    public static void Execute()
    {
      string conn = "Data Source=localhost;Initial Catalog=DBHelper;Integrated Security=True;";
      using (SqlConnection cn = new SqlConnection(conn))
      {
        cn.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = cn;
        com.CommandText = "SELECT '['+CAST(ClassifyType AS VARCHAR(10))+'] '+ClassifyName AS ClassifyName FROM MethodClassify";
        SqlDataReader dr = com.ExecuteReader();
        CustomEOF(dr);
        dr.Close();
        com.Dispose();
      }
    }

    static void CustomEOF(SqlDataReader dr)
    {
      int total=0, count = 0;
      List<string> list = new List<string>();
      while (true)
      {
        total++;
        bool result = dr.Read();

        if (count == 0)
        {
          if (list.Count > 0 && result)
          {
            Console.WriteLine("list.Count is {0}", list.Count);
            foreach (string s in list) Console.WriteLine(s);
            list.Clear();
          }
        }

        if (!result)
        {
          Console.WriteLine("Is end.");
          break;
        }

        count++;
        list.Add(dr["ClassifyName"].ToString());

        if (count >= 3)
        {
          count = 0;
        }
      }
      Console.WriteLine("count: {0}", count);
      Console.WriteLine("total: {0}", total);
      if (list.Count > 0)
      {
        Console.WriteLine("List has values");
        foreach (string s in list) Console.WriteLine(s);
      }
    }

    
  }
}
