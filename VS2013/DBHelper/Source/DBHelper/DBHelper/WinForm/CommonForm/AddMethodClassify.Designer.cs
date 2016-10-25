namespace DBHelper
{
  partial class AddMethodClassify
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
      this.ClassifyName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnAddClassify = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ClassifyName
      // 
      this.ClassifyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ClassifyName.Location = new System.Drawing.Point(104, 39);
      this.ClassifyName.Name = "ClassifyName";
      this.ClassifyName.Size = new System.Drawing.Size(236, 23);
      this.ClassifyName.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(34, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "类别名称";
      // 
      // btnAddClassify
      // 
      this.btnAddClassify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnAddClassify.Location = new System.Drawing.Point(104, 79);
      this.btnAddClassify.Name = "btnAddClassify";
      this.btnAddClassify.Size = new System.Drawing.Size(75, 35);
      this.btnAddClassify.TabIndex = 4;
      this.btnAddClassify.Text = "添加";
      this.btnAddClassify.UseVisualStyleBackColor = true;
      this.btnAddClassify.Click += new System.EventHandler(this.btnAddClassify_Click);
      // 
      // AddMethodClassify
      // 
      this.AcceptButton = this.btnAddClassify;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(380, 154);
      this.Controls.Add(this.btnAddClassify);
      this.Controls.Add(this.ClassifyName);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddMethodClassify";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "AddMethodClassify";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox ClassifyName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnAddClassify;
  }
}