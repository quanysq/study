using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Util
{
  public sealed class EnumUtil<TEnum>
  {
    public static string Enum2EnumName(object enumValue)
    {
      string enumName = Enum.GetName(typeof(TEnum), enumValue);
      return enumName;      
    }

    public static TEnum EnumName2Enum(string enumName)
    {
      return (TEnum)Enum.Parse(typeof(TEnum), enumName);
    }

    public static TEnum EnumName2Enum(object objEnumName)
    {
      string enumName = ConverterUtil.ConvertDataType<string>(objEnumName);
      return EnumName2Enum(enumName);
    }
  }
}
