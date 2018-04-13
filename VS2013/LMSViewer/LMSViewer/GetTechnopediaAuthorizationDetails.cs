using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMSViewer.Entity;

namespace LMSViewer
{
  public partial class GetTechnopediaAuthorizationDetails : SubForm
  {
    public GetTechnopediaAuthorizationDetails()
    {
      InitializeComponent();
    }

    private void GetTechnopediaAuthorizationDetails_Load(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(ParentFormInfo)) return;

      TechnopediaAuthorizationDetails tad = Common.JsonDeserialize<TechnopediaAuthorizationDetails>(ParentFormInfo);
      Subscription.Text = GetSubscription(tad);
      SubscriptionHash.Text = GetSubscriptionHash(Subscription.Text.Trim());
      Vertical.Text = string.Join(", ", tad.tag_short_name);
    }

    private string GetSubscription(TechnopediaAuthorizationDetails tad)
    {
      if (tad.tps_structure == null) return "";
      List<SubscriptionTabCol> CurrentSubscriptionList = tad.tps_structure;
      CurrentSubscriptionList.ForEach(x => { x.table_name = x.table_name.Replace(" ", ""); x.column_name = x.column_name.Replace(" ", ""); });
      CurrentSubscriptionList                          = CurrentSubscriptionList.OrderBy(x => x.table_name).ThenBy(x => x.column_name).ToList();
      List<SubscriptionStr> SubscriptionStrList        =
        (from t in CurrentSubscriptionList
         group t by t.table_name into m
         select new SubscriptionStr
         {
           tablename = m.Key,
           columnnames = string.Join(",", m.Select(n => n.column_name).Distinct())
         }).ToList();
      string strCurrentSubscription                    = string.Join(";", SubscriptionStrList.Select(n => n.tablename + "|" + n.columnnames)) + ";";
      return strCurrentSubscription;
    }

    private string GetSubscriptionHash(string Subscription)
    {
      if (string.IsNullOrWhiteSpace(Subscription)) return "";
      return Common.CalculateSHA1Hash(Subscription, Encoding.UTF8);
    }

    private void Subscription_KeyUp(object sender, KeyEventArgs e)
    {
      Common c = new Common();
      c.SelectAllByKey(sender, e);
    }
  }
}
