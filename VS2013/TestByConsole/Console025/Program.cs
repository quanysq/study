using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Console025
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "Мартин Симеонов";
      Console.WriteLine(s);

      UTF8Encoding utf8 = new UTF8Encoding();
      Byte[] encodedBytes = utf8.GetBytes(s);
      String decodedString = utf8.GetString(encodedBytes);
      Console.WriteLine(decodedString);

      string file1 = @"d:\11.txt";      //ANSI
      string file2 = @"d:\121.txt";     //UTF-8
      string file3 = @"d:\document\TCAT_MANUFACTURER.csv";
      using (StreamReader sr = new StreamReader(file2, Encoding.UTF8))
      {
        s = sr.ReadToEnd();
        Console.WriteLine(s);
      }


      string conn = "Server=192.168.10.42\\SQL2014;Database=BPC2_1020;uid=sa;pwd=Simple.0;";    //Server=.;Database=Test;uid=sa;pwd=quanysq123;
      using (SqlConnection cn = new SqlConnection(conn))
      {
        cn.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = cn;
        //com.CommandText = string.Format("insert into t001(tname) values('{0}')", s);
        com.CommandText = string.Format("UPDATE TCAT_MANUFACTURER SET MANUFACTURER='{0}' WHERE CAT_MANUFACTURER_ID=94404685", s);
        com.ExecuteNonQuery();
        Console.WriteLine("insert ok");
      }
      
      

      Console.ReadKey();
    }
  }
}
