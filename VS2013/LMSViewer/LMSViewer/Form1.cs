using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace LMSViewer
{
  public partial class Form1 : Form
  {
    private MethodInfo[] LMSMethodInfoArray = null;
    private string[] CanFurtherMethods  = null;

    public Form1()
    {
      InitializeComponent();

      ParameterList.AutoGenerateColumns = false;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Init();
      LMSMethodInfoArray = Common.GetLMSMethodInfoArray();

      FillLmsMethod2Listbox();
    }

    private void Init()
    {
      lblLMSURL.Text    = ConfigurationManager.AppSettings["LMSURL"];
      CanFurtherMethods = ConfigurationManager.AppSettings["CanFurther"].Split(';');
    }

    private void FillLmsMethod2Listbox()
    {
      List<string> LmsMethodList = Common.GetLMSMethodList(LMSMethodInfoArray);
      if (LmsMethodList.Count == 0) return;
      MethodList.BeginUpdate();
      MethodList.DataSource = LmsMethodList;
      MethodList.EndUpdate();
    }

    private void MethodList_SelectedIndexChanged(object sender, EventArgs e)
    {
      string mn              = MethodList.SelectedValue.ToString();
      this.MethodName.Text   = mn;
      MethodInfo mi          = Common.GetLMSMethodByName(LMSMethodInfoArray, mn);
      this.MethodReturn.Text = mi.ReturnType.ToString();

      string CanFurtherMname = CanFurtherMethods.FirstOrDefault(x => x.Equals(mn, StringComparison.OrdinalIgnoreCase));
      if (CanFurtherMname == null)
      {
        BtnFurther.Visible = false;
        BtnFurther.Tag     = "";
      }
      else
      {
        BtnFurther.Visible = true;
        BtnFurther.Tag     = CanFurtherMname;
      }

      FillMethodParameter(mi);
      MethodResult.Text = "";
    }

    private void FillMethodParameter(MethodInfo mi)
    {
      ParameterList.Columns.Clear();

      ParameterInfo[] pi = Common.GetMethodParameters(mi);
      if (pi == null || pi.Length == 0) return;
      ParameterList.DataSource = pi;
      AddColums2ParameterList();
    }

    private void AddColums2ParameterList()
    {
      DataGridViewTextBoxColumn PositionColumn = new DataGridViewTextBoxColumn();
      PositionColumn.DataPropertyName          = "Position";
      PositionColumn.Name                      = "Position";
      PositionColumn.HeaderText                = "RN";
      PositionColumn.Width                     = 40;
      PositionColumn.ReadOnly                  = true;
      ParameterList.Columns.Add(PositionColumn);

      DataGridViewTextBoxColumn NameColumn     = new DataGridViewTextBoxColumn();
      NameColumn.DataPropertyName              = "Name";
      NameColumn.Name                          = "Name";
      NameColumn.HeaderText                    = "Name";
      NameColumn.Width                         = 180;
      NameColumn.ReadOnly                      = true;
      ParameterList.Columns.Add(NameColumn);

      DataGridViewTextBoxColumn TypeColumn     = new DataGridViewTextBoxColumn();
      TypeColumn.DataPropertyName              = "ParameterType";
      TypeColumn.Name                          = "ParameterType";
      TypeColumn.HeaderText                    = "ParameterType";
      TypeColumn.Width                         = 120;
      TypeColumn.ReadOnly                      = true;
      ParameterList.Columns.Add(TypeColumn);

      DataGridViewTextBoxColumn ValueColumn    = new DataGridViewTextBoxColumn();
      ValueColumn.Name                         = "ParameterValue";
      ValueColumn.HeaderText                   = "ParameterValue ( NOTE: input the parameter value in here )";
      ValueColumn.Width                        = 450;
      ParameterList.Columns.Add(ValueColumn);
    }

    private void BtnRun_Click(object sender, EventArgs e)
    {
      string lmsurl      = lblLMSURL.Text;
      string methodname  = MethodName.Text.Trim();
      int parametercount = ParameterList.RowCount;
      object[] args      = new object[parametercount];
      for (int i = 0; i < parametercount; i++)
      {
        if (ParameterList.Rows[i].Cells["ParameterValue"].Value == null)
        {
          MessageBox.Show("Please input the parameter value.");
          return;
        }

        string parametervalue = ParameterList.Rows[i].Cells["ParameterValue"].Value.ToString();
        args[i] = parametervalue;
      }
      object o                                = Common.ExecuteMethod<ILMSService>(lmsurl, methodname, args);
      string returntype                       = MethodReturn.Text.Trim();
      MethodResultHandleFactory ResultFactory = new MethodResultHandleFactory();
      MethodResult.Text                       = ResultFactory.GetResultAfterHandle(returntype, o);
    }

    private void BtnFurther_Click(object sender, EventArgs e)
    {
      string FrmName = BtnFurther.Tag.ToString();
      if (string.IsNullOrWhiteSpace(FrmName)) return;

      string mParentFormInfo = MethodResult.Text.Trim();
      if (string.IsNullOrWhiteSpace(mParentFormInfo))
      {
        MessageBox.Show("Please run the method first");
        return;
      }

      Type type          = Assembly.Load("LMSViewer").GetTypes().FirstOrDefault(x => x.Name.Equals(FrmName, StringComparison.OrdinalIgnoreCase));
      if (type           == null) return;
      SubForm frm        = (SubForm)Activator.CreateInstance(type);
      frm.ParentFormInfo = MethodResult.Text.Trim();
      frm.ShowDialog();
    }

    private void MethodResult_KeyUp(object sender, KeyEventArgs e)
    {
      Common c = new Common();
      c.SelectAllByKey(sender, e);
    }
  }
}
