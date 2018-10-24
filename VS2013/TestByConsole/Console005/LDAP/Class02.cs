using System;
using System.Collections.Generic;
using System.IO;
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
      //ConnectNormalLDAP();

      //Import1198Cert(@"D:\Work\TestData\Cert\LDAP\DSE1198-ASCII.cer");
      //ConnectNormalLDAPWithSSL();

      //Import1198Cert(@"D:\Work\TestData\Cert\LDAP\user.com-rootca.cer");
      ConnectTLSOnlyLDAP();

      //Import1198Cert(@"D:\Work\TestData\Cert\LDAP\user.com-rootca.cer");
      //ConnectTLSOnlyLDAPWithSSL();
      
      //ConnectNormalAD();
    }

    //test successed
    private static void ConnectNormalLDAP()
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

    //test successed
    private static void ConnectNormalLDAPWithSSL()
    {
      LDAPHelper ldap = new LDAPHelper();
      ldap.LdapHost = "192.168.11.98";
      ldap.LdapPort = 1636;
      ldap.LoginDN = "uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com";
      ldap.LoginPassword = "Simple.0";
      ldap.IsSSL = true;
      ldap.ConnectLDAP();
      ldap.DisConnectLDAP();

      /*
       * SSL 必须先导入证书，执行 Import1198Cert() 方法
       */
    }

    private static void Import1198Cert(string certFilePath)
    {
      byte[] certBytes = File.ReadAllBytes(certFilePath);
      
      Mono.Security.X509.X509Certificate rootCert = new Mono.Security.X509.X509Certificate(certBytes);
      Mono.Security.X509.X509Store store = Mono.Security.X509.X509StoreManager.CurrentUser.TrustedRoot;
      store.Import(rootCert);
      store.Certificates.Add(rootCert);
    }

    //test failed
    private static void ConnectTLSOnlyLDAP()
    {
      LDAPHelper ldap = new LDAPHelper();
      ldap.LdapHost = "192.168.10.58";
      ldap.LdapPort = 389;
      ldap.LoginDN = "CN=Bee,OU=Engineering,DC=User,DC=com";
      ldap.LoginPassword = "Simple.0";
      ldap.EnableTLS = true;
      ldap.ConnectLDAP();
      ldap.SearchBase = "OU=Engineering,DC=User,DC=com";
      ldap.SearchFilter = "(objectClass=*)";
      ldap.Search();
      ldap.DisConnectLDAP();

      /*
       * Mono.Security.5.4.0.201 支持 TLS11 和 TLS12，但 SSL 导入证书会出错
       */
    }

    //test failed
    private static void ConnectTLSOnlyLDAPWithSSL()
    {
      LDAPHelper ldap = new LDAPHelper();
      ldap.LdapHost = "192.168.10.58";
      ldap.LdapPort = 636;
      ldap.LoginDN = "CN=Bee,OU=Engineering,DC=User,DC=com";
      ldap.LoginPassword = "Simple.0";
      ldap.IsSSL = true;
      ldap.ConnectLDAP();
      ldap.SearchBase = "OU=Engineering,DC=User,DC=com";
      ldap.SearchFilter = "(&(objectClass=Person))";
      ldap.Search();
      ldap.DisConnectLDAP();
    }

    //test successed
    private static void ConnectNormalAD()
    {
      LDAPHelper ldap = new LDAPHelper();
      ldap.LdapHost = "192.168.8.18";
      ldap.LdapPort = 389;
      ldap.LoginDN = "cn=DemoAdmin,ou=nbi,ou=bdna_engineerteam,dc=bdnacn,dc=com";
      ldap.LoginPassword = "bdna";
      ldap.EnableTLS = false;
      ldap.ConnectLDAP();
      ldap.SearchBase = "ou=nbi,ou=bdna_engineerteam,dc=bdnacn,dc=com";
      ldap.SearchFilter = "(&(objectClass=Person)(cn=Demo*))";
      ldap.Search();
      ldap.DisConnectLDAP();

      /*
       * AD LoginDN 要带上用户，否则报 AcceptSecurityContext error, data 57
       */
    }
  }
}
