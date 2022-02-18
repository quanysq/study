namespace GeneratorLogAnalyze
{
  partial class FrmTUSParameter
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
      this.btnDecrypt = new System.Windows.Forms.Button();
      this.txtParameter = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(12, 146);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(708, 308);
      this.txtResult.TabIndex = 20;
      // 
      // btnDecrypt
      // 
      this.btnDecrypt.Location = new System.Drawing.Point(11, 117);
      this.btnDecrypt.Name = "btnDecrypt";
      this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
      this.btnDecrypt.TabIndex = 19;
      this.btnDecrypt.Text = "解密";
      this.btnDecrypt.UseVisualStyleBackColor = true;
      this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
      // 
      // txtParameter
      // 
      this.txtParameter.Location = new System.Drawing.Point(12, 2);
      this.txtParameter.Multiline = true;
      this.txtParameter.Name = "txtParameter";
      this.txtParameter.Size = new System.Drawing.Size(709, 109);
      this.txtParameter.TabIndex = 18;
      this.txtParameter.Text = "Please Input TUS Parameter";
      // 
      // FrmTUSParameter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 457);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnDecrypt);
      this.Controls.Add(this.txtParameter);
      this.Name = "FrmTUSParameter";
      this.Text = "解密 TUS 参数";
      this.Load += new System.EventHandler(this.FrmTUSParameter_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.Button btnDecrypt;
    private System.Windows.Forms.TextBox txtParameter;
  }
}