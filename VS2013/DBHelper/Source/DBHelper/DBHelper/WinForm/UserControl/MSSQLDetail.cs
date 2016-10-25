using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBHelper.Common;
using System.Configuration;
using DBHelper.Model;
namespace DBHelper
{
  public partial class MSSQLDetail : DataBaseDetailInfoUC
  {
    public MSSQLDetail()
    {
      InitializeComponent();
      this.DatabaseDetailInfo = new DatabaseDetailInfoModel();

      this.DBHost_MSSQL.TextChanged  += TextChanged;
      this.DBUser_MSSQL.TextChanged  += TextChanged;
      this.DBPwd_MSSQL.TextChanged   += TextChanged;
      this.Catalog_MSSQL.TextChanged += TextChanged;
    }

    public override void SetDataBaseDetailInfo2Propety()
    {
      //DBHelperMessage.Info("开始设置");
      
      this.DatabaseDetailInfo.DBHost             = this.DBHost_MSSQL.Text.Trim();
      this.DatabaseDetailInfo.DBUser             = this.DBUser_MSSQL.Text.Trim();
      this.DatabaseDetailInfo.DBPwd              = this.DBPwd_MSSQL.Text.Trim();
      this.DatabaseDetailInfo.Pooling            = "true";
      this.DatabaseDetailInfo.MinPoolSize        = "5";
      this.DatabaseDetailInfo.MaxPoolSize        = "50";
      this.DatabaseDetailInfo.ConnectionLifetime = "30";
      this.DatabaseDetailInfo.Catalog            = this.Catalog_MSSQL.Text.Trim();
    }

    public override string GetConnectionStr()
    {
      string ConnectionStrTmep = ConfigurationManager.AppSettings["MSSQLConnection"];
      string ConnectionStr = string.Format(ConnectionStrTmep,
        this.DatabaseDetailInfo.DBHost,
        this.DatabaseDetailInfo.Catalog,
        this.DatabaseDetailInfo.DBUser,
        this.DatabaseDetailInfo.DBPwd,
        this.DatabaseDetailInfo.MaxPoolSize,
        this.DatabaseDetailInfo.MinPoolSize,
        this.DatabaseDetailInfo.Pooling,
        this.DatabaseDetailInfo.ConnectionLifetime);
      return ConnectionStr;
    }

    public override bool TestConnection(string ConnectionStr)
    {
      SqlConnection cn = null;
      try
      {
        cn = new SqlConnection(ConnectionStr);
        cn.Open();
        return true;
      }
      catch (InvalidOperationException ex)
      {
        //TODO hanld log
        return false;
      }
      catch (SqlException ex)
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
