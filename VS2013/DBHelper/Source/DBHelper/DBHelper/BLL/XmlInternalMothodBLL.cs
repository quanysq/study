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
  }
}
