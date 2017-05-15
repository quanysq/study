namespace WinFormSample01.WizardSample
{
  partial class WizardMainFrm
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.btnBack = new System.Windows.Forms.Button();
      this.pnlSubPage = new System.Windows.Forms.Panel();
      this.pnlMessage = new System.Windows.Forms.Panel();
      this.lblMessage = new System.Windows.Forms.Label();
      this.lblLine = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.pnlMessage.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.pnlSubPage, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.pnlMessage, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.lblLine, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 485);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
      this.tableLayoutPanel2.Controls.Add(this.btnCancel, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.btnNext, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.btnBack, 0, 0);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(346, 442);
      this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(7);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(289, 36);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(193, 3);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(93, 30);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnNext
      // 
      this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnNext.Location = new System.Drawing.Point(98, 3);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new System.Drawing.Size(89, 30);
      this.btnNext.TabIndex = 1;
      this.btnNext.Text = "Next";
      this.btnNext.UseVisualStyleBackColor = true;
      // 
      // btnBack
      // 
      this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBack.Location = new System.Drawing.Point(3, 3);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(89, 30);
      this.btnBack.TabIndex = 0;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      // 
      // pnlSubPage
      // 
      this.pnlSubPage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlSubPage.Location = new System.Drawing.Point(3, 3);
      this.pnlSubPage.Name = "pnlSubPage";
      this.pnlSubPage.Size = new System.Drawing.Size(636, 390);
      this.pnlSubPage.TabIndex = 1;
      // 
      // pnlMessage
      // 
      this.pnlMessage.Controls.Add(this.lblMessage);
      this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMessage.Location = new System.Drawing.Point(3, 399);
      this.pnlMessage.Name = "pnlMessage";
      this.pnlMessage.Size = new System.Drawing.Size(636, 25);
      this.pnlMessage.TabIndex = 2;
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Location = new System.Drawing.Point(212, 6);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(35, 13);
      this.lblMessage.TabIndex = 0;
      this.lblMessage.Text = "label1";
      this.lblMessage.Visible = false;
      // 
      // lblLine
      // 
      this.lblLine.AutoSize = true;
      this.lblLine.Location = new System.Drawing.Point(3, 427);
      this.lblLine.Name = "lblLine";
      this.lblLine.Size = new System.Drawing.Size(35, 8);
      this.lblLine.TabIndex = 3;
      this.lblLine.Text = "label1";
      // 
      // WizardMainFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(642, 485);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "WizardMainFrm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "WizardMainFrm";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.pnlMessage.ResumeLayout(false);
      this.pnlMessage.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.Panel pnlSubPage;
    private System.Windows.Forms.Panel pnlMessage;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Label lblLine;
  }
}