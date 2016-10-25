using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Model;
using DBHelper.Common;
using System.Data;

namespace DBHelper.DAO
{
  class MethodClassifyDao
  {
    public int InsertMethodClassify(MethodClassifyModel objMethodClassify)
    {
      try
      {
        string[] PramerValues = 
        { 
          objMethodClassify.DatabaseID.ToString(),
          objMethodClassify.ClassifyName,
          objMethodClassify.ClassifyType.ToString()
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodClassifyAddParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodClassifyList(string ClassifyType, string DatabaseID)
    {
      string[] PramerValues = { ClassifyType, DatabaseID };
      DataTable result      = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodClassifyListFormat.xml", PramerValues, ParameType.Format);
      return result;
    }

    public int MethodClassifyDelete(string ClassifyID)
    {
      try
      {
        string[] PramerValues = { ClassifyID };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodClassifyDeleteFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }
  }
}
