using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console002
{
  /// <summary>
  /// 检查FipsAlgorithmPolicy的设置
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      RegistryKey rk = null;
      string fipsSetting = "0";
      try
      {
        rk = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Lsa\FipsAlgorithmPolicy");
        fipsSetting = rk.GetValue("Enabled").ToString();
      }
      catch
      {
        fipsSetting = "0";
      }
      finally
      {
        if (rk != null) rk.Close();
      }
      Console.WriteLine("FipsAlgorithmPolicy: [{0}]", fipsSetting);
    }
  }
}
