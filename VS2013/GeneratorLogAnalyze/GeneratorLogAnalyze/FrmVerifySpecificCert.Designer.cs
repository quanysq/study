namespace GeneratorLogAnalyze
{
  partial class FrmVerifySpecificCert
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtResult = new System.Windows.Forms.TextBox();
      this.btnVerify = new System.Windows.Forms.Button();
      this.txtCertFile = new System.Windows.Forms.TextBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.txtCertContent = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(3, 176);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtResult.Size = new System.Drawing.Size(890, 489);
      this.txtResult.TabIndex = 21;
      // 
      // btnVerify
      // 
      this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnVerify.Location = new System.Drawing.Point(818, 6);
      this.btnVerify.Name = "btnVerify";
      this.btnVerify.Size = new System.Drawing.Size(75, 23);
      this.btnVerify.TabIndex = 20;
      this.btnVerify.Text = "开始";
      this.btnVerify.UseVisualStyleBackColor = true;
      this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
      // 
      // txtCertFile
      // 
      this.txtCertFile.Location = new System.Drawing.Point(35, 6);
      this.txtCertFile.Multiline = true;
      this.txtCertFile.Name = "txtCertFile";
      this.txtCertFile.Size = new System.Drawing.Size(779, 23);
      this.txtCertFile.TabIndex = 19;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(3, 9);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(31, 13);
      this.Label1.TabIndex = 18;
      this.Label1.Text = "证书";
      // 
      // txtCertContent
      // 
      this.txtCertContent.Location = new System.Drawing.Point(3, 35);
      this.txtCertContent.Multiline = true;
      this.txtCertContent.Name = "txtCertContent";
      this.txtCertContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtCertContent.Size = new System.Drawing.Size(890, 135);
      this.txtCertContent.TabIndex = 22;
      // 
      // FrmVerifySpecificCert
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(895, 667);
      this.Controls.Add(this.txtCertContent);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnVerify);
      this.Controls.Add(this.txtCertFile);
      this.Controls.Add(this.Label1);
      this.Name = "FrmVerifySpecificCert";
      this.Text = "验证指定的证书";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.TextBox txtResult;
    internal System.Windows.Forms.Button btnVerify;
    internal System.Windows.Forms.TextBox txtCertFile;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.TextBox txtCertContent;
  }
}