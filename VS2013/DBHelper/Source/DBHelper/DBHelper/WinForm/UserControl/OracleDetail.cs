using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using DBHelper.Model;

namespace DBHelper
{
  public partial class OracleDetail : DataBaseDetailInfoUC
  {
    public OracleDetail()
    {
      InitializeComponent();
      this.DatabaseDetailInfo = new DatabaseDetailInfoModel();

      this.DBHost_Oracle.TextChanged       += TextChanged;
      this.DBUser_Oracle.TextChanged       += TextChanged;
      this.DBPwd_Oracle.TextChanged        += TextChanged;
      this.Port_Oracle.TextChanged         += TextChanged;
      this.Service_Name_Oracle.TextChanged += TextChanged;
    }

    public override void SetDataBaseDetailInfo2Propety()
    {
      //DBHelperMessage.Info("开始设置");
      this.DatabaseDetailInfo.DBHost       = this.DBHost_Oracle.Text.Trim();
      this.DatabaseDetailInfo.DBUser       = this.DBUser_Oracle.Text.Trim();
      this.DatabaseDetailInfo.DBPwd        = this.DBPwd_Oracle.Text.Trim();
      this.DatabaseDetailInfo.Port         = this.Port_Oracle.Text.Trim();
      this.DatabaseDetailInfo.Service_Name = this.Service_Name_Oracle.Text.Trim();
    }

    public override string GetConnectionStr()
    {
      string ConnectionStrTmep = ConfigurationManager.AppSettings["OracleConnection"];
      string ConnectionStr = string.Format(ConnectionStrTmep,
        this.DatabaseDetailInfo.DBHost,
        this.DatabaseDetailInfo.Port,
        this.DatabaseDetailInfo.Service_Name,
        this.DatabaseDetailInfo.DBUser,
        this.DatabaseDetailInfo.DBPwd);
      return ConnectionStr;
    }

    public override bool TestConnection(string ConnectionStr)
    {
      OracleConnection cn = null;
      try
      {
        cn = new OracleConnection(ConnectionStr);
        cn.Open();
        return true;
      }
      catch (InvalidOperationException ex)
      {
        return false;
      }
      catch (OracleException ex)
      {
        return false;
      }
      catch (System.Configuration.ConfigurationErrorsException ex)
      {
        return false;
      }
      catch (Exception ex)
      {
        return false;
      }
      finally
      {
        if (cn != null) cn.Close();
      }
    }
  }
}
