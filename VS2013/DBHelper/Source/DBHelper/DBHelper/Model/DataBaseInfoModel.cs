using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class DatabaseInfoModel
  {
    public int DatabaseID { get; set; }
    public int UserID { get; set; }
    public string DBType { get; set; }
    public string ConnectionName { get; set; }
    public string ConnectionStr { get; set; }
    public int IsDefault { get; set; }

    public DatabaseInfoModel()
    {
      DatabaseID     = 0;
      UserID         = 0;
      DBType         = "";
      ConnectionName = "";
      ConnectionStr  = "";
      IsDefault      = 0;
    }
  }

  public class DatabaseDetailInfoModel
  {
    public int DatabaseID { get; set; }
    public string DBHost { get; set; }
    public string DBUser { get; set; }
    public string DBPwd { get; set; }
    public string Pooling { get; set; }
    public string MinPoolSize { get; set; }
    public string MaxPoolSize { get; set; }
    public string ConnectionLifetime { get; set; }
    public string Catalog { get; set; }
    public string Port { get; set; }
    public string Service_Name { get; set; }

    public DatabaseDetailInfoModel()
    {
      DatabaseID         = 0;
      DBHost             = "";
      DBUser             = "";
      DBPwd              = "";
      Pooling            = "";
      MinPoolSize        = "";
      MaxPoolSize        = "";
      ConnectionLifetime = "";
      Catalog            = "";
      Port               = "";
      Service_Name       = "";
    }
  }
}
