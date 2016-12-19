using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
  /// </summary>
  class C16
  {
    public static void Execute()
    {
      string cellValue = ".5124";
      Console.WriteLine(Convert.ToDecimal(cellValue, System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
    }
  }
}
