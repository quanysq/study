using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console015
{
  /// <summary>
  /// Read Local Certificates
  /// </summary>
  class Class3
  {
    public static void ReadLocalCert()
    {
      X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
      store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
      X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
      X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByIssuerName, "adssl-dc-root-CA", false);
      foreach (X509Certificate2 x509 in fcollection)
      {
        Console.WriteLine(x509.Subject);
        Console.WriteLine(x509.Issuer);
        Console.WriteLine(x509.IssuerName.Name);
        Console.WriteLine("=============================");
      }
    }
  }
}
