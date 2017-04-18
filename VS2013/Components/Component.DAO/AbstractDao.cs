using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.DAO
{
  public abstract class AbstractDao
  {
    public string ConnectionString { get; set; }

    public T ExecuteSQL<T>(string sqlText)
    {
      return default(T);
    }

    protected abstract DataTable GetDataTable(string sqlText);

    protected abstract IDataReader GetDataReader(string sqlText);

    protected abstract object GetFirstColumnValue(string sqlText);

    protected abstract int ExecuteDDL(string sqlText);
  }
}
