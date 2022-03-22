
namespace DSP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModellingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationAboutSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ModellingToolStripMenuItem,
            this.FilterToolStripMenuItem,
            this.AnaliseToolStripMenuItem,
            this.instrumetsToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1118, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.OpenToolStripMenuItem.Text = "Открыть";
            // 
            // ModellingToolStripMenuItem
            // 
            this.ModellingToolStripMenuItem.Name = "ModellingToolStripMenuItem";
            this.ModellingToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.ModellingToolStripMenuItem.Text = "Моделирование";
            // 
            // FilterToolStripMenuItem
            // 
            this.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem";
            this.FilterToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.FilterToolStripMenuItem.Text = "Фильтрация";
            // 
            // AnaliseToolStripMenuItem
            // 
            this.AnaliseToolStripMenuItem.Name = "AnaliseToolStripMenuItem";
            this.AnaliseToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.AnaliseToolStripMenuItem.Text = "Анализ";
            // 
            // instrumetsToolStripMenuItem
            // 
            this.instrumetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationAboutSignalToolStripMenuItem});
            this.instrumetsToolStripMenuItem.Name = "instrumetsToolStripMenuItem";
            this.instrumetsToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.instrumetsToolStripMenuItem.Text = "Инструменты";
            // 
            // informationAboutSignalToolStripMenuItem
            // 
            this.informationAboutSignalToolStripMenuItem.Name = "informationAboutSignalToolStripMenuItem";
            this.informationAboutSignalToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.informationAboutSignalToolStripMenuItem.Text = "Информация о сигнале";
            this.informationAboutSignalToolStripMenuItem.Click += new System.EventHandler(this.informationAboutSignalToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.HelpToolStripMenuItem.Text = "Справка";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1118, 554);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DSP - Shestopalova, Smagina, Prokhorova";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModellingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnaliseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem instrumetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationAboutSignalToolStripMenuItem;
    }
}

