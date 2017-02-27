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
      MSSQL.C4.Execute();
      
      Console.ReadKey();
    }
  }
}
