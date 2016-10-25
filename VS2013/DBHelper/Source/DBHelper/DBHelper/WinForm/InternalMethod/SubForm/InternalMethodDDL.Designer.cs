namespace DBHelper
{
  partial class InternalMethodDDL
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
      this.MethodDesc = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.MethodName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuccessMsg = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.FailMsg = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
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
      this.label2.TabIndex = 15;
      this.label2.Text = "方法描述";
      // 
      // btnOK
      // 
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnOK.Location = new System.Drawing.Point(125, 375);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 35);
      this.btnOK.TabIndex = 5;
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
      this.label1.TabIndex = 12;
      this.label1.Text = "方法名称";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label3.Location = new System.Drawing.Point(52, 134);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(64, 17);
      this.label3.TabIndex = 15;
      this.label3.Text = "成功消息";
      // 
      // SuccessMsg
      // 
      this.SuccessMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.SuccessMsg.Location = new System.Drawing.Point(125, 133);
      this.SuccessMsg.Name = "SuccessMsg";
      this.SuccessMsg.Size = new System.Drawing.Size(528, 23);
      this.SuccessMsg.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label4.Location = new System.Drawing.Point(52, 183);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 17);
      this.label4.TabIndex = 15;
      this.label4.Text = "失败消息";
      // 
      // FailMsg
      // 
      this.FailMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.FailMsg.Location = new System.Drawing.Point(125, 182);
      this.FailMsg.Name = "FailMsg";
      this.FailMsg.Size = new System.Drawing.Size(528, 23);
      this.FailMsg.TabIndex = 4;
      // 
      // InternalMethodDDL
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 437);
      this.Controls.Add(this.FailMsg);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.SuccessMsg);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.MethodDesc);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.MethodName);
      this.Controls.Add(this.label1);
      this.FunctionType = DBHelper.Enums.FunctionType.Insert;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InternalMethodDDL";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "InternalMethodDDL";
      this.Load += new System.EventHandler(this.InternalMethodDDL_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox MethodDesc;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox MethodName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox SuccessMsg;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox FailMsg;
  }
}