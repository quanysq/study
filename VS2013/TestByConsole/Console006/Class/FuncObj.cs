using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.Class
{
  /// <summary>  
  /// 方法参数  
  /// </summary>  
  class InputArgs
  {
    public InputArgs(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
  }

  /// <summary>  
  /// 方法结果  
  /// </summary>  
  class Result
  {
    public string Msg { get; set; }
    public bool Flag { get; set; }
    public override string ToString()
    {
      return string.Format("Flag:{0},Msg:{1}", Flag, Msg);
    }
  }
}
