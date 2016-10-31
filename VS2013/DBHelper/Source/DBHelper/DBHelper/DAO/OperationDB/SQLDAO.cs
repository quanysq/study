using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Interface;
using System.Data.SqlClient;
using System.Data;
using DBHelper.Common;
using DBHelper.Util;

namespace DBHelper.DAO
{
  class SQLDAO: IOperationDBCommon
  {
    public List<string> ExtractParamerFromStoredProcedure(string StoredProcedureName)
    {
      SqlConnection cn   = null;
      SqlCommand cmd     = null;
      SqlDataAdapter sda = null;
      DataTable dt       = new DataTable();
      try
      {
        List<string> ParamerList = new List<string>();
        cn = new SqlConnection(Common.Common.OperateDbConnection);
        cn.Open();

        string sqlstr = string.Format("select name from syscolumns where id=object_id('{0}')", StoredProcedureName);
        cmd           = new SqlCommand(sqlstr, cn);
        sda           = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
          ParamerList.Add(CommonUtil.TranNull<string>(dr["name"]));
        }
        return ParamerList;
      }
      catch
      {
        throw;
      }
      finally
      {
        if (dt  != null) dt.Dispose();
        if (sda != null) sda.Dispose();
        if (cmd != null) cmd.Dispose();
        if (cn  != null) cn.Dispose();
      }
    }
  }
}
