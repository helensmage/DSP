
namespace DSP
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.осциллограммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спектральныйАнализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 753);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.осциллограммаToolStripMenuItem,
            this.статистикиToolStripMenuItem,
            this.спектральныйАнализToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 104);
            // 
            // осциллограммаToolStripMenuItem
            // 
            this.осциллограммаToolStripMenuItem.Name = "осциллограммаToolStripMenuItem";
            this.осциллограммаToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.осциллограммаToolStripMenuItem.Text = "Осциллограмма";
            this.осциллограммаToolStripMenuItem.Click += new System.EventHandler(this.осциллограммаToolStripMenuItem_Click);
            // 
            // статистикиToolStripMenuItem
            // 
            this.статистикиToolStripMenuItem.Name = "статистикиToolStripMenuItem";
            this.статистикиToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.статистикиToolStripMenuItem.Text = "Статистики";
            this.статистикиToolStripMenuItem.Click += new System.EventHandler(this.статистикиToolStripMenuItem_Click);
            // 
            // спектральныйАнализToolStripMenuItem
            // 
            this.спектральныйАнализToolStripMenuItem.Name = "спектральныйАнализToolStripMenuItem";
            this.спектральныйАнализToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.спектральныйАнализToolStripMenuItem.Text = "Спектральный анализ";
            this.спектральныйАнализToolStripMenuItem.Click += new System.EventHandler(this.спектральныйАнализToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(232, 753);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Каналы";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem осциллограммаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спектральныйАнализToolStripMenuItem;
    }
}