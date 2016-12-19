using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console005.LDAP
{
  /// <summary>
  /// LDAP
  /// </summary>
  class C2
  {
    public static void Execute()
    {
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
    }
  }
}
