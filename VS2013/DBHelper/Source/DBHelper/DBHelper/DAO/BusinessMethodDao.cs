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
  class BusinessMethodDao
  {
    public DataTable BusinessMethodList(string DatabaseID, string ClassifyID, string Keyword)
    {
      string[] PramerValues = { DatabaseID, ClassifyID, Keyword };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodListFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int BusinessMethodDelete(string BMCode)
    {
      try
      {
        string[] PramerValues = { BMCode };
        int result            = DaoXmlHelper.ExecuteSQLSatement<int>("BusinessMethodDeleteParameter.xml", PramerValues, ParameType.Parames);
        return result;
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
        string result = DaoXmlHelper.ExecuteSQLSatement<string>("BusinessMethodCodeNormal.xml", null, ParameType.Normal);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable BusinessMethodQuery(string BMCode)
    {
      string[] PramerValues = { BMCode };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodQueryFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public string BusinessMethodSave(BusinessMethodModel businessmethodmodel)
    {
      try
      {
        string[] PramerValues = 
        {
          businessmethodmodel.BMCode,
          businessmethodmodel.DatabaseID.ToString(),
          businessmethodmodel.ClassifyID.ToString(),
          businessmethodmodel.BMDesc,
          businessmethodmodel.FunctionType,
          UserInfoModel.Instance.UserName,
          businessmethodmodel.UpdateReson
        };
        string result = DaoXmlHelper.ExecuteSQLSatement<string>("BusinessMethodSaveFormatSingle.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable BusinessMethodAllIM(string DatabaseID, string Keyword)
    {
      string[] PramerValues = { DatabaseID, Keyword };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodAllIMFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable BusinessMethodIMSelected(string BMCode)
    {
      try
      {
        string[] PramerValues = { BMCode };
        DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodIMSelectedFormat.xml", PramerValues, ParameType.Format);
        return dt;
      }
      catch
      {
        throw;
      }
    }

    public int BusinessMethodIMSave(BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel)
    {
      try
      {
        string[] PramerValues = 
        {
          businessmethod_internalmethodsmodel.BMCode,
          businessmethod_internalmethodsmodel.MethodID.ToString()
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("BusinessMethodIMSaveFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int BusinessMethodIMDelete(BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel)
    {
      try
      {
        string[] PramerValues = 
        {
          businessmethod_internalmethodsmodel.BMCode,
          businessmethod_internalmethodsmodel.MethodID.ToString()
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("BusinessMethodIMDeleteParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int BusinessMethodIMMove(BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel, string IsMoveUp)
    {
      try
      {
        string[] PramerValues = 
        {
          businessmethod_internalmethodsmodel.BMCode,
          businessmethod_internalmethodsmodel.MethodID.ToString(),
          IsMoveUp
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("BusinessMethodIMMoveFormat.xml", PramerValues, ParameType.Format);
        return result;
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
        string[] PramerValues = 
        {
          businessmethod_parameterrelationsmodel.BMCode,
          businessmethod_parameterrelationsmodel.MethodID.ToString()
        };
        DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodPRSaveFormat.xml", PramerValues, ParameType.Format);
        return dt;
      }
      catch
      {
        throw;
      }
    }

    public int BusinessMethodPRUpdate(BusinessMethod_ParameterRelationsModel businessmethod_parameterrelationsmodel)
    {
      try
      {
        string[] PramerValues = 
        {
          businessmethod_parameterrelationsmodel.BMCode,
          businessmethod_parameterrelationsmodel.MethodID.ToString(),
          businessmethod_parameterrelationsmodel.MethodParameterName,
          businessmethod_parameterrelationsmodel.BMParameterName
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("BusinessMethodPRUpdateFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable BusinessMethodPMList(string BMCode)
    {
      string[] PramerValues = { BMCode };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodPMListFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable BusinessMethodPMSave(string BMCode)
    {
      try
      {
        string[] PramerValues = { BMCode };
        DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("BusinessMethodPMSaveFormat.xml", PramerValues, ParameType.Format);
        return dt;
      }
      catch
      {
        throw;
      }
    }

    public int BusinessMethodPMUpdate(string FieldName, string FieldValue, string ParameterID)
    {
      try
      {
        string[] PramerValues = { FieldName, FieldValue, ParameterID };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("BusinessMethodPMUpdateFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }
  }
}
