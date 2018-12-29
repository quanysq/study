using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace Web003.Util
{
  public class SoapHeaderHelper: SoapHeader
  {
    string _UserName = string.Empty;
    string _Password = string.Empty;   

    public SoapHeaderHelper() { }

    public SoapHeaderHelper(string userName, string passWord)   
    {   
        _UserName = userName;   
        _Password = passWord;   
    }

    public string UserName
    {
      get { return _UserName; }
      set { _UserName = value; }
    }

    public string Password
    {
      get { return _Password; }
      set { _Password = value; }
    }

    public bool CheckLogin()
    {
      if (_UserName.Equals("Admin") && _Password.Equals("1234567"))
      {
        return true;
      }
      else
      {
        return false;
      }
    }  
  }
}