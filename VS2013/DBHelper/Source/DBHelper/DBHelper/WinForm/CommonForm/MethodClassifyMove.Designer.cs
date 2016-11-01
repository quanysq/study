namespace DBHelper
{
  partial class MethodClassifyMove
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnMove = new System.Windows.Forms.Button();
      this.gvMethodClassify = new System.Windows.Forms.DataGridView();
      this.panel3 = new System.Windows.Forms.Panel();
      this.ClassifyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ClassifyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvMethodClassify)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.gvMethodClassify);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(315, 203);
      this.panel1.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnMove);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 173);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(315, 30);
      this.panel2.TabIndex = 1;
      // 
      // btnMove
      // 
      this.btnMove.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnMove.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnMove.Location = new System.Drawing.Point(221, 0);
      this.btnMove.Name = "btnMove";
      this.btnMove.Size = new System.Drawing.Size(94, 30);
      this.btnMove.TabIndex = 5;
      this.btnMove.Text = "确定";
      this.btnMove.UseVisualStyleBackColor = true;
      this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
      // 
      // gvMethodClassify
      // 
      this.gvMethodClassify.AllowUserToAddRows = false;
      this.gvMethodClassify.AllowUserToDeleteRows = false;
      this.gvMethodClassify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvMethodClassify.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassifyID,
            this.ClassifyName});
      this.gvMethodClassify.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvMethodClassify.Location = new System.Drawing.Point(0, 0);
      this.gvMethodClassify.Name = "gvMethodClassify";
      this.gvMethodClassify.ReadOnly = true;
      this.gvMethodClassify.Size = new System.Drawing.Size(315, 203);
      this.gvMethodClassify.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel3.Location = new System.Drawing.Point(0, 169);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(315, 4);
      this.panel3.TabIndex = 2;
      // 
      // ClassifyID
      // 
      this.ClassifyID.DataPropertyName = "ClassifyID";
      this.ClassifyID.HeaderText = "ID";
      this.ClassifyID.Name = "ClassifyID";
      this.ClassifyID.ReadOnly = true;
      this.ClassifyID.Width = 80;
      // 
      // ClassifyName
      // 
      this.ClassifyName.DataPropertyName = "ClassifyName";
      this.ClassifyName.HeaderText = "类别名称";
      this.ClassifyName.Name = "ClassifyName";
      this.ClassifyName.ReadOnly = true;
      this.ClassifyName.Width = 220;
      // 
      // MethodClassifyMove
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(315, 203);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "MethodClassifyMove";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "移至...";
      this.Load += new System.EventHandler(this.MethodClassifyMove_Load);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvMethodClassify)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.DataGridView gvMethodClassify;
    private System.Windows.Forms.Button btnMove;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.DataGridViewTextBoxColumn ClassifyID;
    private System.Windows.Forms.DataGridViewTextBoxColumn ClassifyName;
  }
}