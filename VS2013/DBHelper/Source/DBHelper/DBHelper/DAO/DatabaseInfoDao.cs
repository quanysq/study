using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Model;

namespace DBHelper.DAO
{
  class DatabaseInfoDao
  {
    public int InsertDatabaseInfo(DatabaseInfoModel dbinfoobj, DatabaseDetailInfoModel dbdeailinfoobj)
    {
      try
      {
        string[] PramerValues = 
        { 
            dbinfoobj.UserID.ToString(), 
            dbinfoobj.DBType, 
            dbinfoobj.ConnectionName, 
            dbinfoobj.ConnectionStr, 
            dbdeailinfoobj.DBHost,
            dbdeailinfoobj.DBUser,
            dbdeailinfoobj.DBPwd,
            dbdeailinfoobj.Pooling,
            dbdeailinfoobj.MinPoolSize,
            dbdeailinfoobj.MaxPoolSize,
            dbdeailinfoobj.ConnectionLifetime,
            dbdeailinfoobj.Catalog,
            dbdeailinfoobj.Port,
            dbdeailinfoobj.Service_Name
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("DatabaseInfoAddParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }
  }
}
