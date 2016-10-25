using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  class ComboBoxItemModel
  {
    public string Key { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
      return this.Key;
    }
  }
}
