namespace MRHelper
{
    partial class FrmZqReportHandler
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
            btnSelectFile = new Button();
            txtFile = new TextBox();
            groupBox1 = new GroupBox();
            chkLegaler = new CheckBox();
            chkBankAccountCode = new CheckBox();
            groupBox2 = new GroupBox();
            txtPg = new TextBox();
            pgBar = new ProgressBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(678, 58);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 23);
            btnSelectFile.TabIndex = 5;
            btnSelectFile.Text = "选择文件";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // txtFile
            // 
            txtFile.Location = new Point(7, 58);
            txtFile.Name = "txtFile";
            txtFile.Size = new Size(667, 23);
            txtFile.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkLegaler);
            groupBox1.Controls.Add(chkBankAccountCode);
            groupBox1.Controls.Add(txtFile);
            groupBox1.Controls.Add(btnSelectFile);
            groupBox1.Location = new Point(12, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 93);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "请选择 Excel 文件";
            // 
            // chkLegaler
            // 
            chkLegaler.AutoSize = true;
            chkLegaler.Checked = true;
            chkLegaler.CheckState = CheckState.Checked;
            chkLegaler.Location = new Point(124, 29);
            chkLegaler.Name = "chkLegaler";
            chkLegaler.Size = new Size(111, 21);
            chkLegaler.TabIndex = 7;
            chkLegaler.Text = "按法人代表统计";
            chkLegaler.UseVisualStyleBackColor = true;
            chkLegaler.CheckedChanged += chkLegaler_CheckedChanged;
            // 
            // chkBankAccountCode
            // 
            chkBankAccountCode.AutoSize = true;
            chkBankAccountCode.Checked = true;
            chkBankAccountCode.CheckState = CheckState.Checked;
            chkBankAccountCode.Location = new Point(7, 29);
            chkBankAccountCode.Name = "chkBankAccountCode";
            chkBankAccountCode.Size = new Size(111, 21);
            chkBankAccountCode.TabIndex = 6;
            chkBankAccountCode.Text = "按银行账号统计";
            chkBankAccountCode.UseVisualStyleBackColor = true;
            chkBankAccountCode.CheckedChanged += chkBankAccountCode_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPg);
            groupBox2.Controls.Add(pgBar);
            groupBox2.Location = new Point(13, 135);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(759, 314);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "处理进度";
            // 
            // txtPg
            // 
            txtPg.Location = new Point(7, 60);
            txtPg.Multiline = true;
            txtPg.Name = "txtPg";
            txtPg.ScrollBars = ScrollBars.Both;
            txtPg.Size = new Size(746, 245);
            txtPg.TabIndex = 1;
            // 
            // pgBar
            // 
            pgBar.Location = new Point(7, 27);
            pgBar.Name = "pgBar";
            pgBar.Size = new Size(746, 23);
            pgBar.TabIndex = 0;
            // 
            // FrmZqReportHandler
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "FrmZqReportHandler";
            Text = "渠道账期金额报表处理器";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectFile;
        private TextBox txtFile;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtPg;
        private ProgressBar pgBar;
        private CheckBox chkBankAccountCode;
        private CheckBox chkLegaler;
    }
}