using DBHelper.BLL;
using DBHelper.Common;
using DBHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBHelper
{
  public partial class BusinessMethodSubFormTemplate : Form
  {
    public string BMCode { get; set; }
    public bool CanNext { get; set; }

    public BusinessMethodSubFormTemplate()
    {
      InitializeComponent();
    }

    protected void BusinessMethodIMMove(string IsMoveUp, DataGridView gvSelected)
    {
      try
      {
        BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel = new BusinessMethod_InternalMethodsModel();
        businessmethod_internalmethodsmodel.BMCode                              = this.BMCode;
        businessmethod_internalmethodsmodel.MethodID                            = DataGridViewCommonOperate.GetIdentilyVal<int>(gvSelected);
        BusinessMethodBLL businessmethodbll                                     = new BusinessMethodBLL();
        bool result = businessmethodbll.BusinessMethodIMMove(businessmethod_internalmethodsmodel, IsMoveUp);
        if (result)
        {
          gvSelectedLoad();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    protected virtual void gvSelectedLoad()
    {

    }
  }
}
