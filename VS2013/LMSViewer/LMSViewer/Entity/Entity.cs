using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSViewer.Entity
{
  public class TechnopediaAuthorizationDetails
  {
    public bool has_technopedia_apikey { get; set; }

    public string isEligibleToReceiveTechnopediaUpdate { get; set; }

    public int subscription_id { get; set; }

    public object tps_coverage { get; set; }

    public string tps_coverage_mode { get; set; }

    public List<SubscriptionTabCol> tps_structure { get; set; }

    public string tps_structure_mode { get; set; }

    public string tag_subscription_status { get; set; }
    public List<string> tag_short_name { get; set; }
  }

  public class SubscriptionTabCol
  {
    public string table_name { get; set; }
    public string column_name { get; set; }
  }

  public class SubscriptionStr
  {
    public string tablename { get; set; }
    public string columnnames { get; set; }
  }
}
