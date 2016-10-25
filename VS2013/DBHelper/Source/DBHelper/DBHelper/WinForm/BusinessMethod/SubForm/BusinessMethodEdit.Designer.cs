namespace DBHelper
{
  partial class BusinessMethodEdit
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
      this.cbbFunctionType = new System.Windows.Forms.ComboBox();
      this.BMDesc = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.txtBMCode = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cbbFunctionType
      // 
      this.cbbFunctionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.cbbFunctionType.FormattingEnabled = true;
      this.cbbFunctionType.Location = new System.Drawing.Point(125, 123);
      this.cbbFunctionType.Name = "cbbFunctionType";
      this.cbbFunctionType.Size = new System.Drawing.Size(262, 25);
      this.cbbFunctionType.TabIndex = 27;
      // 
      // BMDesc
      // 
      this.BMDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.BMDesc.Location = new System.Drawing.Point(125, 77);
      this.BMDesc.Name = "BMDesc";
      this.BMDesc.Size = new System.Drawing.Size(528, 23);
      this.BMDesc.TabIndex = 26;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(52, 78);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 17);
      this.label2.TabIndex = 35;
      this.label2.Text = "方法描述";
      // 
      // btnOK
      // 
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnOK.Location = new System.Drawing.Point(125, 346);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 32);
      this.btnOK.TabIndex = 30;
      this.btnOK.Text = "确定";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label6.Location = new System.Drawing.Point(52, 124);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(64, 17);
      this.label6.TabIndex = 31;
      this.label6.Text = "方法功能";
      // 
      // txtBMCode
      // 
      this.txtBMCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtBMCode.Location = new System.Drawing.Point(125, 32);
      this.txtBMCode.Name = "txtBMCode";
      this.txtBMCode.ReadOnly = true;
      this.txtBMCode.Size = new System.Drawing.Size(262, 23);
      this.txtBMCode.TabIndex = 25;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(52, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 17);
      this.label1.TabIndex = 32;
      this.label1.Text = "方法代码";
      // 
      // BusinessMethodEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 403);
      this.Controls.Add(this.cbbFunctionType);
      this.Controls.Add(this.BMDesc);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtBMCode);
      this.Controls.Add(this.label1);
      this.Name = "BusinessMethodEdit";
      this.Text = "BusinessMethodEdit";
      this.Load += new System.EventHandler(this.BusinessMethodEdit_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbbFunctionType;
    private System.Windows.Forms.TextBox BMDesc;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtBMCode;
    private System.Windows.Forms.Label label1;
  }
}