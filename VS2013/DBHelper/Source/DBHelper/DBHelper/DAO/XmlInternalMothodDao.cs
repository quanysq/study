using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.DAO
{
  class XmlInternalMothodDao
  {
    public DataTable GetInternalMethodBaseInfo(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlInternalMethodBaseInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable GetMethodStatementInfo(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlMethodStatementInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable GetMethodStatementConditionalInfo(string StatementID)
    {
      string[] PramerValues = { StatementID };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlMethodStatementConditionalInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable GetMethodParameterInfo(string MethodID)
    {
      string[] PramerValues = { MethodID };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlMethodParameterInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }
  }
}
