using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTestTools
{
  public partial class Form1 : Form
  {
    private ClsReflection clsreflection = null;
    public Form1()
    {
      InitializeComponent();
    }


    private void BtnGetmethods_Click(object sender, EventArgs e)
    {
      string AssemblyName = TxtAssembly.Text.Trim();
      string NamespaceName = TxtNamespace.Text.Trim();
      string ClassName = TxtClass.Text.Trim();

      bool validata = ValidataAssembly(AssemblyName, NamespaceName, ClassName);
      if (!validata) return;

      clsreflection = new ClsReflection(AssemblyName, NamespaceName, ClassName);

      FillMethod2Listbox();
    }

    private bool ValidataAssembly(string AssemblyName, string NamespaceName, string ClassName)
    {
      if (string.IsNullOrWhiteSpace(AssemblyName) ||
          string.IsNullOrWhiteSpace(NamespaceName) ||
          string.IsNullOrWhiteSpace(ClassName))
      {
        MessageBox.Show("Please fill in the complete assembly information.! \n [Assembly, Namespace, ClassName]");
        TxtAssembly.Focus();
        return false;
      }
      return true;
    }

    private void FillMethod2Listbox()
    {
      List<string> MethodList = clsreflection.GetMethodList();
      if (MethodList.Count == 0) return;
      LbMethods.BeginUpdate();
      LbMethods.DataSource = MethodList;
      LbMethods.EndUpdate();

      BtnSingleTest.Enabled = true;
      BtnMultiTest.Enabled = true;
    }

    private void BtnSingleTest_Click(object sender, EventArgs e)
    {
      string MethodName = LbMethods.SelectedValue.ToString();
      List<UnitTestResult> UnitTestResultList = clsreflection.ExecuteMethod(MethodName);

      DisplayUnitTestResult(UnitTestResultList);
    }

    private void BtnMultiTest_Click(object sender, EventArgs e)
    {
      List<UnitTestResult> UnitTestResultList = clsreflection.ExecuteAllMethods();

      DisplayUnitTestResult(UnitTestResultList);
    }

    private void DisplayUnitTestResult(List<UnitTestResult> UnitTestResultList)
    {
      TxtTestresult.Text = "";
      StringBuilder sb = new StringBuilder(1024);
      foreach (UnitTestResult Utr in UnitTestResultList)
      {
        sb.AppendLine(string.Format("Test Method: {0}", Utr.TestMethodName));
        sb.AppendLine(string.Format("Test Status: {0}", Utr.Status.ToString()));
        if (Utr.Exception != null) sb.AppendLine(Utr.Exception.ToString());
        sb.AppendLine("================================");
        sb.AppendLine("");
      }

      TxtTestresult.Text = sb.ToString();
    }

    private void BtnSelect_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      //ofd.InitialDirectory = @"D:\";
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        TxtAssembly.Text = ofd.FileName;
        TxtNamespace.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
      }
    }
  }
}
