using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class UserInfoModel
  {
    public int UserID { get; set; }
    public string Usercode { get; set; }
    public string UserName { get; set; }
    public string Pwd { get; set; }
    public int IsAddSelf { get; set; }
    public int IsEditSelf { get; set; }
    public int IsDeleteSelf { get; set; }
    public int IsEditOther { get; set; }
    public int IsDeleteOther { get; set; }

    private UserInfoModel() { }

    private static UserInfoModel instance = null;
    public static UserInfoModel Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new UserInfoModel();
        }
        return instance;
      }
    }
  }
}
