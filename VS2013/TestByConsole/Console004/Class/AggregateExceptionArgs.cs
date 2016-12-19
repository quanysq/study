using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console004.Class
{
  class AggregateExceptionArgs : EventArgs
  {
    public AggregateException AggregateException { get; set; }
    public int retry { get; set; }
  }
}
