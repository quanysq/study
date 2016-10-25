using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.DAO;
using DBHelper.Model;
using DBHelper.Util;
using System.Data;
using DBHelper.Enums;
using DBHelper.Common;

namespace DBHelper.BLL
{
  class InternalMethodBLL
  {
    public DataTable InternalMethodList(string DatabaseID, string ClassifyID, string Keyword)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.InternalMethodList(DatabaseID, ClassifyID, Keyword);
      return dt;
    }

    public int InternalMethodSave(InternalMethodModel internalmethodmodel)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.InternalMethodSave(internalmethodmodel);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodStatementList(string MethodID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.MethodStatementList(MethodID);
      return dt;
    }

    public int MethodStatementSaveMain(MethodStatementModel methodstatementmodel)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodStatementSaveMain(methodstatementmodel);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public bool MethodStatementUpdateStatement(MethodStatementModel methodstatementmodel)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodStatementUpdateStatement(methodstatementmodel);
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

    public bool MethodStatementUpdateStatus(string FieldName, string FieldValue, string StatementID)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodStatementUpdateStatus(FieldName, FieldValue, StatementID);
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

    public DataTable MethodStatementDisplay(string StatementID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.MethodStatementDisplay(StatementID);
      return dt;
    }

    public bool MethodStatementMove(string StatementID, string IsMoveUp)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodStatementMove(StatementID, IsMoveUp);
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

    public bool MethodStatementDelete(string StatementID)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodStatementDelete(StatementID);
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

    public int MethodStatementConditionalSave(MethodStatementConditionalModel methodstatementconditionalmodel)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodStatementConditionalSave(methodstatementconditionalmodel);
        return result;
      }
      catch
      {
        throw;
      }
    }

    public DataTable MethodStatementConditionalDisplay(string StatementID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.MethodStatementConditionalDisplay(StatementID);
      return dt;
    }

    public DataTable InternalMethodQuery(string MethodID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.InternalMethodQuery(MethodID);
      return dt;
    }

    public DataTable InternalMethodDDLSP(string MethodID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.InternalMethodDDLSP(MethodID);
      return dt;
    }

    public string MethodParameterAllStatement(string MethodID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.MethodParameterAllStatement(MethodID);
      if (dt.Rows.Count == 0) return "";
      StringBuilder FullStatement = new StringBuilder(1024);
      foreach (DataRow dr in dt.Rows)
      {
        FullStatement.AppendLine(CommonUtil.TranNull<string>(dr["Statement"]));
      }
      return FullStatement.ToString();
    }

    public DataTable MethodParameterList(string MethodID)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.MethodParameterList(MethodID);
      return dt;
    }

    public bool MethodParameterSaveMain(MethodParameterModel methodparametermodel)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodParameterSaveMain(methodparametermodel);
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

    public bool MethodParameterUpdate(string FieldName, string FieldValue, string ParameterID)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodParameterUpdate(FieldName, FieldValue, ParameterID);
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

    public bool MethodParameterDelete(string ParameterID)
    {
      try
      {
        InternalMethodDao internalmethoddao = new InternalMethodDao();
        int result                          = internalmethoddao.MethodParameterDelete(ParameterID);
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

    public List<string> MethodParameterSP(string StoredProcedureName)
    {
      List<string> StoredProcedureParameterList = new List<string>();
      InternalMethodDao internalmethoddao       = new InternalMethodDao();
      DataTable dt                              = internalmethoddao.MethodParameterSP(StoredProcedureName);
      if (dt.Rows.Count == 0) return StoredProcedureParameterList;
      foreach (DataRow dr in dt.Rows)
      {
        StoredProcedureParameterList.Add(CommonUtil.TranNull<string>(dr["name"]));
      }
      return StoredProcedureParameterList;
    }

    public void MethodParameterMain(string MethodID, ref string StoredProcedureName, ref MethodType MethodType, ref FunctionType FunctionType)
    {
      InternalMethodDao internalmethoddao = new InternalMethodDao();
      DataTable dt                        = internalmethoddao.MethodParameterMain(MethodID);
      if (dt.Rows.Count == 0) return;
      StoredProcedureName                 = CommonUtil.TranNull<string>(dt.Rows[0]["MethodName"]);
      MethodType                          = EnumManager<MethodType>.EnumName2Enum(dt.Rows[0]["MethodType"]);
      FunctionType                        = EnumManager<FunctionType>.EnumName2Enum(dt.Rows[0]["FunctionType"]);
    }
  }
}
