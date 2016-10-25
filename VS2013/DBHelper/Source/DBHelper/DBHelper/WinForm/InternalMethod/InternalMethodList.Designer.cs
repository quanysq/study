namespace DBHelper
{
  partial class InternalMethodList
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.ucMethodClassifyList = new DBHelper.MethodClassifyList();
      this.gvInternalMethod = new System.Windows.Forms.DataGridView();
      this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.MethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FunctionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnSplit = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnMove = new System.Windows.Forms.Button();
      this.btnQuery = new System.Windows.Forms.Button();
      this.txtKeyword = new System.Windows.Forms.TextBox();
      this.btnGenerateXml = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvInternalMethod)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.ucMethodClassifyList);
      this.splitContainer1.Panel1MinSize = 250;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.gvInternalMethod);
      this.splitContainer1.Panel2.Controls.Add(this.pnSplit);
      this.splitContainer1.Panel2.Controls.Add(this.panel1);
      this.splitContainer1.Size = new System.Drawing.Size(990, 518);
      this.splitContainer1.SplitterDistance = 250;
      this.splitContainer1.TabIndex = 0;
      // 
      // ucMethodClassifyList
      // 
      this.ucMethodClassifyList.AddMethodClassifyFrm_Title = "添加元素方法类别";
      this.ucMethodClassifyList.ClassifyType = 1;
      this.ucMethodClassifyList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMethodClassifyList.Location = new System.Drawing.Point(0, 0);
      this.ucMethodClassifyList.Name = "ucMethodClassifyList";
      this.ucMethodClassifyList.Size = new System.Drawing.Size(250, 518);
      this.ucMethodClassifyList.TabIndex = 0;
      // 
      // gvInternalMethod
      // 
      this.gvInternalMethod.AllowUserToAddRows = false;
      this.gvInternalMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvInternalMethod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.MethodID,
            this.MethodName,
            this.MethodDesc,
            this.MethodType,
            this.FunctionType,
            this.CreateUser,
            this.CreateDate});
      this.gvInternalMethod.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvInternalMethod.Location = new System.Drawing.Point(0, 39);
      this.gvInternalMethod.Name = "gvInternalMethod";
      this.gvInternalMethod.RowTemplate.Height = 23;
      this.gvInternalMethod.Size = new System.Drawing.Size(736, 479);
      this.gvInternalMethod.TabIndex = 1;
      this.gvInternalMethod.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInternalMethod_CellDoubleClick);
      // 
      // Selected
      // 
      this.Selected.FalseValue = "0";
      this.Selected.HeaderText = "";
      this.Selected.Name = "Selected";
      this.Selected.TrueValue = "1";
      this.Selected.Width = 40;
      // 
      // MethodID
      // 
      this.MethodID.DataPropertyName = "MethodID";
      this.MethodID.HeaderText = "ID";
      this.MethodID.Name = "MethodID";
      this.MethodID.ReadOnly = true;
      this.MethodID.Width = 70;
      // 
      // MethodName
      // 
      this.MethodName.DataPropertyName = "MethodName";
      this.MethodName.HeaderText = "元素方法名";
      this.MethodName.Name = "MethodName";
      this.MethodName.ReadOnly = true;
      // 
      // MethodDesc
      // 
      this.MethodDesc.DataPropertyName = "MethodDesc";
      this.MethodDesc.HeaderText = "元素方法描述";
      this.MethodDesc.Name = "MethodDesc";
      this.MethodDesc.ReadOnly = true;
      this.MethodDesc.Width = 300;
      // 
      // MethodType
      // 
      this.MethodType.DataPropertyName = "MethodType";
      this.MethodType.HeaderText = "方法类别";
      this.MethodType.Name = "MethodType";
      this.MethodType.ReadOnly = true;
      // 
      // FunctionType
      // 
      this.FunctionType.DataPropertyName = "FunctionType";
      this.FunctionType.HeaderText = "方法功能";
      this.FunctionType.Name = "FunctionType";
      this.FunctionType.ReadOnly = true;
      // 
      // CreateUser
      // 
      this.CreateUser.DataPropertyName = "CreateUser";
      this.CreateUser.HeaderText = "创建用户";
      this.CreateUser.Name = "CreateUser";
      this.CreateUser.ReadOnly = true;
      // 
      // CreateDate
      // 
      this.CreateDate.DataPropertyName = "CreateDate";
      this.CreateDate.HeaderText = "创建时间";
      this.CreateDate.Name = "CreateDate";
      this.CreateDate.ReadOnly = true;
      this.CreateDate.Width = 120;
      // 
      // pnSplit
      // 
      this.pnSplit.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnSplit.Location = new System.Drawing.Point(0, 38);
      this.pnSplit.Name = "pnSplit";
      this.pnSplit.Size = new System.Drawing.Size(736, 1);
      this.pnSplit.TabIndex = 2;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.btnMove);
      this.panel1.Controls.Add(this.btnQuery);
      this.panel1.Controls.Add(this.txtKeyword);
      this.panel1.Controls.Add(this.btnGenerateXml);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(736, 38);
      this.panel1.TabIndex = 0;
      // 
      // btnMove
      // 
      this.btnMove.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnMove.Location = new System.Drawing.Point(529, 6);
      this.btnMove.Name = "btnMove";
      this.btnMove.Size = new System.Drawing.Size(94, 25);
      this.btnMove.TabIndex = 4;
      this.btnMove.Text = "移至...";
      this.btnMove.UseVisualStyleBackColor = true;
      this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
      // 
      // btnQuery
      // 
      this.btnQuery.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnQuery.Location = new System.Drawing.Point(308, 6);
      this.btnQuery.Name = "btnQuery";
      this.btnQuery.Size = new System.Drawing.Size(74, 25);
      this.btnQuery.TabIndex = 3;
      this.btnQuery.Text = "查询";
      this.btnQuery.UseVisualStyleBackColor = true;
      this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
      // 
      // txtKeyword
      // 
      this.txtKeyword.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtKeyword.Location = new System.Drawing.Point(28, 8);
      this.txtKeyword.Name = "txtKeyword";
      this.txtKeyword.Size = new System.Drawing.Size(274, 23);
      this.txtKeyword.TabIndex = 2;
      this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
      // 
      // btnGenerateXml
      // 
      this.btnGenerateXml.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnGenerateXml.Location = new System.Drawing.Point(629, 6);
      this.btnGenerateXml.Name = "btnGenerateXml";
      this.btnGenerateXml.Size = new System.Drawing.Size(94, 25);
      this.btnGenerateXml.TabIndex = 1;
      this.btnGenerateXml.Text = "生成XML";
      this.btnGenerateXml.UseVisualStyleBackColor = true;
      this.btnGenerateXml.Click += new System.EventHandler(this.btnGenerateXml_Click);
      // 
      // InternalMethodList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(990, 518);
      this.Controls.Add(this.splitContainer1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InternalMethodList";
      this.Text = "元素方法列表";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InternalMethodList_FormClosed);
      this.Load += new System.EventHandler(this.InternalMethodList_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvInternalMethod)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private MethodClassifyList ucMethodClassifyList;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtKeyword;
    private System.Windows.Forms.Button btnGenerateXml;
    private System.Windows.Forms.Button btnQuery;
    private System.Windows.Forms.Button btnMove;
    private System.Windows.Forms.DataGridView gvInternalMethod;
    private System.Windows.Forms.Panel pnSplit;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodID;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodName;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodDesc;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodType;
    private System.Windows.Forms.DataGridViewTextBoxColumn FunctionType;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;



  }
}