using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Console025.SQLite
{
  public class SQLiteHelper
  {
    private string dbPath = null;

    public string ConnectionString
    {
      get { return string.Format(@"Data Source = {0}\{1}", AppDomain.CurrentDomain.BaseDirectory, @"SQLite\sqlitest.db"); }
    }
  }
}
