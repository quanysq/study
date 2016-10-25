namespace DBHelper
{
  partial class BusinessMethodParameter
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
      this.components = new System.ComponentModel.Container();
      this.CMgvParameter = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnExtractParameter = new System.Windows.Forms.Button();
      this.gvParameter = new System.Windows.Forms.DataGridView();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.ParameterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ParameterDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ParameterDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.ParameterDirection = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.ParameterValidateType = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.ConstValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CMgvParameter.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvParameter)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // CMgvParameter
      // 
      this.CMgvParameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDelete});
      this.CMgvParameter.Name = "CMgvParameter";
      this.CMgvParameter.Size = new System.Drawing.Size(101, 26);
      // 
      // miDelete
      // 
      this.miDelete.Name = "miDelete";
      this.miDelete.Size = new System.Drawing.Size(100, 22);
      this.miDelete.Text = "删除";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnExtractParameter);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(804, 45);
      this.panel1.TabIndex = 8;
      // 
      // btnExtractParameter
      // 
      this.btnExtractParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnExtractParameter.Location = new System.Drawing.Point(0, 6);
      this.btnExtractParameter.Name = "btnExtractParameter";
      this.btnExtractParameter.Size = new System.Drawing.Size(138, 32);
      this.btnExtractParameter.TabIndex = 7;
      this.btnExtractParameter.Text = "重新加载参数";
      this.btnExtractParameter.UseVisualStyleBackColor = true;
      this.btnExtractParameter.Click += new System.EventHandler(this.btnExtractParameter_Click);
      // 
      // gvParameter
      // 
      this.gvParameter.AllowUserToAddRows = false;
      this.gvParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterID,
            this.ParameterName,
            this.ParameterDesc,
            this.ParameterDataType,
            this.ParameterDirection,
            this.ParameterValidateType,
            this.ConstValue,
            this.DefaultValue});
      this.gvParameter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvParameter.Location = new System.Drawing.Point(0, 45);
      this.gvParameter.MultiSelect = false;
      this.gvParameter.Name = "gvParameter";
      this.gvParameter.Size = new System.Drawing.Size(804, 358);
      this.gvParameter.TabIndex = 9;
      this.gvParameter.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvParameter_CellEndEdit);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
      this.contextMenuStrip1.Name = "CMgvParameter";
      this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItem1.Text = "删除";
      // 
      // ParameterID
      // 
      this.ParameterID.DataPropertyName = "ParameterID";
      this.ParameterID.HeaderText = "ID";
      this.ParameterID.Name = "ParameterID";
      this.ParameterID.ReadOnly = true;
      this.ParameterID.Visible = false;
      // 
      // ParameterName
      // 
      this.ParameterName.DataPropertyName = "ParameterName";
      this.ParameterName.HeaderText = "参数名称";
      this.ParameterName.Name = "ParameterName";
      this.ParameterName.ReadOnly = true;
      this.ParameterName.Width = 150;
      // 
      // ParameterDesc
      // 
      this.ParameterDesc.DataPropertyName = "ParameterDesc";
      this.ParameterDesc.HeaderText = "参数描述";
      this.ParameterDesc.Name = "ParameterDesc";
      this.ParameterDesc.Width = 200;
      // 
      // ParameterDataType
      // 
      this.ParameterDataType.DataPropertyName = "ParameterDataType";
      this.ParameterDataType.HeaderText = "数据类型";
      this.ParameterDataType.Name = "ParameterDataType";
      // 
      // ParameterDirection
      // 
      this.ParameterDirection.DataPropertyName = "ParameterDirection";
      this.ParameterDirection.HeaderText = "参数方向";
      this.ParameterDirection.Name = "ParameterDirection";
      this.ParameterDirection.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // ParameterValidateType
      // 
      this.ParameterValidateType.DataPropertyName = "ParameterValidateType";
      this.ParameterValidateType.HeaderText = "参数要求";
      this.ParameterValidateType.Name = "ParameterValidateType";
      this.ParameterValidateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // ConstValue
      // 
      this.ConstValue.DataPropertyName = "ConstValue";
      this.ConstValue.HeaderText = "固定值";
      this.ConstValue.Name = "ConstValue";
      this.ConstValue.Width = 80;
      // 
      // DefaultValue
      // 
      this.DefaultValue.DataPropertyName = "DefaultValue";
      this.DefaultValue.HeaderText = "默认值";
      this.DefaultValue.Name = "DefaultValue";
      this.DefaultValue.Width = 80;
      // 
      // BusinessMethodParameter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 403);
      this.Controls.Add(this.gvParameter);
      this.Controls.Add(this.panel1);
      this.Name = "BusinessMethodParameter";
      this.Text = "BusinessMethodParameter";
      this.Load += new System.EventHandler(this.BusinessMethodParameter_Load);
      this.CMgvParameter.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvParameter)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip CMgvParameter;
    private System.Windows.Forms.ToolStripMenuItem miDelete;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnExtractParameter;
    private System.Windows.Forms.DataGridView gvParameter;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.DataGridViewTextBoxColumn ParameterID;
    private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
    private System.Windows.Forms.DataGridViewTextBoxColumn ParameterDesc;
    private System.Windows.Forms.DataGridViewComboBoxColumn ParameterDataType;
    private System.Windows.Forms.DataGridViewComboBoxColumn ParameterDirection;
    private System.Windows.Forms.DataGridViewComboBoxColumn ParameterValidateType;
    private System.Windows.Forms.DataGridViewTextBoxColumn ConstValue;
    private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue;
  }
}