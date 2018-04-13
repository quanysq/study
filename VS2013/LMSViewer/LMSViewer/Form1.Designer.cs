namespace LMSViewer
{
  partial class Form1
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
      this.MethodList = new System.Windows.Forms.ListBox();
      this.MethodName = new System.Windows.Forms.TextBox();
      this.MethodReturn = new System.Windows.Forms.TextBox();
      this.ParameterList = new System.Windows.Forms.DataGridView();
      this.BtnRun = new System.Windows.Forms.Button();
      this.MethodResult = new System.Windows.Forms.TextBox();
      this.lblLMSURL = new System.Windows.Forms.Label();
      this.BtnFurther = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.ParameterList)).BeginInit();
      this.SuspendLayout();
      // 
      // MethodList
      // 
      this.MethodList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.MethodList.FormattingEnabled = true;
      this.MethodList.ItemHeight = 17;
      this.MethodList.Location = new System.Drawing.Point(12, 12);
      this.MethodList.Name = "MethodList";
      this.MethodList.Size = new System.Drawing.Size(295, 701);
      this.MethodList.TabIndex = 0;
      this.MethodList.SelectedIndexChanged += new System.EventHandler(this.MethodList_SelectedIndexChanged);
      // 
      // MethodName
      // 
      this.MethodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MethodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.MethodName.Location = new System.Drawing.Point(314, 13);
      this.MethodName.Name = "MethodName";
      this.MethodName.ReadOnly = true;
      this.MethodName.Size = new System.Drawing.Size(895, 23);
      this.MethodName.TabIndex = 1;
      // 
      // MethodReturn
      // 
      this.MethodReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MethodReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.MethodReturn.Location = new System.Drawing.Point(314, 39);
      this.MethodReturn.Name = "MethodReturn";
      this.MethodReturn.ReadOnly = true;
      this.MethodReturn.Size = new System.Drawing.Size(895, 23);
      this.MethodReturn.TabIndex = 2;
      // 
      // ParameterList
      // 
      this.ParameterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ParameterList.Location = new System.Drawing.Point(314, 69);
      this.ParameterList.Name = "ParameterList";
      this.ParameterList.Size = new System.Drawing.Size(895, 183);
      this.ParameterList.TabIndex = 3;
      // 
      // BtnRun
      // 
      this.BtnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.BtnRun.Location = new System.Drawing.Point(314, 258);
      this.BtnRun.Name = "BtnRun";
      this.BtnRun.Size = new System.Drawing.Size(114, 31);
      this.BtnRun.TabIndex = 4;
      this.BtnRun.Text = "Run Method";
      this.BtnRun.UseVisualStyleBackColor = true;
      this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
      // 
      // MethodResult
      // 
      this.MethodResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MethodResult.Location = new System.Drawing.Point(314, 295);
      this.MethodResult.Multiline = true;
      this.MethodResult.Name = "MethodResult";
      this.MethodResult.ReadOnly = true;
      this.MethodResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.MethodResult.Size = new System.Drawing.Size(895, 418);
      this.MethodResult.TabIndex = 5;
      this.MethodResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MethodResult_KeyUp);
      // 
      // lblLMSURL
      // 
      this.lblLMSURL.AutoSize = true;
      this.lblLMSURL.Location = new System.Drawing.Point(434, 268);
      this.lblLMSURL.Name = "lblLMSURL";
      this.lblLMSURL.Size = new System.Drawing.Size(0, 13);
      this.lblLMSURL.TabIndex = 6;
      // 
      // BtnFurther
      // 
      this.BtnFurther.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.BtnFurther.Location = new System.Drawing.Point(1018, 258);
      this.BtnFurther.Name = "BtnFurther";
      this.BtnFurther.Size = new System.Drawing.Size(191, 31);
      this.BtnFurther.TabIndex = 7;
      this.BtnFurther.Text = "Further analysis data";
      this.BtnFurther.UseVisualStyleBackColor = true;
      this.BtnFurther.Visible = false;
      this.BtnFurther.Click += new System.EventHandler(this.BtnFurther_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1221, 722);
      this.Controls.Add(this.BtnFurther);
      this.Controls.Add(this.lblLMSURL);
      this.Controls.Add(this.MethodResult);
      this.Controls.Add(this.BtnRun);
      this.Controls.Add(this.ParameterList);
      this.Controls.Add(this.MethodReturn);
      this.Controls.Add(this.MethodName);
      this.Controls.Add(this.MethodList);
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "LMS Viewer";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ParameterList)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox MethodList;
    private System.Windows.Forms.TextBox MethodName;
    private System.Windows.Forms.TextBox MethodReturn;
    private System.Windows.Forms.DataGridView ParameterList;
    private System.Windows.Forms.Button BtnRun;
    private System.Windows.Forms.TextBox MethodResult;
    private System.Windows.Forms.Label lblLMSURL;
    private System.Windows.Forms.Button BtnFurther;
  }
}

