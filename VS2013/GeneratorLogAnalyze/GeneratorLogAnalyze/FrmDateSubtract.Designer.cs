﻿namespace GeneratorLogAnalyze
{
  partial class FrmDateSubtract
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
      this.txtDate1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtDate2 = new System.Windows.Forms.TextBox();
      this.btnOK = new System.Windows.Forms.Button();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtDate1
      // 
      this.txtDate1.Location = new System.Drawing.Point(13, 24);
      this.txtDate1.Name = "txtDate1";
      this.txtDate1.Size = new System.Drawing.Size(217, 20);
      this.txtDate1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(237, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(19, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "减";
      // 
      // txtDate2
      // 
      this.txtDate2.Location = new System.Drawing.Point(262, 24);
      this.txtDate2.Name = "txtDate2";
      this.txtDate2.Size = new System.Drawing.Size(217, 20);
      this.txtDate2.TabIndex = 0;
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(13, 61);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 2;
      this.btnOK.Text = "等于";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(13, 100);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(708, 345);
      this.txtResult.TabIndex = 15;
      // 
      // FrmDateSubtract
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 457);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtDate2);
      this.Controls.Add(this.txtDate1);
      this.Name = "FrmDateSubtract";
      this.Text = "日期相减";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtDate1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDate2;
    private System.Windows.Forms.Button btnOK;
    internal System.Windows.Forms.TextBox txtResult;
  }
}