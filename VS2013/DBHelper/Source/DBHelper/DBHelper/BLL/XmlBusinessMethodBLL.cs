using DBHelper.Common;
using DBHelper.DAO;
using DBHelper.Enums;
using DBHelper.Generate;
using DBHelper.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.BLL
{
  class XmlBusinessMethodBLL
  {
    public void GetBusinessMethodBaseInfo(string BMCode, ref XmlBusinessMethodModel XBMM)
    {
      XmlBusinessMethodDao xmlbusinessmethoddao = new XmlBusinessMethodDao();
      DataTable result                          = xmlbusinessmethoddao.GetBusinessMethodBaseInfo(BMCode);

      if (result.Rows.Count == 0) return;
      
      XBMM.BMCode                = BMCode;
      XBMM.DBType                = Common.Common.OperateDbType;
      XBMM.ConnectionStr         = Common.Common.OperateDbConnection;
      XBMM.BMDesc                = CommonUtil.TranNull<string>(result.Rows[0]["BMDesc"]);
      XBMM.FunctionType          = EnumManager<FunctionType>.EnumName2Enum(result.Rows[0]["FunctionType"]);
      XBMM.InternalMethodList    = new List<XmlBusinessInternalMethodModel>();
      XBMM.BusinessParameterList = new List<XmlBusinessParameterModel>();
    }

    public void GetBusinessInternalMethodInfo(string BMCode, ref XmlBusinessMethodModel XBMM)
    {
      XmlBusinessMethodDao xmlbusinessmethoddao = new XmlBusinessMethodDao();
      DataTable result                          = xmlbusinessmethoddao.GetBusinessInternalMethodInfo(BMCode);

      if (result.Rows.Count == 0) return;

      foreach (DataRow dr in result.Rows)
      {
        XmlBusinessInternalMethodModel XBIMM = new XmlBusinessInternalMethodModel();
        XBIMM.MethodOrder                    = CommonUtil.TranNull<int>(dr["MethodOrder"]);
        XBIMM.MethodID                       = CommonUtil.TranNull<int>(dr["MethodID"]);
        XBIMM.ParameterRelationList          = new List<XmlParameterRelationModel>();

        DataTable RelationResult             = xmlbusinessmethoddao.GetBusinessParameterRelationInfo(BMCode, XBIMM.MethodID.ToString());
        foreach (DataRow RelationDr in RelationResult.Rows)
        {
          XmlParameterRelationModel XPRM = new XmlParameterRelationModel();
          XPRM.BMParameterName           = CommonUtil.TranNull<string>(RelationDr["BMParameterName"]);
          XPRM.MethodParameterName       = CommonUtil.TranNull<string>(RelationDr["MethodParameterName"]);
          XBIMM.ParameterRelationList.Add(XPRM);
        }

        XBMM.InternalMethodList.Add(XBIMM);
      }
    }

    public void GetBusinessParameterInfo(string BMCode, ref XmlBusinessMethodModel XBMM)
    {
      XmlBusinessMethodDao xmlbusinessmethoddao = new XmlBusinessMethodDao();
      DataTable result                          = xmlbusinessmethoddao.GetBusinessParameterInfo(BMCode);

      if (result.Rows.Count == 0) return;

      foreach (DataRow dr in result.Rows)
      {
        XmlBusinessParameterModel XBPM = new XmlBusinessParameterModel();
        XBPM.ParameterName             = CommonUtil.TranNull<string>(dr["ParameterName"]);
        XBPM.ParameterDesc             = CommonUtil.TranNull<string>(dr["ParameterDesc"]);
        XBPM.ParameterDataType         = EnumManager<ParameterDataType>.EnumName2Enum(dr["ParameterDataType"]);
        XBPM.ParameterDirection        = EnumManager<DBHelper.Enums.ParameterDirection>.EnumName2Enum(dr["ParameterDirection"]);
        XBPM.ParameterValidateType     = EnumManager<ParameterValidateType>.EnumName2Enum(dr["ParameterValidateType"]);
        XBPM.ConstValue                = CommonUtil.TranNull<string>(dr["ConstValue"]);
        XBPM.DefaultValue              = CommonUtil.TranNull<string>(dr["DefaultValue"]);

        XBMM.BusinessParameterList.Add(XBPM);
      }
    }
  }
}
