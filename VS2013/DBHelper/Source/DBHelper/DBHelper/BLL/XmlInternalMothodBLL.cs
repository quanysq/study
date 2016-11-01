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
using DBHelper.Generate;

namespace DBHelper.BLL
{
  class XmlInternalMothodBLL
  {
    public void GetInternalMethodBaseInfo(int MethodID, ref XmlInternalMethodModel XIMM)
    {
      XmlInternalMothodDao xmlinternalmothoddao = new XmlInternalMothodDao();
      DataTable result                          = xmlinternalmothoddao.GetInternalMethodBaseInfo(MethodID.ToString());

      if (result.Rows.Count == 0) return;
      
      XIMM.MethodID                       = MethodID;
      XIMM.DBType                         = Common.Common.OperateDbType;
      XIMM.ConnectionStr                  = Common.Common.OperateDbConnection;
      XIMM.MethodName                     = CommonUtil.TranNull<string>(result.Rows[0]["MethodName"]);
      XIMM.MethodDesc                     = CommonUtil.TranNull<string>(result.Rows[0]["MethodDesc"]);
      XIMM.MethodType                     = EnumManager<MethodType>.EnumName2Enum(result.Rows[0]["MethodType"]);
      XIMM.FunctionType                   = EnumManager<FunctionType>.EnumName2Enum(result.Rows[0]["FunctionType"]);
      XIMM.SuccessMsg                     = CommonUtil.TranNull<string>(result.Rows[0]["SuccessMsg"]);
      XIMM.FailMsg                        = CommonUtil.TranNull<string>(result.Rows[0]["FailMsg"]);
      XIMM.MethodStatementList            = new List<XmlMethodStatementModel>();
      XIMM.MethodParameterList            = new List<XmlMethodParameterModel>();
    }

    public void GetMethodStatementInfo(int MethodID, ref XmlInternalMethodModel XIMM)
    {
      XmlInternalMothodDao xmlinternalmothoddao = new XmlInternalMothodDao();
      DataTable result                          = xmlinternalmothoddao.GetMethodStatementInfo(MethodID.ToString());

      if (result.Rows.Count == 0) return;

      foreach (DataRow dr in result.Rows)
      {
        XmlMethodStatementModel XMSM  = new XmlMethodStatementModel();
        XMSM.OrderID                  = CommonUtil.TranNull<int>(dr["OrderID"]);
        XMSM.Tag                      = CommonUtil.TranNull<string>(dr["Tag"]);
        XMSM.Statement                = CommonUtil.TranNull<string>(dr["Statement"]);
        XMSM.IsOrderby                = CommonUtil.TranNull<bool>(dr["IsOrderby"]);
        XMSM.HasConditional           = CommonUtil.TranNull<bool>(dr["HasConditional"]);
        XMSM.StatementConditionalList = new List<XmlMethodStatementConditionalModel>();

        string StatementID            = CommonUtil.TranNull<string>(dr["StatementID"]);
        DataTable ConditionalResult   = xmlinternalmothoddao.GetMethodStatementConditionalInfo(StatementID);
        foreach (DataRow ConditionalDr in ConditionalResult.Rows)
        {
          XmlMethodStatementConditionalModel XMSCM = new XmlMethodStatementConditionalModel();
          XMSCM.ConditionType                      = EnumManager<ConditionType>.EnumName2Enum(ConditionalDr["ConditionType"]);
          XMSCM.ParameterName                      = CommonUtil.TranNull<string>(ConditionalDr["ParameterName"]);
          XMSCM.ExpectBehavior                     = EnumManager<BehaviorType>.EnumName2Enum(ConditionalDr["ExpectBehavior"]);
          XMSCM.CompareValue                       = CommonUtil.TranNull<string>(ConditionalDr["CompareValue"]);
          XMSM.StatementConditionalList.Add(XMSCM);
        }

        XIMM.MethodStatementList.Add(XMSM);
      }
    }

    public void GetMethodParameterInfo(int MethodID, ref XmlInternalMethodModel XIMM)
    {
      XmlInternalMothodDao xmlinternalmothoddao = new XmlInternalMothodDao();
      DataTable result                          = xmlinternalmothoddao.GetMethodParameterInfo(MethodID.ToString());

      if (result.Rows.Count == 0) return;

      foreach (DataRow dr in result.Rows)
      {
        XmlMethodParameterModel XMPM = new XmlMethodParameterModel();
        XMPM.ParameterName           = CommonUtil.TranNull<string>(dr["ParameterName"]);
        XMPM.ParameterDesc           = CommonUtil.TranNull<string>(dr["ParameterDesc"]);
        XMPM.ParameterDataType       = EnumManager<ParameterDataType>.EnumName2Enum(dr["ParameterDataType"]);
        XMPM.ParameterDirection      = EnumManager<DBHelper.Enums.ParameterDirection>.EnumName2Enum(dr["ParameterDirection"]);
        XMPM.ParameterValidateType   = EnumManager<ParameterValidateType>.EnumName2Enum(dr["ParameterValidateType"]);
        XMPM.ValidateValue           = CommonUtil.TranNull<string>(dr["ValidateValue"]);
        XIMM.MethodParameterList.Add(XMPM);
      }
    }
  }
}
