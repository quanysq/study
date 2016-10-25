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
using DBHelper.Enums;
using DBHelper.Common;
using DBHelper.BLL;
using DBHelper.Util;
using System.Threading;

namespace DBHelper
{
  public partial class MethodClassifyList : UserControl
  {
    public delegate void MethodClassifyListEventHandle(object sender, MethodClassifyListEventArgs e);
    public int ClassifyType { get; set; }
    public string AddMethodClassifyFrm_Title { get; set; }
    public event MethodClassifyListEventHandle OnListBoxSelectedIndexChanged;

    public MethodClassifyList()
    {
      InitializeComponent();
    }

    private void MethodClassifyList_Load(object sender, EventArgs e)
    {
      if (this.DesignMode) return;
      btnAddMethodClassify.Text = AddMethodClassifyFrm_Title;
      MethodClassifyLoad();

    }

    private void btnAddMethodClassify_Click(object sender, EventArgs e)
    {
      AddMethodClassify AddMethodClassifyFrm = new AddMethodClassify();
      AddMethodClassifyFrm.Text              = AddMethodClassifyFrm_Title;
      AddMethodClassifyFrm.ClassifyType      = ClassifyType;
      AddMethodClassifyFrm.ShowDialog();
      if (AddMethodClassifyFrm.DialogResult == DialogResult.OK)
      {
        MethodClassifyLoad();
      }
    }

    private void MethodClassifyLoad()
    {
      lstMethodClassify.Items.Clear();
      MethodClassifyBLL methodclassifybll = new MethodClassifyBLL();
      DataTable dt = methodclassifybll.MethodClassifyList(ClassifyType.ToString(), Common.Common.OperateDbID.ToString());
      Common.ListControlOperater.Bind2ListCtr(dt, lstMethodClassify);
    }

    private void lstMethodClassify_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        int posindex = lstMethodClassify.IndexFromPoint(new Point(e.X, e.Y));
        lstMethodClassify.ContextMenuStrip = null;
        if (posindex >= 0 && posindex < lstMethodClassify.Items.Count)
        {
          lstMethodClassify.SelectedIndex = posindex;
          cmMethodClassify.Show(lstMethodClassify, new Point(e.X, e.Y));
        }
      }
      lstMethodClassify.Refresh();
    }

    private void miDeleteMethodClassify_Click(object sender, EventArgs e)
    {
      try
      {
        ListBox listbox                     = cmMethodClassify.SourceControl as ListBox;
        ComboBoxItemModel listitem          = listbox.SelectedItem as ComboBoxItemModel;
        string ClassifyID                   = CommonUtil.TranNull<string>(listitem.Value);
        MethodClassifyBLL methodclassifybll = new MethodClassifyBLL();
        bool result                         = methodclassifybll.MethodClassifyDelete(ClassifyID);
        if (result)
        {
          int CurrentIndex = listbox.SelectedIndex;
          listbox.Items.Remove(listbox.Items[CurrentIndex]);
        }
      }
      catch(Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }

    private void lstMethodClassify_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBoxItemModel listitem            = lstMethodClassify.SelectedItem as ComboBoxItemModel;
      if (listitem == null) return;
      MethodClassifyListEventArgs eventargs = new MethodClassifyListEventArgs();
      eventargs.Key                         = listitem.Key;
      eventargs.Value                       = CommonUtil.TranNull<int>(listitem.Value);
      if (OnListBoxSelectedIndexChanged != null)
      {
        if (eventargs.Value == MethodClassifyListEventArgs.OldValue) return;
        MethodClassifyListEventArgs.OldValue = eventargs.Value;
        MethodClassifyListEventArgs.OldKey   = eventargs.Key;
        OnListBoxSelectedIndexChanged(this, eventargs);
      }
    }
  }
}
