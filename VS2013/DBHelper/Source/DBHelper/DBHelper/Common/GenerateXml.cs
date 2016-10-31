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

namespace DBHelper.Common
{
  class GenerateXml
  {
    public void GenerateInternalMothod(int MethodID)
    {
      XmlInternalMethodModel XIMM = new XmlInternalMethodModel();
      XmlInternalMothodBLL xmlinternalmothodbll = new BLL.XmlInternalMothodBLL();
      xmlinternalmothodbll.GetInternalMethodBaseInfo(MethodID, ref XIMM);
    }

    
  }
}
