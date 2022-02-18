using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WinFormSample05
{
  public class ExcelConfig
  {
    public static string ExcelFile  = ConfigurationManager.AppSettings["ExcelFile"];
    public static int RowNum        = Convert.ToInt32(ConfigurationManager.AppSettings["RowNum"]);
    public static int CellOfOpen    = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfOpen"]);
    public static int CellOfClose   = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfClose"]);
    public static int CellOfHighest = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfHighest"]);
    public static int CellOfLowest  = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfLowest"]);
    public static int CellOfRange   = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfRange"]);
    public static int CellOfM5      = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfM5"]);
    public static int CellOfM10     = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfM10"]);
    public static int CellOfM30     = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfM30"]);
    public static int CellOfMacd    = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfMacd"]);
    public static int CellOfDiff    = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfDiff"]);
    public static int CellOfDea     = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfDea"]);
    public static int CellOfK       = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfK"]);
    public static int CellOfD       = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfD"]);
    public static int CellOfJ       = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfJ"]);
    public static int CellOfRSI6    = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfRSI6"]);
    public static int CellOfRSI12   = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfRSI12"]);
    public static int CellOfRSI24   = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfRSI24"]);
    public static int CellOfVol     = Convert.ToInt32(ConfigurationManager.AppSettings["CellOfVol"]);
  }
}
