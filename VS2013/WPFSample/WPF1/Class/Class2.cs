using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF001
{
  class Student: INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    
    private string name;
    public string Name
    {
      get { return name; }
      set
      {
        name = value;

        //激发事件
        if (this.PropertyChanged != null)
        {
          PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
        }
      }
    }
  }
}
