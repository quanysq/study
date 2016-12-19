using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console005.LDAP
{
  /// <summary>
  /// AD
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      ADHelper.ADPath = "LDAP://192.168.11.98:1389";
      ADHelper.ADUser = "nbiadministrator";
      ADHelper.ADPassword = "Simple.0";
      DirectoryEntry de = ADHelper.GetDirectoryObject();
       
      string s1 = "demoadmin";    //nbiadministrator
      string s2 = "bdna";         //Simple.0
      string s3 = "bdnacn";       //dsee7-ldap
      IdentityImpersonation idi = new IdentityImpersonation(s1, s2, s3);
      idi.BeginImpersonate();
    }
  }
}
