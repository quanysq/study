namespace WinFormSample01.DataGridViewSample
{
  partial class SpanHeaderFrm
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
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.spanHeaderDataGridView1 = new WinFormSample01.DataGridViewSample.SpanHeaderDataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spanHeaderDataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
      this.dataGridView1.Location = new System.Drawing.Point(11, 242);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(296, 185);
      this.dataGridView1.TabIndex = 3;
      // 
      // Column5
      // 
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      // 
      // Column6
      // 
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      // 
      // Column7
      // 
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      // 
      // Column8
      // 
      this.Column8.HeaderText = "Column8";
      this.Column8.Name = "Column8";
      // 
      // spanHeaderDataGridView1
      // 
      this.spanHeaderDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.spanHeaderDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
      this.spanHeaderDataGridView1.Location = new System.Drawing.Point(11, 12);
      this.spanHeaderDataGridView1.Name = "spanHeaderDataGridView1";
      this.spanHeaderDataGridView1.Size = new System.Drawing.Size(311, 212);
      this.spanHeaderDataGridView1.TabIndex = 2;
      // 
      // Column1
      // 
      this.Column1.DataPropertyName = "1";
      this.Column1.HeaderText = "国家";
      this.Column1.Name = "Column1";
      // 
      // Column2
      // 
      this.Column2.DataPropertyName = "2";
      this.Column2.HeaderText = "城市";
      this.Column2.Name = "Column2";
      // 
      // Column3
      // 
      this.Column3.DataPropertyName = "3";
      this.Column3.HeaderText = "男";
      this.Column3.Name = "Column3";
      // 
      // Column4
      // 
      this.Column4.DataPropertyName = "4";
      this.Column4.HeaderText = "女";
      this.Column4.Name = "Column4";
      // 
      // SpanHeaderFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(517, 451);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.spanHeaderDataGridView1);
      this.Name = "SpanHeaderFrm";
      this.Text = "SpanHeaderFrm";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spanHeaderDataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private SpanHeaderDataGridView spanHeaderDataGridView1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
  }
}