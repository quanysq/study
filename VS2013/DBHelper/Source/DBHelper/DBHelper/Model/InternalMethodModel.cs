using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class InternalMethodModel
  {
    public int MethodID { get; set; }
    public int DatabaseID { get; set; }
    public int ClassifyID { get; set; }
    public string MethodName { get; set; }
    public string MethodDesc { get; set; }
    public string MethodType { get; set; }
    public string FunctionType { get; set; }
    public string SuccessMsg { get; set; }
    public string FailMsg { get; set; }
    public string CreateUser { get; set; }
    public DateTime CreateDate { get; set; }
    public string UpdateUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public string UpdateReson { get; set; }

    public InternalMethodModel()
    {
      MethodID     = 0;
      DatabaseID   = 0;
      ClassifyID   = 0;
      MethodName   = "";
      MethodDesc   = "";
      MethodType   = "";
      FunctionType = "";
      SuccessMsg   = "";
      FailMsg      = "";
      CreateUser   = UserInfoModel.Instance.Usercode;
      CreateDate   = DateTime.Now;
      UpdateUser   = UserInfoModel.Instance.Usercode;
      UpdateDate   = DateTime.Now;
      UpdateReson  = "";

    }
  }
}
