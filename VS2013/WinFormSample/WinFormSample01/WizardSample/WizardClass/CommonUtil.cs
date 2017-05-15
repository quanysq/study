using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormSample01.WizardSample.WizardClass
{
  public class CommonUtil
  {
    public static T TranNull<T>(object obj)
    {
      if (obj == null) return default(T);
      if (obj is T) return (T)obj;
      try
      {
        return (T)Convert.ChangeType(obj, typeof(T));
      }
      catch
      {
        return default(T);
      }
    }
  }
}
