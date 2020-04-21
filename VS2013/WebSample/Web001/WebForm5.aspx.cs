using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web001
{
  public partial class WebForm5 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //字符串转数字
      string val1 = "123";
      int val2 = TranNull<int>(val1);
      int val3 = val2 + 1;
      Response.Write("123 + 1 = " + val3);
      Response.Write("<br />");
      
      //object 转 bool
      object obj1 = null;
      bool obj2 = TranNull<bool>(obj1);
      Response.Write("object - null = " + obj2); // output: False
      Response.Write("<br />");
      

      //打印一个不存在 Cache 项
      var objBB = Cache.Get("BB");
      Response.Write("Cache[\"BB\"] = " + (objBB ?? "null"));
      Response.Write("<br />");

      //插入一个 Cache
      Cache.Insert("AA", "aa", null, DateTime.Now.AddSeconds(3), System.Web.Caching.Cache.NoSlidingExpiration);
      Response.Write("Cache[\"AA\"] = " + Cache["AA"]);
      Cache.Insert("AA", "bb", null, DateTime.Now.AddSeconds(3), System.Web.Caching.Cache.NoSlidingExpiration);
      Response.Write("<br />");
      Thread.Sleep(5000); //到期值为 null
      Response.Write("Cache[\"AA\"] = " + Cache["AA"]);
    }

    private T TranNull<T>(object obj)
    {
      if (obj == null) return default(T);
      if (obj is T) return (T)obj;
      try
      {
        return (T)Convert.ChangeType(obj, typeof(T));
      }
      catch
      {
        return default(T);
      }
    }
  }
}