namespace GeneratorLogAnalyze
{
  partial class FrmEncrypt
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
      this.txtEnctrypt = new System.Windows.Forms.TextBox();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.btnEncrypt = new System.Windows.Forms.Button();
      this.btnDeencrypt = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtEnctrypt
      // 
      this.txtEnctrypt.Location = new System.Drawing.Point(13, 2);
      this.txtEnctrypt.Multiline = true;
      this.txtEnctrypt.Name = "txtEnctrypt";
      this.txtEnctrypt.Size = new System.Drawing.Size(709, 109);
      this.txtEnctrypt.TabIndex = 1;
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(13, 146);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(708, 308);
      this.txtResult.TabIndex = 17;
      // 
      // btnEncrypt
      // 
      this.btnEncrypt.Location = new System.Drawing.Point(12, 117);
      this.btnEncrypt.Name = "btnEncrypt";
      this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
      this.btnEncrypt.TabIndex = 16;
      this.btnEncrypt.Text = "加密";
      this.btnEncrypt.UseVisualStyleBackColor = true;
      this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
      // 
      // btnDeencrypt
      // 
      this.btnDeencrypt.Location = new System.Drawing.Point(93, 117);
      this.btnDeencrypt.Name = "btnDeencrypt";
      this.btnDeencrypt.Size = new System.Drawing.Size(75, 23);
      this.btnDeencrypt.TabIndex = 18;
      this.btnDeencrypt.Text = "解密";
      this.btnDeencrypt.UseVisualStyleBackColor = true;
      this.btnDeencrypt.Click += new System.EventHandler(this.btnDeencrypt_Click);
      // 
      // FrmEncrypt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 457);
      this.Controls.Add(this.btnDeencrypt);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnEncrypt);
      this.Controls.Add(this.txtEnctrypt);
      this.Name = "FrmEncrypt";
      this.Text = "BDNA加解密";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtEnctrypt;
    internal System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.Button btnEncrypt;
    private System.Windows.Forms.Button btnDeencrypt;
  }
}