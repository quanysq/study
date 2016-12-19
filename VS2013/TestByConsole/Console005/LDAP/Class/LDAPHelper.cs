using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novell.Directory.Ldap;
using Novell.Directory.Ldap.Utilclass;
using System.Collections;

namespace Console005.LDAP
{
  /// <summary>
  /// Use Novell.Directory.Ldap.dll
  /// </summary>
  class LDAPHelper
  {
    private LdapConnection conn = null;

    public string LdapHost { get; set; }
    public int LdapPort { get; set; }
    public string LoginDN { get; set; }
    public string LoginPassword { get; set; }
    public string SearchBase { get; set; }
    public string SearchFilter { get; set; }

    public LDAPHelper()
    {

    }

    public LDAPHelper(string ldapHost, int ldapPort, string loginDN, string loginPassword)
    {
      LdapHost      = ldapHost;
      LdapPort      = ldapPort;
      LoginDN       = loginDN;
      LoginPassword = loginPassword;
      ConnectLDAP();
    }

    public void ConnectLDAP()
    {
      try
      {
        conn = new LdapConnection();
        conn.Connect(LdapHost, LdapPort);
        conn.Bind(LoginDN, LoginPassword);
        Console.WriteLine("Connect LDAP/AD Server Successfull!");
        Console.WriteLine("=======================");
      }
      catch (LdapException e)
      {
        throw e;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public void DisConnectLDAP()
    {
      if (conn != null && conn.Connected) conn.Disconnect();
    }

    public void Search()
    {
      LdapSearchResults lsc = conn.Search(SearchBase, LdapConnection.SCOPE_SUB, SearchFilter, null, false);
      while (lsc.hasMore())
      {
        LdapEntry nextEntry = null;
        try
        {
          nextEntry = lsc.next();
        }
        catch (LdapException e)
        {
          Console.WriteLine("Error: " + e.LdapErrorMessage);
          // Exception is thrown, go for next entry
          continue;
        }
        Console.WriteLine("\n" + nextEntry.DN);
        LdapAttributeSet attributeSet = nextEntry.getAttributeSet();
        IEnumerator ienum = attributeSet.GetEnumerator();
        while (ienum.MoveNext())
        {
          LdapAttribute attribute = (LdapAttribute)ienum.Current;
          string attributeName = attribute.Name;
          string attributeVal = attribute.StringValue;
          if (!Base64.isLDIFSafe(attributeVal))
          {
            byte[] tbyte = SupportClass.ToByteArray(attributeVal);
            attributeVal = Base64.encode(SupportClass.ToSByteArray(tbyte));
          }
          Console.WriteLine(attributeName + "value:" + attributeVal);
        }
      }
    }
  }
}
