using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.WizardSample
{
  public partial class WizardPageTemplate : UserControl
  {
    protected WizardPageTemplate()
    {
      InitializeComponent();
      Load += WizardPageTemplate_Load;
      Size = new Size(636, 390);
    }

    void WizardPageTemplate_Load(object sender, EventArgs e)
    {
      DisplayData();
    }

    public bool IsFirstPage { get; set; }

    public bool IsLastPage { get; set; }

    public int PageOrder { get; set; }

    public string ValidationMessage { get; set; }

    public bool ValidationStatus { get; set; }
    
    public virtual void SaveData()
    {
      throw new NotImplementedException();
    }
    protected virtual bool ValidateData()
    {
      throw new NotImplementedException();
    }

    protected virtual void DisplayData()
    {
      //throw new NotImplementedException();
    }
  }
}
