namespace WindowsFormsApp8
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读写对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读写jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据联动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1233, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读写对象ToolStripMenuItem,
            this.读写jsonToolStripMenuItem,
            this.数据联动ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 读写对象ToolStripMenuItem
            // 
            this.读写对象ToolStripMenuItem.Name = "读写对象ToolStripMenuItem";
            this.读写对象ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.读写对象ToolStripMenuItem.Text = "读写对象";
            this.读写对象ToolStripMenuItem.Click += new System.EventHandler(this.读写对象ToolStripMenuItem_Click);
            // 
            // 读写jsonToolStripMenuItem
            // 
            this.读写jsonToolStripMenuItem.Name = "读写jsonToolStripMenuItem";
            this.读写jsonToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.读写jsonToolStripMenuItem.Text = "读写json";
            this.读写jsonToolStripMenuItem.Click += new System.EventHandler(this.读写jsonToolStripMenuItem_Click);
            // 
            // 数据联动ToolStripMenuItem
            // 
            this.数据联动ToolStripMenuItem.Name = "数据联动ToolStripMenuItem";
            this.数据联动ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.数据联动ToolStripMenuItem.Text = "数据联动";
            this.数据联动ToolStripMenuItem.Click += new System.EventHandler(this.数据联动ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 717);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读写对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读写jsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据联动ToolStripMenuItem;
    }
}

