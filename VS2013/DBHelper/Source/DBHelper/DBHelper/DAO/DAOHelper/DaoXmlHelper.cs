using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper.DAO.DAOModel;
using System.Xml.Serialization;
using System.IO;

namespace DBHelper.DAO
{
  public class DaoXmlHelper
  {
    public static SQLSatement ReadDaoXml(string DaoXmlPath)
    {
      XmlSerializer xs = new XmlSerializer(typeof(SQLSatement));
      using (FileStream fs = new FileStream(DaoXmlPath, FileMode.Open))
      {
        return (SQLSatement)xs.Deserialize(fs);
      }
    }

    public static T ExecuteSQLSatement<T>(string DaoXmlFileName, string[] PramerValues, ParameType SqlParameType)
    {
      string xmlpath  = string.Format("{0}{1}", @"../../DAO/XML/", DaoXmlFileName);
      SQLHelper sh    = new SQLHelper(xmlpath);
      if (SqlParameType == ParameType.Format)
      {
        sh.FormatValues = PramerValues;
      }
      else if (SqlParameType == ParameType.Parames)
      {
        sh.ParameValues = PramerValues;
      }
      return sh.ExecuteSQL<T>();
    }
  }
}