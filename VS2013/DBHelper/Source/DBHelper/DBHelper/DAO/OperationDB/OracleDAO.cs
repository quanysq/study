using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Interface;
using Oracle.ManagedDataAccess.Client;
using DBHelper.Common;
using DBHelper.Util;
using System.Data;

namespace DBHelper.DAO
{
  class OracleDAO: IOperationDBCommon
  {
    public List<string> ExtractParamerFromStoredProcedure(string StoredProcedureName)
    {
      OracleConnection cn   = null;
      OracleCommand cmd     = null;
      OracleDataAdapter sda = null;
      DataTable dt          = new DataTable();
      try
      {
        List<string> ParamerList = new List<string>();
        cn = new OracleConnection(Common.Common.OperateDbConnection);
        cn.Open();

        string spname; string owner; string packagename;
        ParseStoredProcedureName(StoredProcedureName, out spname, out owner, out packagename);
        StringBuilder sqlstr = new StringBuilder(1024);
        sqlstr.AppendFormat(" select t.object_name from all_arguments t");
        sqlstr.AppendFormat(" where t.object_name='{0}'", spname);
        if (!string.IsNullOrWhiteSpace(owner))
        {
          sqlstr.AppendFormat(" and t.owner='{0}'", owner);
        }
        if (!string.IsNullOrWhiteSpace(packagename))
        {
          sqlstr.AppendFormat(" and t.package_name='{0}'", packagename);
        }
        cmd           = new OracleCommand(sqlstr.ToString(), cn);
        sda           = new OracleDataAdapter(cmd);
        sda.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
          ParamerList.Add(CommonUtil.TranNull<string>(dr["OBJECT_NAME"]));
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

    private void ParseStoredProcedureName(string StoredProcedureName, out string spname, out string owner, out string packagename)
    {
      //Format 1: owner.packagename.spname
      //Format 2: packagename.spname
      //Format 3: spname
      spname      = "";
      owner       = "";
      packagename = "";

      string[] arrStoredProcedureName = StoredProcedureName.Split('.');
      switch (arrStoredProcedureName.Length)
      {
        case 2:
          packagename = arrStoredProcedureName[0].ToUpper();
          spname      = arrStoredProcedureName[1].ToUpper();
          break;
        case 3:
          owner       = arrStoredProcedureName[0].ToUpper();
          packagename = arrStoredProcedureName[1].ToUpper();
          spname      = arrStoredProcedureName[2].ToUpper();
          break;
        default:
          spname      = arrStoredProcedureName[0].ToUpper();
          break;
      }
    }
  }
}
