using DBHelper.BLL;
using DBHelper.Enums;
using DBHelper.Generate;
using DBHelper.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.BLL;
using DBHelper.Common;

namespace DBHelper.Common
{
  class GenerateXml
  {
    public void GenerateInternalMothod(int MethodID)
    {
      XmlInternalMethodModel XIMM = new XmlInternalMethodModel();
      XmlInternalMothodBLL xmlinternalmothodbll = new XmlInternalMothodBLL();
      xmlinternalmothodbll.GetInternalMethodBaseInfo(MethodID, ref XIMM);
      xmlinternalmothodbll.GetMethodStatementInfo(MethodID, ref XIMM);
      xmlinternalmothodbll.GetMethodParameterInfo(MethodID, ref XIMM);

      string XmlFilePath = string.Format("{0}{1}.xml", Common.XmlFileDir, MethodID.ToString());
      XmlHelper.Serialize<XmlInternalMethodModel>(XIMM, XmlFilePath);
    }

    public void GenerateBusinessMethod(string BMCode)
    {
      XmlBusinessMethodModel XBMM = new XmlBusinessMethodModel();
      XmlBusinessMethodBLL xmlbusinessmethodbll = new XmlBusinessMethodBLL();
      xmlbusinessmethodbll.GetBusinessMethodBaseInfo(BMCode, ref XBMM);
      xmlbusinessmethodbll.GetBusinessInternalMethodInfo(BMCode, ref XBMM);
      xmlbusinessmethodbll.GetBusinessParameterInfo(BMCode, ref XBMM);

      string XmlFilePath = string.Format("{0}{1}.xml", Common.XmlFileDir, BMCode);
      XmlHelper.Serialize<XmlBusinessMethodModel>(XBMM, XmlFilePath);
    }
  }
}
