
namespace Tyuiu.DolgushinVA.Sprint7.Project.V12
{
    partial class FormCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCharts));
            this.panelLeftC_DVA = new System.Windows.Forms.Panel();
            this.panelRightC_DVA = new System.Windows.Forms.Panel();
            this.panelDownC_DVA = new System.Windows.Forms.Panel();
            this.openFileDialog_DVA = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_DVA = new System.Windows.Forms.SaveFileDialog();
            this.toolTipOpenFile_DVA = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSaveFile_DVA = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipAddChart_DVA = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDeleteChart_DVA = new System.Windows.Forms.ToolTip(this.components);
            this.panelCharts_DVA = new System.Windows.Forms.Panel();
            this.groupBoxActions_DVA = new System.Windows.Forms.GroupBox();
            this.buttonDeleteChart_DVA = new System.Windows.Forms.Button();
            this.buttonAddChart_DVA = new System.Windows.Forms.Button();
            this.buttonSaveFile_DVA = new System.Windows.Forms.Button();
            this.buttonOpenFile_DVA = new System.Windows.Forms.Button();
            this.chartFunction_DVA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewOpenDataBase_DVA = new System.Windows.Forms.DataGridView();
            this.menuStrip_DVA = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.главнаяСтраницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCharts_DVA.SuspendLayout();
            this.groupBoxActions_DVA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction_DVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpenDataBase_DVA)).BeginInit();
            this.menuStrip_DVA.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftC_DVA
            // 
            this.panelLeftC_DVA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelLeftC_DVA.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftC_DVA.Location = new System.Drawing.Point(0, 0);
            this.panelLeftC_DVA.Name = "panelLeftC_DVA";
            this.panelLeftC_DVA.Size = new System.Drawing.Size(25, 657);
            this.panelLeftC_DVA.TabIndex = 0;
            // 
            // panelRightC_DVA
            // 
            this.panelRightC_DVA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelRightC_DVA.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightC_DVA.Location = new System.Drawing.Point(1332, 0);
            this.panelRightC_DVA.Name = "panelRightC_DVA";
            this.panelRightC_DVA.Size = new System.Drawing.Size(25, 657);
            this.panelRightC_DVA.TabIndex = 2;
            // 
            // panelDownC_DVA
            // 
            this.panelDownC_DVA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelDownC_DVA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDownC_DVA.Location = new System.Drawing.Point(25, 632);
            this.panelDownC_DVA.Name = "panelDownC_DVA";
            this.panelDownC_DVA.Size = new System.Drawing.Size(1307, 25);
            this.panelDownC_DVA.TabIndex = 3;
            // 
            // openFileDialog_DVA
            // 
            this.openFileDialog_DVA.FileName = "openFileDialog1";
            // 
            // toolTipOpenFile_DVA
            // 
            this.toolTipOpenFile_DVA.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipOpenFile_DVA.ToolTipTitle = "Открыть файл";
            // 
            // toolTipSaveFile_DVA
            // 
            this.toolTipSaveFile_DVA.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipSaveFile_DVA.ToolTipTitle = "Сохранить файл";
            // 
            // toolTipAddChart_DVA
            // 
            this.toolTipAddChart_DVA.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipAddChart_DVA.ToolTipTitle = "Построить график";
            // 
            // toolTipDeleteChart_DVA
            // 
            this.toolTipDeleteChart_DVA.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipDeleteChart_DVA.ToolTipTitle = "Очистить плоскость";
            // 
            // panelCharts_DVA
            // 
            this.panelCharts_DVA.BackColor = System.Drawing.SystemColors.Control;
            this.panelCharts_DVA.BackgroundImage = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.background;
            this.panelCharts_DVA.Controls.Add(this.groupBoxActions_DVA);
            this.panelCharts_DVA.Controls.Add(this.chartFunction_DVA);
            this.panelCharts_DVA.Controls.Add(this.dataGridViewOpenDataBase_DVA);
            this.panelCharts_DVA.Controls.Add(this.menuStrip_DVA);
            this.panelCharts_DVA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharts_DVA.Location = new System.Drawing.Point(25, 0);
            this.panelCharts_DVA.Name = "panelCharts_DVA";
            this.panelCharts_DVA.Size = new System.Drawing.Size(1307, 632);
            this.panelCharts_DVA.TabIndex = 4;
            // 
            // groupBoxActions_DVA
            // 
            this.groupBoxActions_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions_DVA.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBoxActions_DVA.Controls.Add(this.buttonDeleteChart_DVA);
            this.groupBoxActions_DVA.Controls.Add(this.buttonAddChart_DVA);
            this.groupBoxActions_DVA.Controls.Add(this.buttonSaveFile_DVA);
            this.groupBoxActions_DVA.Controls.Add(this.buttonOpenFile_DVA);
            this.groupBoxActions_DVA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBoxActions_DVA.Location = new System.Drawing.Point(6, 492);
            this.groupBoxActions_DVA.Name = "groupBoxActions_DVA";
            this.groupBoxActions_DVA.Size = new System.Drawing.Size(1295, 134);
            this.groupBoxActions_DVA.TabIndex = 2;
            this.groupBoxActions_DVA.TabStop = false;
            this.groupBoxActions_DVA.Text = "Работа с графиком";
            // 
            // buttonDeleteChart_DVA
            // 
            this.buttonDeleteChart_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteChart_DVA.Image = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.chart_curve_delete;
            this.buttonDeleteChart_DVA.Location = new System.Drawing.Point(1097, 39);
            this.buttonDeleteChart_DVA.Name = "buttonDeleteChart_DVA";
            this.buttonDeleteChart_DVA.Size = new System.Drawing.Size(175, 85);
            this.buttonDeleteChart_DVA.TabIndex = 3;
            this.toolTipDeleteChart_DVA.SetToolTip(this.buttonDeleteChart_DVA, "Удалить график");
            this.buttonDeleteChart_DVA.UseVisualStyleBackColor = true;
            this.buttonDeleteChart_DVA.Click += new System.EventHandler(this.buttonDeleteChart_DVA_Click);
            // 
            // buttonAddChart_DVA
            // 
            this.buttonAddChart_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddChart_DVA.Image = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.chart_curve_add;
            this.buttonAddChart_DVA.Location = new System.Drawing.Point(879, 39);
            this.buttonAddChart_DVA.Name = "buttonAddChart_DVA";
            this.buttonAddChart_DVA.Size = new System.Drawing.Size(175, 85);
            this.buttonAddChart_DVA.TabIndex = 2;
            this.toolTipAddChart_DVA.SetToolTip(this.buttonAddChart_DVA, "Построить график по данным из выбранного столбца");
            this.buttonAddChart_DVA.UseVisualStyleBackColor = true;
            this.buttonAddChart_DVA.Click += new System.EventHandler(this.buttonAddChart_DVA_Click);
            // 
            // buttonSaveFile_DVA
            // 
            this.buttonSaveFile_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveFile_DVA.Image = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.database_save;
            this.buttonSaveFile_DVA.Location = new System.Drawing.Point(237, 39);
            this.buttonSaveFile_DVA.Name = "buttonSaveFile_DVA";
            this.buttonSaveFile_DVA.Size = new System.Drawing.Size(175, 85);
            this.buttonSaveFile_DVA.TabIndex = 0;
            this.toolTipSaveFile_DVA.SetToolTip(this.buttonSaveFile_DVA, "Сохранить базу данных по выбранному пути");
            this.buttonSaveFile_DVA.UseVisualStyleBackColor = true;
            this.buttonSaveFile_DVA.Click += new System.EventHandler(this.buttonSaveFile_DVA_Click);
            // 
            // buttonOpenFile_DVA
            // 
            this.buttonOpenFile_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenFile_DVA.Image = global::Tyuiu.DolgushinVA.Sprint7.Project.V12.Properties.Resources.folder_database;
            this.buttonOpenFile_DVA.Location = new System.Drawing.Point(19, 39);
            this.buttonOpenFile_DVA.Name = "buttonOpenFile_DVA";
            this.buttonOpenFile_DVA.Size = new System.Drawing.Size(175, 85);
            this.buttonOpenFile_DVA.TabIndex = 1;
            this.toolTipOpenFile_DVA.SetToolTip(this.buttonOpenFile_DVA, "Открыть выбранную в проводнике базу данных");
            this.buttonOpenFile_DVA.UseVisualStyleBackColor = true;
            this.buttonOpenFile_DVA.Click += new System.EventHandler(this.buttonOpenFile_DVA_Click);
            // 
            // chartFunction_DVA
            // 
            this.chartFunction_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartFunction_DVA.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartFunction_DVA.Legends.Add(legend1);
            this.chartFunction_DVA.Location = new System.Drawing.Point(645, 34);
            this.chartFunction_DVA.Name = "chartFunction_DVA";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFunction_DVA.Series.Add(series1);
            this.chartFunction_DVA.Size = new System.Drawing.Size(656, 452);
            this.chartFunction_DVA.TabIndex = 1;
            this.chartFunction_DVA.Text = "chart1";
            // 
            // dataGridViewOpenDataBase_DVA
            // 
            this.dataGridViewOpenDataBase_DVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewOpenDataBase_DVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpenDataBase_DVA.ColumnHeadersVisible = false;
            this.dataGridViewOpenDataBase_DVA.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewOpenDataBase_DVA.Name = "dataGridViewOpenDataBase_DVA";
            this.dataGridViewOpenDataBase_DVA.RowHeadersVisible = false;
            this.dataGridViewOpenDataBase_DVA.RowHeadersWidth = 51;
            this.dataGridViewOpenDataBase_DVA.RowTemplate.Height = 24;
            this.dataGridViewOpenDataBase_DVA.Size = new System.Drawing.Size(633, 452);
            this.dataGridViewOpenDataBase_DVA.TabIndex = 0;
            // 
            // menuStrip_DVA
            // 
            this.menuStrip_DVA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip_DVA.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip_DVA.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_DVA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.главнаяСтраницаToolStripMenuItem,
            this.руководствоToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip_DVA.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_DVA.Name = "menuStrip_DVA";
            this.menuStrip_DVA.Size = new System.Drawing.Size(1307, 31);
            this.menuStrip_DVA.TabIndex = 3;
            this.menuStrip_DVA.Text = "menuStrip_DVA";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(66, 27);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemOpenFile_DVA_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(179, 28);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemSaveFile_DVA_Click);
            // 
            // главнаяСтраницаToolStripMenuItem
            // 
            this.главнаяСтраницаToolStripMenuItem.Name = "главнаяСтраницаToolStripMenuItem";
            this.главнаяСтраницаToolStripMenuItem.Size = new System.Drawing.Size(166, 27);
            this.главнаяСтраницаToolStripMenuItem.Text = "Главная страница";
            this.главнаяСтраницаToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemMainPage_DVA_Click);
            // 
            // руководствоToolStripMenuItem
            // 
            this.руководствоToolStripMenuItem.Name = "руководствоToolStripMenuItem";
            this.руководствоToolStripMenuItem.Size = new System.Drawing.Size(125, 27);
            this.руководствоToolStripMenuItem.Text = "Руководство";
            this.руководствоToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemGuide_DVA_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(133, 27);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemAbout_DVA_Click);
            // 
            // FormCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 657);
            this.Controls.Add(this.panelCharts_DVA);
            this.Controls.Add(this.panelDownC_DVA);
            this.Controls.Add(this.panelRightC_DVA);
            this.Controls.Add(this.panelLeftC_DVA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_DVA;
            this.Name = "FormCharts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение графиков";
            this.panelCharts_DVA.ResumeLayout(false);
            this.panelCharts_DVA.PerformLayout();
            this.groupBoxActions_DVA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction_DVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpenDataBase_DVA)).EndInit();
            this.menuStrip_DVA.ResumeLayout(false);
            this.menuStrip_DVA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeftC_DVA;
        private System.Windows.Forms.Panel panelRightC_DVA;
        private System.Windows.Forms.Panel panelDownC_DVA;
        private System.Windows.Forms.Panel panelCharts_DVA;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction_DVA;
        private System.Windows.Forms.DataGridView dataGridViewOpenDataBase_DVA;
        private System.Windows.Forms.GroupBox groupBoxActions_DVA;
        private System.Windows.Forms.Button buttonOpenFile_DVA;
        private System.Windows.Forms.Button buttonSaveFile_DVA;
        private System.Windows.Forms.Button buttonDeleteChart_DVA;
        private System.Windows.Forms.Button buttonAddChart_DVA;
        private System.Windows.Forms.MenuStrip menuStrip_DVA;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главнаяСтраницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog_DVA;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_DVA;
        private System.Windows.Forms.ToolTip toolTipOpenFile_DVA;
        private System.Windows.Forms.ToolTip toolTipSaveFile_DVA;
        private System.Windows.Forms.ToolTip toolTipAddChart_DVA;
        private System.Windows.Forms.ToolTip toolTipDeleteChart_DVA;
    }
}