using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Generate;
using DBHelper.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DBHelper.Util;

namespace DBHelper.Generate.Tests
{
  [TestClass()]
  public class XmlHelperTest
  {
    private string XmlFilePath = @"D:\Study\study\VS2013\DBHelper\Source\Temp\Test.xml";

    [TestMethod()]
    public void SerializeTest()
    {
      XmlInternalMethodModel XIMM = new XmlInternalMethodModel();
      XIMM.MethodID = 1;
      XIMM.DBType = DBType.MsSqlServer;
      XIMM.ConnectionStr = "ABC";
      XIMM.MethodName = "BCD";
      XIMM.MethodDesc = "BCD";
      XIMM.MethodType = MethodType.SQLStatement;
      XIMM.FunctionType = FunctionType.Select_Paging;
      XIMM.SuccessMsg = "";
      XIMM.FailMsg = "";
      XIMM.MethodStatementList = new List<XmlMethodStatementModel>();
      XIMM.MethodParameterList = new List<XmlMethodParameterModel>();

      #region XmlMethodStatementModel 1
      XmlMethodStatementModel XMSM1 = new XmlMethodStatementModel();
      XMSM1.OrderID = 1;
      XMSM1.Tag = "AS1";
      XMSM1.Statement = "AAAAAAAAA";
      XMSM1.IsOrderby = CommonUtil.TranNull<bool>(0);
      XMSM1.HasConditional = CommonUtil.TranNull<bool>(1);
      XMSM1.StatementConditionalList = new List<XmlMethodStatementConditionalModel>();

      XmlMethodStatementConditionalModel XMSCM1 = new XmlMethodStatementConditionalModel();
      XMSCM1.ConditionType = ConditionType.And;
      XMSCM1.ParameterName = "ABCD";
      XMSCM1.ExpectBehavior = BehaviorType.Equal;
      XMSCM1.CompareValue = "";
      XMSM1.StatementConditionalList.Add(XMSCM1);

      XmlMethodStatementConditionalModel XMSCM2 = new XmlMethodStatementConditionalModel();
      XMSCM2.ConditionType = ConditionType.Or;
      XMSCM2.ParameterName = "BCDE";
      XMSCM2.ExpectBehavior = BehaviorType.GreaterThan_Equal;
      XMSCM2.CompareValue = "11";
      XMSM1.StatementConditionalList.Add(XMSCM2);

      XIMM.MethodStatementList.Add(XMSM1);
      #endregion

      #region XmlMethodStatementModel 2
      XmlMethodStatementModel XMSM2 = new XmlMethodStatementModel();
      XMSM2.OrderID = 2;
      XMSM2.Tag = "AS2";
      XMSM2.Statement = "BBBBBBB";
      XMSM2.IsOrderby = false;
      XMSM2.HasConditional = false;
      XMSM2.StatementConditionalList = new List<XmlMethodStatementConditionalModel>();
      XIMM.MethodStatementList.Add(XMSM2);
      #endregion

      #region XmlMethodParameterModel
      XmlMethodParameterModel XMPM1 = new XmlMethodParameterModel();
      XMPM1.ParameterName  = "A1";
      XMPM1.ParameterDesc  = "ABCDE#";
      XMPM1.ParameterDataType  = ParameterDataType.Varchar;
      XMPM1.ParameterDirection  = ParameterDirection.In;
      XMPM1.ParameterValidateType  = ParameterValidateType.Required;
      XMPM1.ValidateValue  = "";
      XIMM.MethodParameterList.Add(XMPM1);

      XmlMethodParameterModel XMPM2 = new XmlMethodParameterModel();
      XMPM2.ParameterName  = "A2";
      XMPM2.ParameterDesc  = "ABCDES";
      XMPM2.ParameterDataType  = ParameterDataType.Nvarchar;
      XMPM2.ParameterDirection  = ParameterDirection.In;
      XMPM2.ParameterValidateType  = ParameterValidateType.InList;
      XMPM2.ValidateValue  = "1,100";
      XIMM.MethodParameterList.Add(XMPM2);
      #endregion

      XmlHelper.Serialize<XmlInternalMethodModel>(XIMM, XmlFilePath);

      Assert.IsTrue(File.Exists(XmlFilePath));
    }

    [TestMethod()]
    public void DeSerializeTest()
    {
      var val = XmlHelper.DeSerialize<XmlInternalMethodModel>(XmlFilePath);
      Assert.IsTrue(val != null);
    }

    [TestMethod()]
    public void SerializeForBusinessMethodTest()
    {
      XmlBusinessMethodModel XBMM = new XmlBusinessMethodModel();
      XBMM.BMCode = "A00001";
      XBMM.DBType = DBType.MsSqlServer;
      XBMM.ConnectionStr = "ABABABAB";
      XBMM.BMDesc = "AABBCCDDEEFF";
      XBMM.FunctionType = FunctionType.Select_Paging;
      XBMM.InternalMethodList = new List<XmlBusinessInternalMethodModel>();
      XBMM.BusinessParameterList = new List<XmlBusinessParameterModel>();

      #region InternalMethodList
      XmlBusinessInternalMethodModel XBIMM = new XmlBusinessInternalMethodModel();
      XBIMM.MethodOrder = 1;
      XBIMM.MethodID = 1;
      XBIMM.ParameterRelationList = new List<XmlParameterRelationModel>();

      XmlParameterRelationModel XPRM = new XmlParameterRelationModel();
      XPRM.BMParameterName = "A";
      XPRM.MethodParameterName = "B";
      XBIMM.ParameterRelationList.Add(XPRM);

      XBMM.InternalMethodList.Add(XBIMM);
      #endregion

      #region BusinessParameterList
      XmlBusinessParameterModel XBPM = new XmlBusinessParameterModel();
      XBPM.ParameterName = "AAA";
      XBPM.ParameterDesc = "BBB";
      XBPM.ParameterDataType = ParameterDataType.Int;
      XBPM.ParameterDirection = ParameterDirection.InOut;
      XBPM.ParameterValidateType = ParameterValidateType.LessThan;
      XBPM.ConstValue = "1";
      XBPM.DefaultValue = "";

      XBMM.BusinessParameterList.Add(XBPM);
      #endregion

      XmlHelper.Serialize<XmlBusinessMethodModel>(XBMM, XmlFilePath);

      Assert.IsTrue(File.Exists(XmlFilePath));
    }

    [TestMethod()]
    public void DeSerializeForBusinessMethodTest()
    {
      var val = XmlHelper.DeSerialize<XmlBusinessMethodModel>(XmlFilePath);
      Assert.IsTrue(val != null);
    }

  }
}
