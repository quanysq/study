using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Util
{
    public sealed class ConverterUtil
    {
      public static T ConvertDataType<T>(object obj)
      {
        if (obj == null) return default(T);
        if (obj is T) return (T)obj;
        try
        {
          return (T)Convert.ChangeType(obj, typeof(T));
        }
        catch (InvalidCastException)
        {
          return default(T);
        }
        catch (FormatException)
        {
          return default(T);
        }
        catch (OverflowException)
        {
          return default(T);
        }
        catch (ArgumentNullException)
        {
          return default(T);
        }
        catch
        {
          return default(T);
        }
      }

      public static T ConvertDataType<T>(string str)
      {
        try
        {
          return (T)Convert.ChangeType(str, typeof(T));
        }
        catch (InvalidCastException)
        {
          return default(T);
        }
        catch (FormatException)
        {
          return default(T);
        }
        catch (OverflowException)
        {
          return default(T);
        }
        catch (ArgumentNullException)
        {
          return default(T);
        }
        catch
        {
          return default(T);
        }
      }
    }
}
