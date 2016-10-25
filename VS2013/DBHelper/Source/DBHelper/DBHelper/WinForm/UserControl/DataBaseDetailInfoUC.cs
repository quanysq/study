using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Model;

namespace DBHelper
{
  public class DataBaseDetailInfoUC : UserControl
  {
    public DatabaseDetailInfoModel DatabaseDetailInfo { get; set; }

    public virtual void SetDataBaseDetailInfo2Propety()
    {
      
    }

    public virtual string GetConnectionStr()
    {
      return "";
    }

    public virtual bool TestConnection(string ConnectionStr)
    {
      return true;
    }

    public event EventHandler ValueChanged;

    protected new void TextChanged(object sender, EventArgs e)
    {
      if (ValueChanged != null)
      {
        ValueChanged(this, e);
      }
    }
  }
}
