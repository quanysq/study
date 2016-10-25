using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.DAO;
using DBHelper.Model;
using DBHelper.Util;

namespace DBHelper.BLL
{
  class UserInfoBLL
  {
    public static bool isAdministrator
    {
      get
      {
        return UserInfoModel.Instance.Usercode.Equals("Admin", StringComparison.OrdinalIgnoreCase);
      }
    }

    public bool Login(string Usercode, string Pwd)
    {
      UserInfoDao userinfodao = new UserInfoDao();
      DataTable dt            = userinfodao.Login(Usercode, Pwd);
      if (dt.Rows.Count == 0)
      {
        return false;
      }
      else
      {
        UserInfoModel.Instance.UserID        = CommonUtil.TranNull<int>(dt.Rows[0]["UserID"]);
        UserInfoModel.Instance.Usercode      = CommonUtil.TranNull<string>(dt.Rows[0]["Usercode"]);
        UserInfoModel.Instance.UserName      = CommonUtil.TranNull<string>(dt.Rows[0]["UserName"]);
        UserInfoModel.Instance.Pwd           = CommonUtil.TranNull<string>(dt.Rows[0]["Pwd"]);
        UserInfoModel.Instance.IsAddSelf     = CommonUtil.TranNull<int>(dt.Rows[0]["IsAddSelf"]);
        UserInfoModel.Instance.IsEditSelf    = CommonUtil.TranNull<int>(dt.Rows[0]["IsEditSelf"]);
        UserInfoModel.Instance.IsDeleteSelf  = CommonUtil.TranNull<int>(dt.Rows[0]["IsDeleteSelf"]);
        UserInfoModel.Instance.IsEditOther   = CommonUtil.TranNull<int>(dt.Rows[0]["IsEditOther"]);
        UserInfoModel.Instance.IsDeleteOther = CommonUtil.TranNull<int>(dt.Rows[0]["IsDeleteOther"]);
        return true;
      }
    }

    public static bool CheckLogin()
    {
      return !string.IsNullOrEmpty(UserInfoModel.Instance.Usercode);
    }

    public static bool CheckChooseDatabase()
    {
      UserInfoDao userinfodao = new UserInfoDao();
      int result = userinfodao.CheckChooseDatabase(UserInfoModel.Instance.UserID.ToString());
      if (result == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public bool ModifyPwd(UserInfoModel objUserInfo)
    {
      try
      {
        UserInfoDao userinfodao = new UserInfoDao();
        int result = userinfodao.ModifyPwd(objUserInfo);
        if (result == 0)
        {
          return false;
        }
        else
        {
          return true;
        }
      }
      catch
      {
        throw;
      }
    }

    public static void GetChooseDatabase()
    {
      UserInfoDao userinfodao           = new UserInfoDao();
      DataTable dt                      = userinfodao.GetChooseDatabase(UserInfoModel.Instance.UserID.ToString());
      if (dt.Rows.Count == 0) return;
      Common.Common.OperateDbID         = CommonUtil.TranNull<int>(dt.Rows[0]["DatabaseID"]);
      Common.Common.OperateDbConnection = CommonUtil.TranNull<string>(dt.Rows[0]["ConnectionStr"]);
    }

    public DataTable UserInfoList()
    {
      UserInfoDao userinfodao = new UserInfoDao();
      DataTable dt            = userinfodao.UserInfoList();
      return dt;
    }

    public bool UserEdit(string FieldName, string FieldValue, string UserID)
    {
      try
      {
        UserInfoDao userinfodao = new UserInfoDao();
        int result = userinfodao.UserEdit(FieldName, FieldValue, UserID);
        if (result == 0)
        {
          return false;
        }
        else
        {
          return true;
        }
      }
      catch
      {
        throw;
      }
    }

    public bool UserAdd(string Usercode, string Username)
    {
      try
      {
        UserInfoDao userinfodao = new UserInfoDao();
        int result = userinfodao.UserAdd(Usercode, Username);
        if (result == 0)
        {
          return false;
        }
        else
        {
          return true;
        }
      }
      catch
      {
        throw;
      }
    }
  }
}
