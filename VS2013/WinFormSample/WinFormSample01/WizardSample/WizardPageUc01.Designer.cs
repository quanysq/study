namespace WinFormSample01.WizardSample
{
  partial class WizardPageUc01
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtTemplateName = new System.Windows.Forms.TextBox();
      this.txtTemplateType = new System.Windows.Forms.TextBox();
      this.txtTemplateDesc = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(79, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "TemplateName";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(30, 70);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "TemplateType";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(30, 140);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(76, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "TemplateDesc";
      // 
      // txtTemplateName
      // 
      this.txtTemplateName.Location = new System.Drawing.Point(119, 30);
      this.txtTemplateName.Name = "txtTemplateName";
      this.txtTemplateName.Size = new System.Drawing.Size(257, 20);
      this.txtTemplateName.TabIndex = 1;
      // 
      // txtTemplateType
      // 
      this.txtTemplateType.Location = new System.Drawing.Point(119, 70);
      this.txtTemplateType.Multiline = true;
      this.txtTemplateType.Name = "txtTemplateType";
      this.txtTemplateType.Size = new System.Drawing.Size(257, 50);
      this.txtTemplateType.TabIndex = 1;
      // 
      // txtTemplateDesc
      // 
      this.txtTemplateDesc.Location = new System.Drawing.Point(119, 140);
      this.txtTemplateDesc.Name = "txtTemplateDesc";
      this.txtTemplateDesc.Size = new System.Drawing.Size(257, 20);
      this.txtTemplateDesc.TabIndex = 1;
      // 
      // WizardPageUc01
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtTemplateType);
      this.Controls.Add(this.txtTemplateDesc);
      this.Controls.Add(this.txtTemplateName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "WizardPageUc01";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtTemplateName;
    private System.Windows.Forms.TextBox txtTemplateType;
    private System.Windows.Forms.TextBox txtTemplateDesc;

  }
}
