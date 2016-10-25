namespace DBHelper
{
  partial class InternalMethodQuery
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
      this.btnOK = new System.Windows.Forms.Button();
      this.MethodName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.MethodDesc = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.FunctionType_Paging = new System.Windows.Forms.RadioButton();
      this.FunctionType_Rows = new System.Windows.Forms.RadioButton();
      this.FunctionType_View = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnOK.Location = new System.Drawing.Point(125, 375);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 35);
      this.btnOK.TabIndex = 6;
      this.btnOK.Text = "确定";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // MethodName
      // 
      this.MethodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.MethodName.Location = new System.Drawing.Point(125, 35);
      this.MethodName.Name = "MethodName";
      this.MethodName.Size = new System.Drawing.Size(202, 23);
      this.MethodName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(52, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 17);
      this.label1.TabIndex = 4;
      this.label1.Text = "方法名称";
      // 
      // MethodDesc
      // 
      this.MethodDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.MethodDesc.Location = new System.Drawing.Point(125, 84);
      this.MethodDesc.Name = "MethodDesc";
      this.MethodDesc.Size = new System.Drawing.Size(528, 23);
      this.MethodDesc.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(52, 85);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 17);
      this.label2.TabIndex = 7;
      this.label2.Text = "方法描述";
      // 
      // FunctionType_Paging
      // 
      this.FunctionType_Paging.AutoSize = true;
      this.FunctionType_Paging.Checked = true;
      this.FunctionType_Paging.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.FunctionType_Paging.Location = new System.Drawing.Point(125, 133);
      this.FunctionType_Paging.Name = "FunctionType_Paging";
      this.FunctionType_Paging.Size = new System.Drawing.Size(110, 21);
      this.FunctionType_Paging.TabIndex = 3;
      this.FunctionType_Paging.TabStop = true;
      this.FunctionType_Paging.Text = "分页返回数据";
      this.FunctionType_Paging.UseVisualStyleBackColor = true;
      this.FunctionType_Paging.Click += new System.EventHandler(this.FunctionType_Paging_Click);
      // 
      // FunctionType_Rows
      // 
      this.FunctionType_Rows.AutoSize = true;
      this.FunctionType_Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.FunctionType_Rows.Location = new System.Drawing.Point(259, 133);
      this.FunctionType_Rows.Name = "FunctionType_Rows";
      this.FunctionType_Rows.Size = new System.Drawing.Size(110, 21);
      this.FunctionType_Rows.TabIndex = 4;
      this.FunctionType_Rows.TabStop = true;
      this.FunctionType_Rows.Text = "返回多行记录";
      this.FunctionType_Rows.UseVisualStyleBackColor = true;
      this.FunctionType_Rows.Click += new System.EventHandler(this.FunctionType_Rows_Click);
      // 
      // FunctionType_View
      // 
      this.FunctionType_View.AutoSize = true;
      this.FunctionType_View.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.FunctionType_View.Location = new System.Drawing.Point(393, 133);
      this.FunctionType_View.Name = "FunctionType_View";
      this.FunctionType_View.Size = new System.Drawing.Size(110, 21);
      this.FunctionType_View.TabIndex = 5;
      this.FunctionType_View.Text = "返回单条记录";
      this.FunctionType_View.UseVisualStyleBackColor = true;
      this.FunctionType_View.Click += new System.EventHandler(this.FunctionType_View_Click);
      // 
      // InternalMethodQuery
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 437);
      this.Controls.Add(this.FunctionType_View);
      this.Controls.Add(this.FunctionType_Rows);
      this.Controls.Add(this.FunctionType_Paging);
      this.Controls.Add(this.MethodDesc);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.MethodName);
      this.Controls.Add(this.label1);
      this.FunctionType = DBHelper.Enums.FunctionType.Select_Paging;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InternalMethodQuery";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "创建查询语句方法";
      this.Load += new System.EventHandler(this.InternalMethodQuery_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox MethodName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox MethodDesc;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RadioButton FunctionType_Paging;
    private System.Windows.Forms.RadioButton FunctionType_Rows;
    private System.Windows.Forms.RadioButton FunctionType_View;
  }
}