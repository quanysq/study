using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.DAO;
using DBHelper.Model;
using System.Data;
using DBHelper.Util;

namespace DBHelper.BLL
{
  class BusinessMethodBLL
  {
    public DataTable BusinessMethodList(string DatabaseID, string ClassifyID, string Keyword)
    {
      BusinessMethodDao businessmethoddao = new BusinessMethodDao();
      DataTable dt                        = businessmethoddao.BusinessMethodList(DatabaseID, ClassifyID, Keyword);
      return dt;
    }

    public bool BusinessMethodDelete(string BMCode)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        int result                          = businessmethoddao.BusinessMethodDelete(BMCode);
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

    public string BusinessMethodCode()
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        string result                          = businessmethoddao.BusinessMethodCode();
        return result;
      }
      catch
      {
        throw;
      }
    }

    public BusinessMethodModel BusinessMethodQuery(string BMCode)
    {
      BusinessMethodDao businessmethoddao = new BusinessMethodDao();
      DataTable dt                        = businessmethoddao.BusinessMethodQuery(BMCode);
      if (dt.Rows.Count == 0) return null;
      BusinessMethodModel businessmethodmodel = new BusinessMethodModel()
      {
        BMCode       = CommonUtil.TranNull<string>(dt.Rows[0]["BMCode"]),
        BMDesc       = CommonUtil.TranNull<string>(dt.Rows[0]["BMDesc"]),
        FunctionType = CommonUtil.TranNull<string>(dt.Rows[0]["FunctionType"])
      };
      return businessmethodmodel;
    }

    public string BusinessMethodSave(BusinessMethodModel businessmethodmodel)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        string result                       = businessmethoddao.BusinessMethodSave(businessmethodmodel);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable BusinessMethodAllIM(string DatabaseID, string Keyword)
    {
      BusinessMethodDao businessmethoddao = new BusinessMethodDao();
      DataTable dt                        = businessmethoddao.BusinessMethodAllIM(DatabaseID, Keyword);
      return dt;
    }

    public DataTable BusinessMethodIMSelected(string BMCode)
    {
      BusinessMethodDao businessmethoddao = new BusinessMethodDao();
      DataTable dt                        = businessmethoddao.BusinessMethodIMSelected(BMCode);
      return dt;
    }

    public bool BusinessMethodIMSave(BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        int result                          = businessmethoddao.BusinessMethodIMSave(businessmethod_internalmethodsmodel);
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

    public bool BusinessMethodIMDelete(BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        int result                          = businessmethoddao.BusinessMethodIMDelete(businessmethod_internalmethodsmodel);
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

    public bool BusinessMethodIMMove(BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel, string IsMoveUp)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        int result                          = businessmethoddao.BusinessMethodIMMove(businessmethod_internalmethodsmodel, IsMoveUp);
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

    public DataTable BusinessMethodPRSave(BusinessMethod_ParameterRelationsModel businessmethod_parameterrelationsmodel)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        DataTable dt                        = businessmethoddao.BusinessMethodPRSave(businessmethod_parameterrelationsmodel);
        return dt;
      }
      catch
      {
        throw;
      }
    }

    public bool BusinessMethodPRUpdate(BusinessMethod_ParameterRelationsModel businessmethod_parameterrelationsmodel)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        int result                          = businessmethoddao.BusinessMethodPRUpdate(businessmethod_parameterrelationsmodel);
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

    public DataTable BusinessMethodPMList(string BMCode)
    {
      BusinessMethodDao businessmethoddao = new BusinessMethodDao();
      DataTable dt                        = businessmethoddao.BusinessMethodPMList(BMCode);
      return dt;
    }

    public DataTable BusinessMethodPMSave(string BMCode)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        DataTable dt                        = businessmethoddao.BusinessMethodPMSave(BMCode);
        return dt;
      }
      catch
      {
        throw;
      }
    }

    public bool BusinessMethodPMUpdate(string FieldName, string FieldValue, string ParameterID)
    {
      try
      {
        BusinessMethodDao businessmethoddao = new BusinessMethodDao();
        int result                          = businessmethoddao.BusinessMethodPMUpdate(FieldName, FieldValue, ParameterID);
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
