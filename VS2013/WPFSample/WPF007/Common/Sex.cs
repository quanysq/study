using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF007
{
  public class Sex
  {
    public int SexID { get; set; }
    public string SexName { get; set; }
  }

  public class SexList : ObservableCollection<Sex>
  {
    public SexList()
    {
      this.Add(new Sex() { SexID = 1, SexName = "男" });
      this.Add(new Sex() { SexID = 2, SexName = "女" });
    }
  }
}
