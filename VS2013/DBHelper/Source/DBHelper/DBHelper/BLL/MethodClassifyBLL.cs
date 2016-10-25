using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Common;
using DBHelper.DAO;
using DBHelper.Model;
using System.Data;

namespace DBHelper.BLL
{
  class MethodClassifyBLL
  {
    public bool InsertMethodClassify(MethodClassifyModel objMethodClassify)
    {
      try
      {
        MethodClassifyDao methodclassifydao = new MethodClassifyDao();
        int result                          = methodclassifydao.InsertMethodClassify(objMethodClassify);
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

    public DataTable MethodClassifyList(string ClassifyType, string DatabaseID)
    {
      MethodClassifyDao methodclassifydao = new MethodClassifyDao();
      DataTable result                    = methodclassifydao.MethodClassifyList(ClassifyType, DatabaseID);
      return result;
    }

    public bool MethodClassifyDelete(string ClassifyID)
    {
      try
      {
        MethodClassifyDao methodclassifydao = new MethodClassifyDao();
        int result                          = methodclassifydao.MethodClassifyDelete(ClassifyID);
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
