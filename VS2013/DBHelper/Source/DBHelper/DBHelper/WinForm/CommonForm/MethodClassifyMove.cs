using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Model;
using DBHelper.Enums;
using DBHelper.Common;
using DBHelper.BLL;
using DBHelper.Util;
using DBHelper.Interface;

namespace DBHelper
{
  public partial class MethodClassifyMove : Form
  {
    public int ClassifyType { get; set; }
    public string MethodListJoin { get; set; }

    public MethodClassifyMove()
    {
      InitializeComponent();
      this.gvMethodClassify.AutoGenerateColumns = false;
    }

    private void MethodClassifyMove_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvMethodClassify);
      MethodClassifyListLoad();
    }

    public void MethodClassifyListLoad()
    {
      MethodClassifyBLL methodclassifybll = new MethodClassifyBLL();
      DataTable result                    = methodclassifybll.MethodClassifyList(ClassifyType.ToString(), Common.Common.OperateDbID.ToString());
      gvMethodClassify.DataSource         = result;
    }

    private void btnMove_Click(object sender, EventArgs e)
    {
      string ClassifyID = DataGridViewCommonOperate.GetIdentilyVal<string>(gvMethodClassify);
      IMoveClassify IMC = null; 
      if (ClassifyType == 1)
        IMC = new InternalMethodMoveClassify();
      else
        IMC = new BusinesMethodMethodMoveClassify();

      try
      {
        IMC.MoveClassify(ClassifyID, MethodListJoin);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }

    private class InternalMethodMoveClassify : IMoveClassify
    {
      public bool MoveClassify(string classifyid, string methodlistjoin)
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        bool result                         = internalmethodbll.InternalMethodMoveClassify(classifyid, methodlistjoin);
        return result;
      }
    }

    private class BusinesMethodMethodMoveClassify : IMoveClassify
    {
      public bool MoveClassify(string classifyid, string methodlistjoin)
      {
        BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
        bool result                         = businessmethodbll.BusinessMethodMoveClassify(classifyid, methodlistjoin);
        return result;
      }
    }
  }
}
