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
  class InternalMethodDao
  {
    public DataTable InternalMethodList(string DatabaseID, string ClassifyID, string Keyword)
    {
      string[] PramerValues = { DatabaseID, ClassifyID, Keyword };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("InternalMethodListFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int InternalMethodSave(InternalMethodModel internalmethodmodel)
    {
      try
      {
        string[] PramerValues = 
        { 
          internalmethodmodel.MethodID.ToString(),
          internalmethodmodel.DatabaseID.ToString(),
          internalmethodmodel.ClassifyID.ToString(),
          internalmethodmodel.MethodName,
          internalmethodmodel.MethodDesc,
          internalmethodmodel.MethodType,
          internalmethodmodel.FunctionType,
          internalmethodmodel.SuccessMsg,
          internalmethodmodel.FailMsg,
          UserInfoModel.Instance.UserName,
          internalmethodmodel.UpdateReson
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("InternalMethodSaveParameterSingle.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodStatementList(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodStatementListFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int MethodStatementSaveMain(MethodStatementModel methodstatementmodel)
    {
      try
      {
        string[] PramerValues = 
        { 
          methodstatementmodel.StatementID.ToString(),
          methodstatementmodel.MethodID.ToString(),
          methodstatementmodel.Tag
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodStatementSaveMainFormatSingle.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int MethodStatementUpdateStatement(MethodStatementModel methodstatementmodel)
    {
      try
      {
        string[] PramerValues = 
        { 
          methodstatementmodel.Statement,
          methodstatementmodel.StatementID.ToString()
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodStatementUpdateStatementParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int MethodStatementUpdateStatus(string FieldName, string FieldValue, string StatementID)
    {
      try
      {
        string[] PramerValues = { FieldName, FieldValue, StatementID };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodStatementUpdateStatusFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodStatementDisplay(string StatementID)
    {
      string[] PramerValues = { StatementID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodStatementDisplayFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int MethodStatementDelete(string StatementID)
    {
      try
      {
        string[] PramerValues = { StatementID };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodStatementDeleteParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int MethodStatementConditionalSave(MethodStatementConditionalModel methodstatementconditionalmodel)
    {
      try
      {
        string[] PramerValues = 
        { 
          methodstatementconditionalmodel.ConditionalID.ToString(),
          methodstatementconditionalmodel.StatementID.ToString(),
          methodstatementconditionalmodel.MethodID.ToString(),
          methodstatementconditionalmodel.ConditionType,
          methodstatementconditionalmodel.ParameterName,
          methodstatementconditionalmodel.ExpectBehavior,
          methodstatementconditionalmodel.CompareValue
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodStatementConditionalSaveParameterSingle.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodStatementConditionalDisplay(string StatementID)
    {
      string[] PramerValues = { StatementID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodStatementConditionalDisplayFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int MethodStatementMove(string StatementID, string IsMoveUp)
    {
      try
      {
        string[] PramerValues = { StatementID, IsMoveUp };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodStatementMoveFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable InternalMethodQuery(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("InternalMethodQueryFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable InternalMethodDDLSP(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("InternalMethodDDLSPFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable MethodParameterAllStatement(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodParameterAllStatementFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable MethodParameterList(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodParameterListFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public int MethodParameterSaveMain(MethodParameterModel methodparametermodel)
    {
      try
      {
        string[] PramerValues = 
        {
          methodparametermodel.ParameterID.ToString(),
          methodparametermodel.MethodID.ToString(),
          methodparametermodel.ParameterName,
          methodparametermodel.ParameterDataType,
          methodparametermodel.ParameterDirection,
          methodparametermodel.ParameterValidateType
        };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodParameterSaveMainParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int MethodParameterUpdate(string FieldName, string FieldValue, string ParameterID)
    {
      try
      {
        string[] PramerValues = { FieldName, FieldValue, ParameterID };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodParameterUpdateFormat.xml", PramerValues, ParameType.Format);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public int MethodParameterDelete(string ParameterID)
    {
      try
      {
        string[] PramerValues = { ParameterID };
        int result = DaoXmlHelper.ExecuteSQLSatement<int>("MethodParameterDeleteParameter.xml", PramerValues, ParameType.Parames);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodParameterSP(string StoredProcedureName)
    {
      string[] PramerValues = { StoredProcedureName };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodParameterSPFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable MethodParameterMain(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt = DaoXmlHelper.ExecuteSQLSatement<DataTable>("MethodParameterMainFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }
  }
}
