using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Model;

namespace DBHelper.DAO
{
  class UserInfoDao
  {
    public DataTable Login(string Usercode, string Pwd)
    {
      string[] PramerValues = { Usercode, Pwd };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("UserInfoLoginFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int CheckChooseDatabase(string UserID)
    {
      string[] PramerValues = { UserID };
      int result            = DaoXmlHelper.ExecuteSQLSatement<int>("DatabaseInfoChooseCheckSingle.xml", PramerValues, ParameType.Parames);
      return result;
    }

    public int ModifyPwd(UserInfoModel objUserInfo)
    {
      try
      {
        string[] PramerValues = 
        { 
          objUserInfo.UserID.ToString(), 
          objUserInfo.Pwd                       
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("UserInfoModifyPwdParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable GetChooseDatabase(string UserID)
    {
      string[] PramerValues = { UserID };
      DataTable result      = DaoXmlHelper.ExecuteSQLSatement<DataTable>("DatabaseInfoChooseGetParameter.xml", PramerValues, ParameType.Parames);
      return result;
    }

    public DataTable UserInfoList()
    {
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("UserInfoListNormal.xml", null, ParameType.Normal);
      return dt;
    }

    public int UserEdit(string FieldName, string FieldValue, string UserID)
    {
      try
      {
        string[] PramerValues = { FieldName, FieldValue, UserID };
        int result            = DaoXmlHelper.ExecuteSQLSatement<int>("UserInfoEditFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int UserAdd(string Usercode, string Username)
    {
      try
      {
        string[] PramerValues = { Usercode, Username };
        int result            = DaoXmlHelper.ExecuteSQLSatement<int>("UserInfoAddParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }
  }
}
