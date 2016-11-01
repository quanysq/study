using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.DAO
{
  class XmlBusinessMethodDao
  {
    public DataTable GetBusinessMethodBaseInfo(string BMCode)
    {
      string[] PramerValues = { BMCode };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlBusinessMethodBaseInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable GetBusinessInternalMethodInfo(string BMCode)
    {
      string[] PramerValues = { BMCode };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlBusinessInternalMethodInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable GetBusinessParameterRelationInfo(string BMCode, string MethodID)
    {
      string[] PramerValues = { BMCode, MethodID };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlBusinessParameterRelationInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }

    public DataTable GetBusinessParameterInfo(string BMCode)
    {
      string[] PramerValues = { BMCode };
      DataTable dt          = DaoXmlHelper.ExecuteSQLSatement<DataTable>("XmlBusinessParameterInfoFormat.xml", PramerValues, ParameType.Format);
      return dt;
    }
  }
}
