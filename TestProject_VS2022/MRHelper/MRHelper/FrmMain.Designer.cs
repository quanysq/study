namespace MRHelper
{
    partial class FrmMain
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
            MenuFun = new MenuStrip();
            MenuZq = new ToolStripMenuItem();
            MenuTc = new ToolStripMenuItem();
            MenuFun.SuspendLayout();
            SuspendLayout();
            // 
            // MenuFun
            // 
            MenuFun.Items.AddRange(new ToolStripItem[] { MenuZq, MenuTc });
            MenuFun.Location = new Point(0, 0);
            MenuFun.Name = "MenuFun";
            MenuFun.Size = new Size(984, 25);
            MenuFun.TabIndex = 1;
            MenuFun.Text = "menuStrip1";
            // 
            // MenuZq
            // 
            MenuZq.Name = "MenuZq";
            MenuZq.Size = new Size(116, 21);
            MenuZq.Text = "账期渠道金额冻结";
            MenuZq.Click += MenuZq_Click;
            // 
            // MenuTc
            // 
            MenuTc.Name = "MenuTc";
            MenuTc.Size = new Size(140, 21);
            MenuTc.Text = "总分公司渠道金额冻结";
            MenuTc.Click += MenuTc_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(MenuFun);
            IsMdiContainer = true;
            MainMenuStrip = MenuFun;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "中移报表辅助工具";
            MenuFun.ResumeLayout(false);
            MenuFun.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuFun;
        private ToolStripMenuItem MenuZq;
        private ToolStripMenuItem MenuTc;
    }
}