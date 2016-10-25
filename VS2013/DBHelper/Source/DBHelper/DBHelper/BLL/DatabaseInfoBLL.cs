using DBHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.DAO;

namespace DBHelper.BLL
{
  public class DatabaseInfoBLL
  {
    public bool InsertDatabaseInfo(DatabaseInfoModel dbinfoobj, DatabaseDetailInfoModel dbdeailinfoobj)
    {
      try
      {
        DatabaseInfoDao databaseinfodao = new DatabaseInfoDao();
        int result = databaseinfodao.InsertDatabaseInfo(dbinfoobj, dbdeailinfoobj);
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
