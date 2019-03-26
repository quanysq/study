namespace GeneratorLogAnalyze
{
  partial class FrmConvert2Base64
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
      this.btnString = new System.Windows.Forms.Button();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.btnFile = new System.Windows.Forms.Button();
      this.txtFile = new System.Windows.Forms.TextBox();
      this.txtStartBlock = new System.Windows.Forms.TextBox();
      this.txtEndBlock = new System.Windows.Forms.TextBox();
      this.txtBlockSize = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnString
      // 
      this.btnString.Location = new System.Drawing.Point(140, 117);
      this.btnString.Name = "btnString";
      this.btnString.Size = new System.Drawing.Size(123, 23);
      this.btnString.TabIndex = 22;
      this.btnString.Text = "字符串 -> Base64";
      this.btnString.UseVisualStyleBackColor = true;
      this.btnString.Click += new System.EventHandler(this.btnString_Click);
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(12, 146);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(708, 308);
      this.txtResult.TabIndex = 21;
      // 
      // btnFile
      // 
      this.btnFile.Location = new System.Drawing.Point(11, 117);
      this.btnFile.Name = "btnFile";
      this.btnFile.Size = new System.Drawing.Size(123, 23);
      this.btnFile.TabIndex = 20;
      this.btnFile.Text = "文件 -> Base64";
      this.btnFile.UseVisualStyleBackColor = true;
      this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
      // 
      // txtFile
      // 
      this.txtFile.Location = new System.Drawing.Point(12, 2);
      this.txtFile.Multiline = true;
      this.txtFile.Name = "txtFile";
      this.txtFile.Size = new System.Drawing.Size(709, 84);
      this.txtFile.TabIndex = 19;
      this.txtFile.Text = "File Path or String";
      // 
      // txtStartBlock
      // 
      this.txtStartBlock.Location = new System.Drawing.Point(13, 92);
      this.txtStartBlock.Name = "txtStartBlock";
      this.txtStartBlock.Size = new System.Drawing.Size(169, 20);
      this.txtStartBlock.TabIndex = 23;
      this.txtStartBlock.Text = "Start Block";
      // 
      // txtEndBlock
      // 
      this.txtEndBlock.Location = new System.Drawing.Point(188, 92);
      this.txtEndBlock.Name = "txtEndBlock";
      this.txtEndBlock.Size = new System.Drawing.Size(169, 20);
      this.txtEndBlock.TabIndex = 24;
      this.txtEndBlock.Text = "End Block";
      // 
      // txtBlockSize
      // 
      this.txtBlockSize.Location = new System.Drawing.Point(363, 92);
      this.txtBlockSize.Name = "txtBlockSize";
      this.txtBlockSize.Size = new System.Drawing.Size(169, 20);
      this.txtBlockSize.TabIndex = 25;
      this.txtBlockSize.Text = "Block Size";
      // 
      // FrmConvert2Base64
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 457);
      this.Controls.Add(this.txtBlockSize);
      this.Controls.Add(this.txtEndBlock);
      this.Controls.Add(this.txtStartBlock);
      this.Controls.Add(this.btnString);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnFile);
      this.Controls.Add(this.txtFile);
      this.Name = "FrmConvert2Base64";
      this.Text = "文件转化为Base64串";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnString;
    internal System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.Button btnFile;
    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.TextBox txtStartBlock;
    private System.Windows.Forms.TextBox txtEndBlock;
    private System.Windows.Forms.TextBox txtBlockSize;
  }
}