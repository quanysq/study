namespace WinFormSample01.DataGridViewSample
{
  partial class NestedDatagridviewFrm
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.Expand = new System.Windows.Forms.DataGridViewImageColumn();
      this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Expand,
            this.CName,
            this.Sex});
      this.dataGridView1.Location = new System.Drawing.Point(12, 43);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(663, 334);
      this.dataGridView1.TabIndex = 0;
      // 
      // Expand
      // 
      this.Expand.HeaderText = "";
      this.Expand.Image = global::WinFormSample01.Properties.Resources.icon_add_16x16;
      this.Expand.Name = "Expand";
      this.Expand.ToolTipText = "展开/折叠";
      this.Expand.Width = 20;
      // 
      // CName
      // 
      this.CName.DataPropertyName = "CName";
      this.CName.HeaderText = "Name";
      this.CName.Name = "CName";
      this.CName.ReadOnly = true;
      // 
      // Sex
      // 
      this.Sex.DataPropertyName = "Sex";
      this.Sex.HeaderText = "Sex";
      this.Sex.Name = "Sex";
      this.Sex.ReadOnly = true;
      // 
      // NestedDatagridviewFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(710, 460);
      this.Controls.Add(this.dataGridView1);
      this.Name = "NestedDatagridviewFrm";
      this.Text = "NestedDatagridviewFrm";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewImageColumn Expand;
    private System.Windows.Forms.DataGridViewTextBoxColumn CName;
    private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
  }
}