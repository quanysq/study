using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console005
{
  /// <summary>
  /// 域操作
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //ADHelper.ADPath = "LDAP://192.168.11.98:1389";
      //ADHelper.ADUser = "nbiadministrator";
      //ADHelper.ADPassword = "Simple.0";
      //DirectoryEntry de = ADHelper.GetDirectoryObject();
       
      //string s1 = "demoadmin";    //nbiadministrator
      //string s2 = "bdna";         //Simple.0
      //string s3 = "bdnacn";       //dsee7-ldap
      //IdentityImpersonation idi = new IdentityImpersonation(s1, s2, s3);
      //idi.BeginImpersonate();

      LDAPHelper ldap = new LDAPHelper();
      ldap.LdapHost = "192.168.11.98";
      ldap.LdapPort = 1389;
      ldap.LoginDN = "uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com";
      ldap.LoginPassword = "Simple.0";
      ldap.ConnectLDAP();
      ldap.SearchBase = "ou=People,dc=dsee7-ldap,dc=com";
      ldap.SearchFilter = "(objectclass=*)";
      ldap.Search();
      ldap.DisConnectLDAP();

      Console.ReadKey();
    }
  }
}
