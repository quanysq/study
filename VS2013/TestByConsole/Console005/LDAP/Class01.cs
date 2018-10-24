using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console005.LDAP
{
  /// <summary>
  /// Using DirectoryEntry
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      //ConnectLDAP();

      ConnectLDAPWithSSL();
    }

    //test successed
    private static void ConnectAD()
    {
      ADHelper.ADPath = "LDAP://192.168.10.58:389";
      ADHelper.ADUser = "Bee";
      ADHelper.ADPassword = "Simple.0";
      DirectoryEntry de = ADHelper.GetDirectoryObject();

      int i = 0;
      foreach (var item in de.Properties.PropertyNames)
      {
        Console.WriteLine(i);
        Console.WriteLine("{0}: {1}", item, de.Properties[item.ToString()].Value.ToString());
        Console.WriteLine("");
        i++;
      }
    }

    //test successed
    private static void ConnectLDAP()
    {
      DirectoryEntry entry = new DirectoryEntry();
      DirectorySearcher serach = new DirectorySearcher();

      entry.Path = "LDAP://192.168.11.98:1389/uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com";

      entry.AuthenticationType = AuthenticationTypes.None;

      serach.SearchRoot = entry;

      serach.Filter = "(&(objectClass=Person))";

      // Get the first entry of the search.
      SearchResult searchResult = serach.FindOne();

      if (searchResult == null)
      {

        Console.WriteLine("Could not find entries: [{0}]", entry.Path);

        return;

      }

      DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();

      Console.WriteLine("directoryEntry.Name: [{0}]", directoryEntry.Name);

      ResultPropertyCollection resultPropColl = searchResult.Properties;

      foreach (string propName in resultPropColl.PropertyNames)
      {
        Console.WriteLine("propName: [{0}]", propName);

        foreach (Object collection in resultPropColl[propName])
        {
          Console.WriteLine("collection: [{0}]", collection.ToString());
        }
      }

      /*
       * LDAP 服务器 配置
       * suffix  "dc=dsee7-ldap,dc=com"
       * rootdn  "cn=Manager,dc=webCMS,dc=com"

       * entry.Path = "LDAP://192.168.11.98:1389/dc=dsee7-ldap,dc=com"  //LDAP 必须大写
       * entry.Username = "dc=Manager,dc=webCMS,dc=com"        //rootdn
       * serach.Filter = "(&(objectClass=Person))"  
         括号很重要，
         (!(ou=mail)(ou=peopele)) 表示两个条件 or
         (&(ou=mail)(ou=peopele)) 表示两个条件 and
         可以有两个以上的条件
     
       */
    }

    //test failed
    private static void ConnectLDAPWithSSL()
    {
      DirectoryEntry entry = new DirectoryEntry();
      DirectorySearcher serach = new DirectorySearcher();

      entry.Path = "LDAP://192.168.11.98:1636/uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com";
      entry.Username = "NBIAdministrator";
      entry.Password = "Simple.0";
      entry.AuthenticationType = AuthenticationTypes.SecureSocketsLayer;
      object nativeObject = entry.NativeObject;
      serach.SearchRoot = entry;
      
      serach.Filter = "(&(objectClass=Person))";

      // Get the first entry of the search.
      SearchResult searchResult = serach.FindOne();

      if (searchResult == null)
      {

        Console.WriteLine("Could not find entries: [{0}]", entry.Path);

        return;

      }

      DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();

      Console.WriteLine("directoryEntry.Name: [{0}]", directoryEntry.Name);

      ResultPropertyCollection resultPropColl = searchResult.Properties;

      foreach (string propName in resultPropColl.PropertyNames)
      {
        Console.WriteLine("propName: [{0}]", propName);

        foreach (Object collection in resultPropColl[propName])
        {
          Console.WriteLine("collection: [{0}]", collection.ToString());
        }

      }
    }

    
  }
}
