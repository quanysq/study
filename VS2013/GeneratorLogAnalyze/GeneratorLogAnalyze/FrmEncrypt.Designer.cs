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
      this.btnDeencryptAES = new System.Windows.Forms.Button();
      this.btnEncryptAES = new System.Windows.Forms.Button();
      this.txtKey = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnDeencryptRSA = new System.Windows.Forms.Button();
      this.btnEncryptRSA = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.chkFIPS = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // txtEnctrypt
      // 
      this.txtEnctrypt.Location = new System.Drawing.Point(44, 110);
      this.txtEnctrypt.Multiline = true;
      this.txtEnctrypt.Name = "txtEnctrypt";
      this.txtEnctrypt.Size = new System.Drawing.Size(678, 84);
      this.txtEnctrypt.TabIndex = 1;
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(13, 230);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(708, 224);
      this.txtResult.TabIndex = 17;
      // 
      // btnEncrypt
      // 
      this.btnEncrypt.Location = new System.Drawing.Point(12, 201);
      this.btnEncrypt.Name = "btnEncrypt";
      this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
      this.btnEncrypt.TabIndex = 16;
      this.btnEncrypt.Text = "DES 加密";
      this.btnEncrypt.UseVisualStyleBackColor = true;
      this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
      // 
      // btnDeencrypt
      // 
      this.btnDeencrypt.Location = new System.Drawing.Point(93, 201);
      this.btnDeencrypt.Name = "btnDeencrypt";
      this.btnDeencrypt.Size = new System.Drawing.Size(75, 23);
      this.btnDeencrypt.TabIndex = 18;
      this.btnDeencrypt.Text = "DES 解密";
      this.btnDeencrypt.UseVisualStyleBackColor = true;
      this.btnDeencrypt.Click += new System.EventHandler(this.btnDeencrypt_Click);
      // 
      // btnDeencryptAES
      // 
      this.btnDeencryptAES.Location = new System.Drawing.Point(255, 201);
      this.btnDeencryptAES.Name = "btnDeencryptAES";
      this.btnDeencryptAES.Size = new System.Drawing.Size(75, 23);
      this.btnDeencryptAES.TabIndex = 20;
      this.btnDeencryptAES.Text = "AES 解密";
      this.btnDeencryptAES.UseVisualStyleBackColor = true;
      this.btnDeencryptAES.Click += new System.EventHandler(this.btnDeencryptAES_Click);
      // 
      // btnEncryptAES
      // 
      this.btnEncryptAES.Location = new System.Drawing.Point(174, 201);
      this.btnEncryptAES.Name = "btnEncryptAES";
      this.btnEncryptAES.Size = new System.Drawing.Size(75, 23);
      this.btnEncryptAES.TabIndex = 19;
      this.btnEncryptAES.Text = "AES 加密";
      this.btnEncryptAES.UseVisualStyleBackColor = true;
      this.btnEncryptAES.Click += new System.EventHandler(this.btnEncryptAES_Click);
      // 
      // txtKey
      // 
      this.txtKey.Location = new System.Drawing.Point(44, 3);
      this.txtKey.Multiline = true;
      this.txtKey.Name = "txtKey";
      this.txtKey.Size = new System.Drawing.Size(678, 80);
      this.txtKey.TabIndex = 21;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(25, 13);
      this.label1.TabIndex = 22;
      this.label1.Text = "Key";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 113);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 23;
      this.label2.Text = "Data";
      // 
      // btnDeencryptRSA
      // 
      this.btnDeencryptRSA.Location = new System.Drawing.Point(417, 201);
      this.btnDeencryptRSA.Name = "btnDeencryptRSA";
      this.btnDeencryptRSA.Size = new System.Drawing.Size(75, 23);
      this.btnDeencryptRSA.TabIndex = 25;
      this.btnDeencryptRSA.Text = "RSA 解密";
      this.btnDeencryptRSA.UseVisualStyleBackColor = true;
      this.btnDeencryptRSA.Click += new System.EventHandler(this.btnDeencryptRSA_Click);
      // 
      // btnEncryptRSA
      // 
      this.btnEncryptRSA.Location = new System.Drawing.Point(336, 201);
      this.btnEncryptRSA.Name = "btnEncryptRSA";
      this.btnEncryptRSA.Size = new System.Drawing.Size(75, 23);
      this.btnEncryptRSA.TabIndex = 24;
      this.btnEncryptRSA.Text = "RSA 加密";
      this.btnEncryptRSA.UseVisualStyleBackColor = true;
      this.btnEncryptRSA.Click += new System.EventHandler(this.btnEncryptRSA_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(41, 86);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(429, 13);
      this.label3.TabIndex = 26;
      this.label3.Text = "注：DES 无需输入 Key；AES 如果不输入 Key，则用内置的 Key；RSA 加密输入 PublicKey，解密输入 Private Key";
      // 
      // chkFIPS
      // 
      this.chkFIPS.AutoSize = true;
      this.chkFIPS.Checked = true;
      this.chkFIPS.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkFIPS.Location = new System.Drawing.Point(499, 205);
      this.chkFIPS.Name = "chkFIPS";
      this.chkFIPS.Size = new System.Drawing.Size(100, 17);
      this.chkFIPS.TabIndex = 27;
      this.chkFIPS.Text = "AES 兼容 FIPS";
      this.chkFIPS.UseVisualStyleBackColor = true;
      // 
      // FrmEncrypt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 457);
      this.Controls.Add(this.chkFIPS);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnDeencryptRSA);
      this.Controls.Add(this.btnEncryptRSA);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtKey);
      this.Controls.Add(this.btnDeencryptAES);
      this.Controls.Add(this.btnEncryptAES);
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
    private System.Windows.Forms.Button btnDeencryptAES;
    private System.Windows.Forms.Button btnEncryptAES;
    private System.Windows.Forms.TextBox txtKey;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnDeencryptRSA;
    private System.Windows.Forms.Button btnEncryptRSA;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox chkFIPS;
  }
}