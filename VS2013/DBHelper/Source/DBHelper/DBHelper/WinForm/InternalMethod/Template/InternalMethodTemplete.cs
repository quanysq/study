using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Enums;
using DBHelper.Model;
using DBHelper.Common;
using DBHelper.BLL;

namespace DBHelper
{
  public class InternalMethodTemplete: Form
  {
    public int MethodID { get; set; }
    public int ClassifyID { get; set; }
    public MethodType MethodType { get; set; }
    public FunctionType FunctionType { get; set; }

    protected void Init()
    {
      ClassifyID = (this.Owner as InternalMethodList).ClassifyID;
      if (MethodID > 0) LoadData();
    }

    protected virtual void LoadData()
    {

    }

    protected virtual void SaveInternalMethod(InternalMethodModel internalmethodmodel)
    {
      try
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        int result = internalmethodbll.InternalMethodSave(internalmethodmodel);
        if (result > 0)
        {
          this.DialogResult = DialogResult.OK;
          this.MethodID     = result;
          (this.Owner as InternalMethodList).InternalMethodListLoad();
          this.Close();
        }
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }
  }
}
