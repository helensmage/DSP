
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
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModellingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signals1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signail14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signals2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal21ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal22ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal23ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signal24ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделиСлучайныхСигналовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.суперпозицияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мультипликативнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnaliseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationAboutSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fragmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oscillogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.спектральныйАнализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.суперпозицияToolStripMenuItem,
            this.FilterToolStripMenuItem,
            this.AnaliseToolStripMenuItem,
            this.instrumetsToolStripMenuItem,
            this.oscillogramToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1117, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.OpenToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // ModellingToolStripMenuItem
            // 
            this.ModellingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signals1ToolStripMenuItem,
            this.signals2ToolStripMenuItem,
            this.моделиСлучайныхСигналовToolStripMenuItem});
            this.ModellingToolStripMenuItem.Name = "ModellingToolStripMenuItem";
            this.ModellingToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.ModellingToolStripMenuItem.Text = "Моделирование";
            // 
            // signals1ToolStripMenuItem
            // 
            this.signals1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signal11ToolStripMenuItem,
            this.signal12ToolStripMenuItem,
            this.signal13ToolStripMenuItem,
            this.signail14ToolStripMenuItem,
            this.signal15ToolStripMenuItem,
            this.signal16ToolStripMenuItem});
            this.signals1ToolStripMenuItem.Name = "signals1ToolStripMenuItem";
            this.signals1ToolStripMenuItem.Size = new System.Drawing.Size(420, 26);
            this.signals1ToolStripMenuItem.Text = "Модели сигналов с дискретным аргументом ";
            // 
            // signal11ToolStripMenuItem
            // 
            this.signal11ToolStripMenuItem.Name = "signal11ToolStripMenuItem";
            this.signal11ToolStripMenuItem.Size = new System.Drawing.Size(409, 26);
            this.signal11ToolStripMenuItem.Text = "задержанный единичный импульс";
            this.signal11ToolStripMenuItem.Click += new System.EventHandler(this.signal11ToolStripMenuItem_Click);
            // 
            // signal12ToolStripMenuItem
            // 
            this.signal12ToolStripMenuItem.Name = "signal12ToolStripMenuItem";
            this.signal12ToolStripMenuItem.Size = new System.Drawing.Size(409, 26);
            this.signal12ToolStripMenuItem.Text = "задержанный единичный скачок ";
            this.signal12ToolStripMenuItem.Click += new System.EventHandler(this.signal12ToolStripMenuItem_Click);
            // 
            // signal13ToolStripMenuItem
            // 
            this.signal13ToolStripMenuItem.Name = "signal13ToolStripMenuItem";
            this.signal13ToolStripMenuItem.Size = new System.Drawing.Size(409, 26);
            this.signal13ToolStripMenuItem.Text = "дискретизированная убывающая экспонента";
            this.signal13ToolStripMenuItem.Click += new System.EventHandler(this.signal13ToolStripMenuItem_Click);
            // 
            // signail14ToolStripMenuItem
            // 
            this.signail14ToolStripMenuItem.Name = "signail14ToolStripMenuItem";
            this.signail14ToolStripMenuItem.Size = new System.Drawing.Size(409, 26);
            this.signail14ToolStripMenuItem.Text = "дискретизированная синусоида";
            this.signail14ToolStripMenuItem.Click += new System.EventHandler(this.signail14ToolStripMenuItem_Click);
            // 
            // signal15ToolStripMenuItem
            // 
            this.signal15ToolStripMenuItem.Name = "signal15ToolStripMenuItem";
            this.signal15ToolStripMenuItem.Size = new System.Drawing.Size(409, 26);
            this.signal15ToolStripMenuItem.Text = "\"меандр\" (прямоугольная решетка)";
            this.signal15ToolStripMenuItem.Click += new System.EventHandler(this.signal15ToolStripMenuItem_Click);
            // 
            // signal16ToolStripMenuItem
            // 
            this.signal16ToolStripMenuItem.Name = "signal16ToolStripMenuItem";
            this.signal16ToolStripMenuItem.Size = new System.Drawing.Size(409, 26);
            this.signal16ToolStripMenuItem.Text = "\"пила\"";
            this.signal16ToolStripMenuItem.Click += new System.EventHandler(this.signal16ToolStripMenuItem_Click);
            // 
            // signals2ToolStripMenuItem
            // 
            this.signals2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signal21ToolStripMenuItem,
            this.signal22ToolStripMenuItem,
            this.signal23ToolStripMenuItem,
            this.signal24ToolStripMenuItem});
            this.signals2ToolStripMenuItem.Name = "signals2ToolStripMenuItem";
            this.signals2ToolStripMenuItem.Size = new System.Drawing.Size(420, 26);
            this.signals2ToolStripMenuItem.Text = "Модели сигналов с непрерывным аргументом";
            // 
            // signal21ToolStripMenuItem
            // 
            this.signal21ToolStripMenuItem.Name = "signal21ToolStripMenuItem";
            this.signal21ToolStripMenuItem.Size = new System.Drawing.Size(497, 26);
            this.signal21ToolStripMenuItem.Text = "сигнал с экспоненциальной огибающей";
            this.signal21ToolStripMenuItem.Click += new System.EventHandler(this.signal21ToolStripMenuItem_Click);
            // 
            // signal22ToolStripMenuItem
            // 
            this.signal22ToolStripMenuItem.Name = "signal22ToolStripMenuItem";
            this.signal22ToolStripMenuItem.Size = new System.Drawing.Size(497, 26);
            this.signal22ToolStripMenuItem.Text = "сигнал с балансной огибающей ";
            this.signal22ToolStripMenuItem.Click += new System.EventHandler(this.signal22ToolStripMenuItem_Click);
            // 
            // signal23ToolStripMenuItem
            // 
            this.signal23ToolStripMenuItem.Name = "signal23ToolStripMenuItem";
            this.signal23ToolStripMenuItem.Size = new System.Drawing.Size(497, 26);
            this.signal23ToolStripMenuItem.Text = "cигнал с тональной огибающей";
            this.signal23ToolStripMenuItem.Click += new System.EventHandler(this.signal23ToolStripMenuItem_Click);
            // 
            // signal24ToolStripMenuItem
            // 
            this.signal24ToolStripMenuItem.Name = "signal24ToolStripMenuItem";
            this.signal24ToolStripMenuItem.Size = new System.Drawing.Size(497, 26);
            this.signal24ToolStripMenuItem.Text = "сигнал с линейной частотной модуляцией (ЛЧМ - сигнал)";
            this.signal24ToolStripMenuItem.Click += new System.EventHandler(this.signal24ToolStripMenuItem_Click);
            // 
            // моделиСлучайныхСигналовToolStripMenuItem
            // 
            this.моделиСлучайныхСигналовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem,
            this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem,
            this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem});
            this.моделиСлучайныхСигналовToolStripMenuItem.Name = "моделиСлучайныхСигналовToolStripMenuItem";
            this.моделиСлучайныхСигналовToolStripMenuItem.Size = new System.Drawing.Size(420, 26);
            this.моделиСлучайныхСигналовToolStripMenuItem.Text = "Модели случайных сигналов";
            // 
            // сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem
            // 
            this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem.Name = "сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem";
            this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem.Size = new System.Drawing.Size(802, 26);
            this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem.Text = "Сигнал белого шума, равномерно распределенного в интервале";
            this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem.Click += new System.EventHandler(this.сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem_Click);
            // 
            // сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem
            // 
            this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem.Name = "сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToo" +
    "lStripMenuItem";
            this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem.Size = new System.Drawing.Size(802, 26);
            this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem.Text = "Сигнал белого шума, распределенного по нормальному закону с заданными средним и д" +
    "исперсией";
            this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem.Click += new System.EventHandler(this.сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem_Click);
            // 
            // сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem
            // 
            this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem.Name = "сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem";
            this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem.Size = new System.Drawing.Size(802, 26);
            this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem.Text = "Сигнал авторегрессии-скользящего среднего порядка - APCC";
            this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem.Click += new System.EventHandler(this.сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem_Click);
            // 
            // суперпозицияToolStripMenuItem
            // 
            this.суперпозицияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.линейнаяToolStripMenuItem,
            this.мультипликативнаяToolStripMenuItem});
            this.суперпозицияToolStripMenuItem.Name = "суперпозицияToolStripMenuItem";
            this.суперпозицияToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.суперпозицияToolStripMenuItem.Text = "Суперпозиция";
            // 
            // линейнаяToolStripMenuItem
            // 
            this.линейнаяToolStripMenuItem.Name = "линейнаяToolStripMenuItem";
            this.линейнаяToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.линейнаяToolStripMenuItem.Text = "Линейная";
            this.линейнаяToolStripMenuItem.Click += new System.EventHandler(this.линейнаяToolStripMenuItem_Click);
            // 
            // мультипликативнаяToolStripMenuItem
            // 
            this.мультипликативнаяToolStripMenuItem.Name = "мультипликативнаяToolStripMenuItem";
            this.мультипликативнаяToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.мультипликативнаяToolStripMenuItem.Text = "Мультипликативная";
            this.мультипликативнаяToolStripMenuItem.Click += new System.EventHandler(this.мультипликативнаяToolStripMenuItem_Click);
            // 
            // FilterToolStripMenuItem
            // 
            this.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem";
            this.FilterToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.FilterToolStripMenuItem.Text = "Фильтрация";
            // 
            // AnaliseToolStripMenuItem
            // 
            this.AnaliseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статистикиToolStripMenuItem,
            this.спектральныйАнализToolStripMenuItem});
            this.AnaliseToolStripMenuItem.Name = "AnaliseToolStripMenuItem";
            this.AnaliseToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.AnaliseToolStripMenuItem.Text = "Анализ";
            // 
            // статистикиToolStripMenuItem
            // 
            this.статистикиToolStripMenuItem.Name = "статистикиToolStripMenuItem";
            this.статистикиToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.статистикиToolStripMenuItem.Text = "Статистики";
            this.статистикиToolStripMenuItem.MouseHover += new System.EventHandler(this.статистикиToolStripMenuItem_MouseHover);
            // 
            // instrumetsToolStripMenuItem
            // 
            this.instrumetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationAboutSignalToolStripMenuItem,
            this.fragmentToolStripMenuItem});
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
            // fragmentToolStripMenuItem
            // 
            this.fragmentToolStripMenuItem.Name = "fragmentToolStripMenuItem";
            this.fragmentToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.fragmentToolStripMenuItem.Text = "Фрагмент";
            this.fragmentToolStripMenuItem.Click += new System.EventHandler(this.fragmentToolStripMenuItem_Click);
            // 
            // oscillogramToolStripMenuItem
            // 
            this.oscillogramToolStripMenuItem.Name = "oscillogramToolStripMenuItem";
            this.oscillogramToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.oscillogramToolStripMenuItem.Text = "Осциллограммы";
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
            // спектральныйАнализToolStripMenuItem
            // 
            this.спектральныйАнализToolStripMenuItem.Name = "спектральныйАнализToolStripMenuItem";
            this.спектральныйАнализToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.спектральныйАнализToolStripMenuItem.Text = "Спектральный Анализ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1117, 554);
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
        private System.Windows.Forms.ToolStripMenuItem oscillogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fragmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signals1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal13ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signail14ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signals2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal21ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal22ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal23ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signal24ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моделиСлучайныхСигналовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сигналБелогоШумаРавномерноРаспределенногоВИнтервалеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сигналБелогоШумаРаспределенногоПоНормальномуЗаконуСЗаданнымиСреднимИДисперсиейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сигналАвторегрессиискользящегоСреднегоПорядкаAPCCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem суперпозицияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линейнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мультипликативнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спектральныйАнализToolStripMenuItem;
    }
}

