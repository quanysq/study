using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Common;
using DBHelper.Enums;
using DBHelper.Model;
using DBHelper.Util;
using DBHelper.BLL;

namespace DBHelper
{
  public partial class ChooseDatabase : Form
  {
    private DBType CurrentDBType;
    private int HasTest = 0;                    //0:未测试；1: 测试成功；2测试失败
    private DataBaseDetailInfoUC UC = null;

    public ChooseDatabase()
    {
      InitializeComponent();
    }

    private void ChooseDatabase_Load(object sender, EventArgs e)
    {
      BindDataBaseType();
    }

    private void BindDataBaseType()
    {
      EnumManager<DBType>.Bind2ComboBox(DataBaseType);
    }

    private void DataBaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBoxItemModel CurrentItem = DataBaseType.SelectedItem as ComboBoxItemModel;
      CurrentDBType                 = (DBType)CommonUtil.TranNull<int>(CurrentItem.Value);
      RemoveDataBaseDetailInfoUC();
      AddDataBaseDetailInfoUC();
    }

    private void AddDataBaseDetailInfoUC()
    {
      if (CurrentDBType == DBType.MsSqlServer)
      {
        UC      = new MSSQLDetail();
        UC.Name = "MSSQLCtr";
      }
      else
      {
        UC      = new OracleDetail();
        UC.Name = "OracleCtr";
      }
      UC.TabIndex = 2;
      UC.Location = new Point(47, 113);
      UC.ValueChanged += ValueChanged;
      this.Controls.Add(UC);
    }
    
    private void RemoveDataBaseDetailInfoUC()
    {
      string DataBaseDetailInfoUCName = CurrentDBType == DBType.MsSqlServer ? "OracleCtr" : "MSSQLCtr";
      this.Controls.RemoveByKey(DataBaseDetailInfoUCName);
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      UC.SetDataBaseDetailInfo2Propety();
      string ConnectionStr = UC.GetConnectionStr();
      bool TestResult      = UC.TestConnection(ConnectionStr);
      if (TestResult)
      {
        lblTestResult.Text = "测试连接成功！";
        Common.Common.OperateDbConnection = ConnectionStr;
        HasTest = 1;
      }
      else
      {
        lblTestResult.Text = "测试连接失败！请从日志中查看具体出错信息。";
        HasTest = 2;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (HasTest == 0)
      {
        btnTest_Click(null, null);
      }

      if (HasTest == 1)
      {
        try
        {
          DatabaseInfoModel dbinfoobj             = new DatabaseInfoModel();
          DatabaseDetailInfoModel dbdetailinfoobj = new DatabaseDetailInfoModel();
          dbinfoobj.UserID                        = UserInfoModel.Instance.UserID;
          dbinfoobj.DBType                        = CurrentDBType.ToString();
          dbinfoobj.ConnectionName                = ConnectionName.Text.Trim();
          dbinfoobj.ConnectionStr                 = Common.Common.OperateDbConnection;
          dbdetailinfoobj.DBHost                  = UC.DatabaseDetailInfo.DBHost;
          dbdetailinfoobj.DBUser                  = UC.DatabaseDetailInfo.DBUser;
          dbdetailinfoobj.DBPwd                   = UC.DatabaseDetailInfo.DBPwd;
          dbdetailinfoobj.Pooling                 = UC.DatabaseDetailInfo.Pooling;
          dbdetailinfoobj.MinPoolSize             = UC.DatabaseDetailInfo.MinPoolSize;
          dbdetailinfoobj.MaxPoolSize             = UC.DatabaseDetailInfo.MaxPoolSize;
          dbdetailinfoobj.ConnectionLifetime      = UC.DatabaseDetailInfo.ConnectionLifetime;
          dbdetailinfoobj.Catalog                 = UC.DatabaseDetailInfo.Catalog;
          dbdetailinfoobj.Port                    = UC.DatabaseDetailInfo.Port;
          dbdetailinfoobj.Service_Name            = UC.DatabaseDetailInfo.Service_Name;
          DatabaseInfoBLL databaseinfobll         = new DatabaseInfoBLL();
          bool result                             = databaseinfobll.InsertDatabaseInfo(dbinfoobj, dbdetailinfoobj);
          if (result)
          {
            UserInfoBLL.GetChooseDatabase();
            if (this.MdiParent != null)
            {
              DBHelperMessage.Info("您的数据库已经改变， 需要重新加载元素方法和业务方法！");
              MainForm MainFrm = this.MdiParent as MainForm;
              MainFrm.CloseAllForm();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
          }
        }
        catch (Exception ex)
        {
          DBHelperMessage.Error(ex);
        }
      }
      else if (HasTest == 2)
      {
        return;
      }
    }

    private void ValueChanged(object sender, EventArgs e)
    {
      HasTest            = 0;
      lblTestResult.Text = "";
    }
  }
}
