using DBHelper.Model;
using DBHelper.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Enums;

namespace DBHelper.Common
{
  public class Common
  {
    public static readonly string LocalConnection = ConfigurationManager.AppSettings["LocalConnection"];
    public static readonly string XmlFileDir      = ConfigurationManager.AppSettings["XmlFileDir"];

    public static string OperateDbConnection { get; set; }
    public static int OperateDbID { get; set; }
    public static DBType OperateDbType { get; set; }

    
  }
}
