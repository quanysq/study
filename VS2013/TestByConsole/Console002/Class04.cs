using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Console002
{
  /// <summary>
  /// 设置指定目录的权限
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      string folderpath = Console.ReadLine();
      Console.WriteLine("folderpath is [{0}]", folderpath);
      SetSecurity(folderpath, WellKnownSidType.BuiltinUsersSid);
      Console.WriteLine("OK");
      Console.ReadKey();
    }

    static void SetSecurity(string folderpath, string account)
    {
      // Get a FileSecurity object that represents the
      // current security settings.
      DirectorySecurity dSecurity = Directory.GetAccessControl(folderpath);
      dSecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.Write, AccessControlType.Allow));
      dSecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.Modify, AccessControlType.Allow));
      // Set the new access settings.
      Directory.SetAccessControl(folderpath, dSecurity);
    }

    static void SetSecurity(string folderpath, WellKnownSidType wellknownsidtype)
    {
      DirectoryInfo myDirectoryInfo = new DirectoryInfo(folderpath);
      var sid = new SecurityIdentifier(wellknownsidtype, null);   //e.g: WellKnownSidType.AuthenticatedUserSid
      DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
      myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.Write, AccessControlType.Allow));
      myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.Modify, AccessControlType.Allow));
      myDirectoryInfo.SetAccessControl(myDirectorySecurity);
    }

    static void GetSecurityRules(string folderpath)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(folderpath);
      DirectorySecurity DSecurity = directoryInfo.GetAccessControl();
      AuthorizationRuleCollection Rules = DSecurity.GetAccessRules(true, true, typeof(NTAccount));

      foreach (FileSystemAccessRule fileSystemAccessRule in Rules)
      {
        Console.WriteLine("User/Group name {0}", fileSystemAccessRule.IdentityReference.Value);
        Console.WriteLine("Permissions: {0}", fileSystemAccessRule.FileSystemRights.ToString());
      }
    }
  }
}
