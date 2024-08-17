namespace MRHelper
{
    partial class FrmTcReportHandler
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
            txtFile = new TextBox();
            btnSelectFile = new Button();
            groupBox2 = new GroupBox();
            txtPg = new TextBox();
            pgBar = new ProgressBar();
            groupBox1 = new GroupBox();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtFile
            // 
            txtFile.Location = new Point(6, 33);
            txtFile.Name = "txtFile";
            txtFile.Size = new Size(667, 23);
            txtFile.TabIndex = 4;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(679, 33);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(75, 23);
            btnSelectFile.TabIndex = 5;
            btnSelectFile.Text = "选择文件";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPg);
            groupBox2.Controls.Add(pgBar);
            groupBox2.Location = new Point(13, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(759, 343);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "处理进度";
            // 
            // txtPg
            // 
            txtPg.Location = new Point(6, 60);
            txtPg.Multiline = true;
            txtPg.Name = "txtPg";
            txtPg.ScrollBars = ScrollBars.Both;
            txtPg.Size = new Size(746, 277);
            txtPg.TabIndex = 1;
            // 
            // pgBar
            // 
            pgBar.Location = new Point(7, 27);
            pgBar.Name = "pgBar";
            pgBar.Size = new Size(746, 23);
            pgBar.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtFile);
            groupBox1.Controls.Add(btnSelectFile);
            groupBox1.Location = new Point(12, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 72);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "请选择 Excel 文件";
            // 
            // FrmTcReportHandler
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmTcReportHandler";
            Text = "总分公司渠道金额报表处理器";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtFile;
        private Button btnSelectFile;
        private GroupBox groupBox2;
        private TextBox txtPg;
        private ProgressBar pgBar;
        private GroupBox groupBox1;
    }
}