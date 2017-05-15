namespace WinFormSample01.WizardSample
{
  partial class WizardPageUc02
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtSoftSourceName = new System.Windows.Forms.TextBox();
      this.txtOSType = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // txtSoftSourceName
      // 
      this.txtSoftSourceName.Location = new System.Drawing.Point(128, 70);
      this.txtSoftSourceName.Name = "txtSoftSourceName";
      this.txtSoftSourceName.Size = new System.Drawing.Size(257, 20);
      this.txtSoftSourceName.TabIndex = 6;
      // 
      // txtOSType
      // 
      this.txtOSType.Location = new System.Drawing.Point(128, 30);
      this.txtOSType.Name = "txtOSType";
      this.txtOSType.Size = new System.Drawing.Size(257, 20);
      this.txtOSType.TabIndex = 7;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(30, 70);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "SoftSourceName";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "OSType";
      // 
      // WizardPageUc02
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtSoftSourceName);
      this.Controls.Add(this.txtOSType);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "WizardPageUc02";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSoftSourceName;
    private System.Windows.Forms.TextBox txtOSType;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;

  }
}
