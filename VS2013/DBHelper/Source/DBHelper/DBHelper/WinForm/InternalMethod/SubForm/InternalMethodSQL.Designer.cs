namespace DBHelper
{
  partial class InternalMethodSQL
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
      this.gvSQL = new System.Windows.Forms.DataGridView();
      this.StatementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlSplit = new System.Windows.Forms.Panel();
      this.Statement = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.HasConditional = new System.Windows.Forms.CheckBox();
      this.IsOrderby = new System.Windows.Forms.CheckBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblSaveMsg = new System.Windows.Forms.Label();
      this.btnMgrParameter = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.pnlCondition = new System.Windows.Forms.Panel();
      this.ConditionType5 = new System.Windows.Forms.ComboBox();
      this.ConditionType4 = new System.Windows.Forms.ComboBox();
      this.ConditionType3 = new System.Windows.Forms.ComboBox();
      this.ConditionType2 = new System.Windows.Forms.ComboBox();
      this.ConditionType1 = new System.Windows.Forms.ComboBox();
      this.CompareValue5 = new System.Windows.Forms.TextBox();
      this.ExpectBehavior5 = new System.Windows.Forms.ComboBox();
      this.ParameterName5 = new System.Windows.Forms.ComboBox();
      this.CompareValue4 = new System.Windows.Forms.TextBox();
      this.ExpectBehavior4 = new System.Windows.Forms.ComboBox();
      this.ParameterName4 = new System.Windows.Forms.ComboBox();
      this.CompareValue3 = new System.Windows.Forms.TextBox();
      this.ExpectBehavior3 = new System.Windows.Forms.ComboBox();
      this.ParameterName3 = new System.Windows.Forms.ComboBox();
      this.CompareValue2 = new System.Windows.Forms.TextBox();
      this.ExpectBehavior2 = new System.Windows.Forms.ComboBox();
      this.ParameterName2 = new System.Windows.Forms.ComboBox();
      this.ConditionalID5 = new System.Windows.Forms.TextBox();
      this.ConditionalID4 = new System.Windows.Forms.TextBox();
      this.ConditionalID3 = new System.Windows.Forms.TextBox();
      this.ConditionalID2 = new System.Windows.Forms.TextBox();
      this.ConditionalID1 = new System.Windows.Forms.TextBox();
      this.CompareValue1 = new System.Windows.Forms.TextBox();
      this.ExpectBehavior1 = new System.Windows.Forms.ComboBox();
      this.ParameterName1 = new System.Windows.Forms.ComboBox();
      this.btnExtractParameter = new System.Windows.Forms.Button();
      this.CMForgvSQL = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miMoveUp = new System.Windows.Forms.ToolStripMenuItem();
      this.miMoveDown = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.TipCustome = new System.Windows.Forms.ToolTip(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.gvSQL)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.pnlCondition.SuspendLayout();
      this.CMForgvSQL.SuspendLayout();
      this.SuspendLayout();
      // 
      // gvSQL
      // 
      this.gvSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvSQL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatementID,
            this.Tag});
      this.gvSQL.Dock = System.Windows.Forms.DockStyle.Left;
      this.gvSQL.Location = new System.Drawing.Point(0, 0);
      this.gvSQL.Name = "gvSQL";
      this.gvSQL.Size = new System.Drawing.Size(252, 403);
      this.gvSQL.TabIndex = 0;
      this.gvSQL.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSQL_CellEndEdit);
      this.gvSQL.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvSQL_CellMouseDown);
      this.gvSQL.CurrentCellChanged += new System.EventHandler(this.gvSQL_CurrentCellChanged);
      // 
      // StatementID
      // 
      this.StatementID.DataPropertyName = "StatementID";
      this.StatementID.HeaderText = "ID";
      this.StatementID.Name = "StatementID";
      this.StatementID.ReadOnly = true;
      this.StatementID.Visible = false;
      // 
      // Tag
      // 
      this.Tag.DataPropertyName = "Tag";
      this.Tag.HeaderText = "SQL标签";
      this.Tag.Name = "Tag";
      this.Tag.Width = 200;
      // 
      // pnlSplit
      // 
      this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlSplit.Location = new System.Drawing.Point(252, 0);
      this.pnlSplit.Name = "pnlSplit";
      this.pnlSplit.Size = new System.Drawing.Size(4, 403);
      this.pnlSplit.TabIndex = 1;
      // 
      // Statement
      // 
      this.Statement.Dock = System.Windows.Forms.DockStyle.Top;
      this.Statement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.Statement.Location = new System.Drawing.Point(256, 0);
      this.Statement.Multiline = true;
      this.Statement.Name = "Statement";
      this.Statement.ReadOnly = true;
      this.Statement.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.Statement.Size = new System.Drawing.Size(548, 139);
      this.Statement.TabIndex = 2;
      this.Statement.WordWrap = false;
      this.Statement.DoubleClick += new System.EventHandler(this.Statement_DoubleClick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.HasConditional);
      this.panel1.Controls.Add(this.IsOrderby);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(256, 139);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(548, 33);
      this.panel1.TabIndex = 3;
      // 
      // HasConditional
      // 
      this.HasConditional.AutoSize = true;
      this.HasConditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.HasConditional.Location = new System.Drawing.Point(68, 6);
      this.HasConditional.Name = "HasConditional";
      this.HasConditional.Size = new System.Drawing.Size(139, 21);
      this.HasConditional.TabIndex = 0;
      this.HasConditional.Text = "需要满足以下条件";
      this.HasConditional.UseVisualStyleBackColor = true;
      this.HasConditional.CheckedChanged += new System.EventHandler(this.HasConditional_CheckedChanged);
      this.HasConditional.Click += new System.EventHandler(this.HasConditional_Click);
      // 
      // IsOrderby
      // 
      this.IsOrderby.AutoSize = true;
      this.IsOrderby.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.IsOrderby.Location = new System.Drawing.Point(0, 6);
      this.IsOrderby.Name = "IsOrderby";
      this.IsOrderby.Size = new System.Drawing.Size(55, 21);
      this.IsOrderby.TabIndex = 0;
      this.IsOrderby.Text = "排序";
      this.IsOrderby.UseVisualStyleBackColor = true;
      this.IsOrderby.Click += new System.EventHandler(this.IsOrderby_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lblSaveMsg);
      this.panel2.Controls.Add(this.btnMgrParameter);
      this.panel2.Controls.Add(this.btnOK);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(256, 358);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(548, 45);
      this.panel2.TabIndex = 5;
      // 
      // lblSaveMsg
      // 
      this.lblSaveMsg.AutoSize = true;
      this.lblSaveMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.lblSaveMsg.Location = new System.Drawing.Point(88, 14);
      this.lblSaveMsg.Name = "lblSaveMsg";
      this.lblSaveMsg.Size = new System.Drawing.Size(0, 17);
      this.lblSaveMsg.TabIndex = 9;
      // 
      // btnMgrParameter
      // 
      this.btnMgrParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnMgrParameter.Location = new System.Drawing.Point(450, 6);
      this.btnMgrParameter.Name = "btnMgrParameter";
      this.btnMgrParameter.Size = new System.Drawing.Size(94, 32);
      this.btnMgrParameter.TabIndex = 8;
      this.btnMgrParameter.Text = "管理参数";
      this.btnMgrParameter.UseVisualStyleBackColor = true;
      this.btnMgrParameter.Click += new System.EventHandler(this.btnMgrParameter_Click);
      // 
      // btnOK
      // 
      this.btnOK.Enabled = false;
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnOK.Location = new System.Drawing.Point(0, 6);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 32);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "保存";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // pnlCondition
      // 
      this.pnlCondition.Controls.Add(this.ConditionType5);
      this.pnlCondition.Controls.Add(this.ConditionType4);
      this.pnlCondition.Controls.Add(this.ConditionType3);
      this.pnlCondition.Controls.Add(this.ConditionType2);
      this.pnlCondition.Controls.Add(this.ConditionType1);
      this.pnlCondition.Controls.Add(this.CompareValue5);
      this.pnlCondition.Controls.Add(this.ExpectBehavior5);
      this.pnlCondition.Controls.Add(this.ParameterName5);
      this.pnlCondition.Controls.Add(this.CompareValue4);
      this.pnlCondition.Controls.Add(this.ExpectBehavior4);
      this.pnlCondition.Controls.Add(this.ParameterName4);
      this.pnlCondition.Controls.Add(this.CompareValue3);
      this.pnlCondition.Controls.Add(this.ExpectBehavior3);
      this.pnlCondition.Controls.Add(this.ParameterName3);
      this.pnlCondition.Controls.Add(this.CompareValue2);
      this.pnlCondition.Controls.Add(this.ExpectBehavior2);
      this.pnlCondition.Controls.Add(this.ParameterName2);
      this.pnlCondition.Controls.Add(this.ConditionalID5);
      this.pnlCondition.Controls.Add(this.ConditionalID4);
      this.pnlCondition.Controls.Add(this.ConditionalID3);
      this.pnlCondition.Controls.Add(this.ConditionalID2);
      this.pnlCondition.Controls.Add(this.ConditionalID1);
      this.pnlCondition.Controls.Add(this.CompareValue1);
      this.pnlCondition.Controls.Add(this.ExpectBehavior1);
      this.pnlCondition.Controls.Add(this.ParameterName1);
      this.pnlCondition.Controls.Add(this.btnExtractParameter);
      this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlCondition.Enabled = false;
      this.pnlCondition.Location = new System.Drawing.Point(256, 172);
      this.pnlCondition.Name = "pnlCondition";
      this.pnlCondition.Size = new System.Drawing.Size(548, 186);
      this.pnlCondition.TabIndex = 13;
      // 
      // ConditionType5
      // 
      this.ConditionType5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionType5.FormattingEnabled = true;
      this.ConditionType5.Location = new System.Drawing.Point(0, 157);
      this.ConditionType5.Name = "ConditionType5";
      this.ConditionType5.Size = new System.Drawing.Size(106, 25);
      this.ConditionType5.TabIndex = 25;
      // 
      // ConditionType4
      // 
      this.ConditionType4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionType4.FormattingEnabled = true;
      this.ConditionType4.Location = new System.Drawing.Point(0, 127);
      this.ConditionType4.Name = "ConditionType4";
      this.ConditionType4.Size = new System.Drawing.Size(106, 25);
      this.ConditionType4.TabIndex = 25;
      // 
      // ConditionType3
      // 
      this.ConditionType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionType3.FormattingEnabled = true;
      this.ConditionType3.Location = new System.Drawing.Point(0, 98);
      this.ConditionType3.Name = "ConditionType3";
      this.ConditionType3.Size = new System.Drawing.Size(106, 25);
      this.ConditionType3.TabIndex = 25;
      // 
      // ConditionType2
      // 
      this.ConditionType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionType2.FormattingEnabled = true;
      this.ConditionType2.Location = new System.Drawing.Point(0, 68);
      this.ConditionType2.Name = "ConditionType2";
      this.ConditionType2.Size = new System.Drawing.Size(106, 25);
      this.ConditionType2.TabIndex = 25;
      // 
      // ConditionType1
      // 
      this.ConditionType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionType1.FormattingEnabled = true;
      this.ConditionType1.Location = new System.Drawing.Point(0, 39);
      this.ConditionType1.Name = "ConditionType1";
      this.ConditionType1.Size = new System.Drawing.Size(106, 25);
      this.ConditionType1.TabIndex = 25;
      // 
      // CompareValue5
      // 
      this.CompareValue5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.CompareValue5.Location = new System.Drawing.Point(404, 157);
      this.CompareValue5.Name = "CompareValue5";
      this.CompareValue5.Size = new System.Drawing.Size(140, 23);
      this.CompareValue5.TabIndex = 24;
      // 
      // ExpectBehavior5
      // 
      this.ExpectBehavior5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ExpectBehavior5.FormattingEnabled = true;
      this.ExpectBehavior5.Location = new System.Drawing.Point(278, 157);
      this.ExpectBehavior5.Name = "ExpectBehavior5";
      this.ExpectBehavior5.Size = new System.Drawing.Size(120, 25);
      this.ExpectBehavior5.TabIndex = 23;
      // 
      // ParameterName5
      // 
      this.ParameterName5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ParameterName5.FormattingEnabled = true;
      this.ParameterName5.Location = new System.Drawing.Point(112, 157);
      this.ParameterName5.Name = "ParameterName5";
      this.ParameterName5.Size = new System.Drawing.Size(160, 25);
      this.ParameterName5.TabIndex = 22;
      // 
      // CompareValue4
      // 
      this.CompareValue4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.CompareValue4.Location = new System.Drawing.Point(404, 127);
      this.CompareValue4.Name = "CompareValue4";
      this.CompareValue4.Size = new System.Drawing.Size(140, 23);
      this.CompareValue4.TabIndex = 21;
      // 
      // ExpectBehavior4
      // 
      this.ExpectBehavior4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ExpectBehavior4.FormattingEnabled = true;
      this.ExpectBehavior4.Location = new System.Drawing.Point(278, 127);
      this.ExpectBehavior4.Name = "ExpectBehavior4";
      this.ExpectBehavior4.Size = new System.Drawing.Size(120, 25);
      this.ExpectBehavior4.TabIndex = 20;
      // 
      // ParameterName4
      // 
      this.ParameterName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ParameterName4.FormattingEnabled = true;
      this.ParameterName4.Location = new System.Drawing.Point(112, 127);
      this.ParameterName4.Name = "ParameterName4";
      this.ParameterName4.Size = new System.Drawing.Size(160, 25);
      this.ParameterName4.TabIndex = 19;
      // 
      // CompareValue3
      // 
      this.CompareValue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.CompareValue3.Location = new System.Drawing.Point(404, 98);
      this.CompareValue3.Name = "CompareValue3";
      this.CompareValue3.Size = new System.Drawing.Size(140, 23);
      this.CompareValue3.TabIndex = 18;
      // 
      // ExpectBehavior3
      // 
      this.ExpectBehavior3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ExpectBehavior3.FormattingEnabled = true;
      this.ExpectBehavior3.Location = new System.Drawing.Point(278, 98);
      this.ExpectBehavior3.Name = "ExpectBehavior3";
      this.ExpectBehavior3.Size = new System.Drawing.Size(120, 25);
      this.ExpectBehavior3.TabIndex = 17;
      // 
      // ParameterName3
      // 
      this.ParameterName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ParameterName3.FormattingEnabled = true;
      this.ParameterName3.Location = new System.Drawing.Point(112, 98);
      this.ParameterName3.Name = "ParameterName3";
      this.ParameterName3.Size = new System.Drawing.Size(160, 25);
      this.ParameterName3.TabIndex = 16;
      // 
      // CompareValue2
      // 
      this.CompareValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.CompareValue2.Location = new System.Drawing.Point(404, 68);
      this.CompareValue2.Name = "CompareValue2";
      this.CompareValue2.Size = new System.Drawing.Size(140, 23);
      this.CompareValue2.TabIndex = 15;
      // 
      // ExpectBehavior2
      // 
      this.ExpectBehavior2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ExpectBehavior2.FormattingEnabled = true;
      this.ExpectBehavior2.Location = new System.Drawing.Point(278, 68);
      this.ExpectBehavior2.Name = "ExpectBehavior2";
      this.ExpectBehavior2.Size = new System.Drawing.Size(120, 25);
      this.ExpectBehavior2.TabIndex = 14;
      // 
      // ParameterName2
      // 
      this.ParameterName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ParameterName2.FormattingEnabled = true;
      this.ParameterName2.Location = new System.Drawing.Point(112, 68);
      this.ParameterName2.Name = "ParameterName2";
      this.ParameterName2.Size = new System.Drawing.Size(160, 25);
      this.ParameterName2.TabIndex = 13;
      // 
      // ConditionalID5
      // 
      this.ConditionalID5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionalID5.Location = new System.Drawing.Point(242, 9);
      this.ConditionalID5.Name = "ConditionalID5";
      this.ConditionalID5.Size = new System.Drawing.Size(30, 23);
      this.ConditionalID5.TabIndex = 12;
      this.ConditionalID5.Text = "0";
      this.ConditionalID5.Visible = false;
      // 
      // ConditionalID4
      // 
      this.ConditionalID4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionalID4.Location = new System.Drawing.Point(208, 9);
      this.ConditionalID4.Name = "ConditionalID4";
      this.ConditionalID4.Size = new System.Drawing.Size(30, 23);
      this.ConditionalID4.TabIndex = 12;
      this.ConditionalID4.Text = "0";
      this.ConditionalID4.Visible = false;
      // 
      // ConditionalID3
      // 
      this.ConditionalID3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionalID3.Location = new System.Drawing.Point(172, 9);
      this.ConditionalID3.Name = "ConditionalID3";
      this.ConditionalID3.Size = new System.Drawing.Size(30, 23);
      this.ConditionalID3.TabIndex = 12;
      this.ConditionalID3.Text = "0";
      this.ConditionalID3.Visible = false;
      // 
      // ConditionalID2
      // 
      this.ConditionalID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionalID2.Location = new System.Drawing.Point(136, 9);
      this.ConditionalID2.Name = "ConditionalID2";
      this.ConditionalID2.Size = new System.Drawing.Size(30, 23);
      this.ConditionalID2.TabIndex = 12;
      this.ConditionalID2.Text = "0";
      this.ConditionalID2.Visible = false;
      // 
      // ConditionalID1
      // 
      this.ConditionalID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConditionalID1.Location = new System.Drawing.Point(100, 9);
      this.ConditionalID1.Name = "ConditionalID1";
      this.ConditionalID1.Size = new System.Drawing.Size(30, 23);
      this.ConditionalID1.TabIndex = 12;
      this.ConditionalID1.Text = "0";
      this.ConditionalID1.Visible = false;
      // 
      // CompareValue1
      // 
      this.CompareValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.CompareValue1.Location = new System.Drawing.Point(404, 39);
      this.CompareValue1.Name = "CompareValue1";
      this.CompareValue1.Size = new System.Drawing.Size(140, 23);
      this.CompareValue1.TabIndex = 12;
      // 
      // ExpectBehavior1
      // 
      this.ExpectBehavior1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ExpectBehavior1.FormattingEnabled = true;
      this.ExpectBehavior1.Location = new System.Drawing.Point(278, 39);
      this.ExpectBehavior1.Name = "ExpectBehavior1";
      this.ExpectBehavior1.Size = new System.Drawing.Size(120, 25);
      this.ExpectBehavior1.TabIndex = 11;
      // 
      // ParameterName1
      // 
      this.ParameterName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ParameterName1.FormattingEnabled = true;
      this.ParameterName1.Location = new System.Drawing.Point(112, 39);
      this.ParameterName1.Name = "ParameterName1";
      this.ParameterName1.Size = new System.Drawing.Size(160, 25);
      this.ParameterName1.TabIndex = 10;
      // 
      // btnExtractParameter
      // 
      this.btnExtractParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnExtractParameter.Location = new System.Drawing.Point(0, 4);
      this.btnExtractParameter.Name = "btnExtractParameter";
      this.btnExtractParameter.Size = new System.Drawing.Size(94, 32);
      this.btnExtractParameter.TabIndex = 9;
      this.btnExtractParameter.Text = "提取参数";
      this.btnExtractParameter.UseVisualStyleBackColor = true;
      this.btnExtractParameter.Click += new System.EventHandler(this.btnExtractParameter_Click);
      // 
      // CMForgvSQL
      // 
      this.CMForgvSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMoveUp,
            this.miMoveDown,
            this.toolStripSeparator1,
            this.miDelete});
      this.CMForgvSQL.Name = "CMForgvSQL";
      this.CMForgvSQL.Size = new System.Drawing.Size(101, 76);
      // 
      // miMoveUp
      // 
      this.miMoveUp.Name = "miMoveUp";
      this.miMoveUp.Size = new System.Drawing.Size(100, 22);
      this.miMoveUp.Text = "上移";
      this.miMoveUp.Click += new System.EventHandler(this.miMoveUp_Click);
      // 
      // miMoveDown
      // 
      this.miMoveDown.Name = "miMoveDown";
      this.miMoveDown.Size = new System.Drawing.Size(100, 22);
      this.miMoveDown.Text = "下移";
      this.miMoveDown.Click += new System.EventHandler(this.miMoveDown_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
      // 
      // miDelete
      // 
      this.miDelete.Name = "miDelete";
      this.miDelete.Size = new System.Drawing.Size(100, 22);
      this.miDelete.Text = "删除";
      this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
      // 
      // InternalMethodSQL
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 403);
      this.Controls.Add(this.pnlCondition);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.Statement);
      this.Controls.Add(this.pnlSplit);
      this.Controls.Add(this.gvSQL);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InternalMethodSQL";
      this.Text = "编辑SQL语句";
      this.Load += new System.EventHandler(this.InternalMethodSQL_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gvSQL)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.pnlCondition.ResumeLayout(false);
      this.pnlCondition.PerformLayout();
      this.CMForgvSQL.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView gvSQL;
    private System.Windows.Forms.Panel pnlSplit;
    private System.Windows.Forms.TextBox Statement;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox HasConditional;
    private System.Windows.Forms.CheckBox IsOrderby;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnMgrParameter;
    private System.Windows.Forms.Panel pnlCondition;
    private System.Windows.Forms.TextBox CompareValue5;
    private System.Windows.Forms.ComboBox ExpectBehavior5;
    private System.Windows.Forms.ComboBox ParameterName5;
    private System.Windows.Forms.TextBox CompareValue4;
    private System.Windows.Forms.ComboBox ExpectBehavior4;
    private System.Windows.Forms.ComboBox ParameterName4;
    private System.Windows.Forms.TextBox CompareValue3;
    private System.Windows.Forms.ComboBox ExpectBehavior3;
    private System.Windows.Forms.ComboBox ParameterName3;
    private System.Windows.Forms.TextBox CompareValue2;
    private System.Windows.Forms.ComboBox ExpectBehavior2;
    private System.Windows.Forms.ComboBox ParameterName2;
    private System.Windows.Forms.TextBox CompareValue1;
    private System.Windows.Forms.ComboBox ExpectBehavior1;
    private System.Windows.Forms.ComboBox ParameterName1;
    private System.Windows.Forms.Button btnExtractParameter;
    private System.Windows.Forms.ComboBox ConditionType1;
    private System.Windows.Forms.ComboBox ConditionType3;
    private System.Windows.Forms.ComboBox ConditionType2;
    private System.Windows.Forms.ComboBox ConditionType5;
    private System.Windows.Forms.ComboBox ConditionType4;
    private System.Windows.Forms.TextBox ConditionalID5;
    private System.Windows.Forms.TextBox ConditionalID4;
    private System.Windows.Forms.TextBox ConditionalID3;
    private System.Windows.Forms.TextBox ConditionalID2;
    private System.Windows.Forms.TextBox ConditionalID1;
    private System.Windows.Forms.Label lblSaveMsg;
    private System.Windows.Forms.DataGridViewTextBoxColumn StatementID;
    private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
    private System.Windows.Forms.ContextMenuStrip CMForgvSQL;
    private System.Windows.Forms.ToolStripMenuItem miMoveUp;
    private System.Windows.Forms.ToolStripMenuItem miMoveDown;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem miDelete;
    private System.Windows.Forms.ToolTip TipCustome;
  }
}