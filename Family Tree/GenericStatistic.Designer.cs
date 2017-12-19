namespace Family_Tree
{
    partial class GenericStatistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericStatistic));
            this.PeopleByGeneration = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startPersonGroupBox = new System.Windows.Forms.GroupBox();
            this.startPersonComboBox = new System.Windows.Forms.ComboBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DivorcedConunt = new System.Windows.Forms.Label();
            this.MaxChildrenCount = new System.Windows.Forms.Label();
            this.WomanCount = new System.Windows.Forms.Label();
            this.ManCount = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleByGeneration)).BeginInit();
            this.startPersonGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PeopleByGeneration
            // 
            chartArea1.Name = "ChartArea1";
            this.PeopleByGeneration.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.PeopleByGeneration.Legends.Add(legend1);
            this.PeopleByGeneration.Location = new System.Drawing.Point(16, 81);
            this.PeopleByGeneration.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PeopleByGeneration.Name = "PeopleByGeneration";
            this.PeopleByGeneration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.PeopleByGeneration.Series.Add(series1);
            this.PeopleByGeneration.Size = new System.Drawing.Size(444, 260);
            this.PeopleByGeneration.TabIndex = 1;
            this.PeopleByGeneration.Text = "Возрастная статистика";
            // 
            // startPersonGroupBox
            // 
            this.startPersonGroupBox.Controls.Add(this.startPersonComboBox);
            this.startPersonGroupBox.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.startPersonGroupBox.Location = new System.Drawing.Point(16, 14);
            this.startPersonGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startPersonGroupBox.Name = "startPersonGroupBox";
            this.startPersonGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startPersonGroupBox.Size = new System.Drawing.Size(332, 60);
            this.startPersonGroupBox.TabIndex = 12;
            this.startPersonGroupBox.TabStop = false;
            this.startPersonGroupBox.Text = "Исходное лицо";
            // 
            // startPersonComboBox
            // 
            this.startPersonComboBox.DropDownHeight = 200;
            this.startPersonComboBox.DropDownWidth = 248;
            this.startPersonComboBox.FormattingEnabled = true;
            this.startPersonComboBox.IntegralHeight = false;
            this.startPersonComboBox.Location = new System.Drawing.Point(7, 21);
            this.startPersonComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.startPersonComboBox.Name = "startPersonComboBox";
            this.startPersonComboBox.Size = new System.Drawing.Size(316, 22);
            this.startPersonComboBox.Sorted = true;
            this.startPersonComboBox.TabIndex = 5;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(360, 35);
            this.CalculateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(100, 27);
            this.CalculateButton.TabIndex = 13;
            this.CalculateButton.Text = "Посчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DivorcedConunt);
            this.groupBox1.Controls.Add(this.MaxChildrenCount);
            this.groupBox1.Controls.Add(this.WomanCount);
            this.groupBox1.Controls.Add(this.ManCount);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(16, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 122);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Родовая статистика";
            // 
            // DivorcedConunt
            // 
            this.DivorcedConunt.AutoSize = true;
            this.DivorcedConunt.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.DivorcedConunt.Location = new System.Drawing.Point(7, 99);
            this.DivorcedConunt.Name = "DivorcedConunt";
            this.DivorcedConunt.Size = new System.Drawing.Size(201, 16);
            this.DivorcedConunt.TabIndex = 3;
            this.DivorcedConunt.Text = "Количество разводов в роду: ";
            // 
            // MaxChildrenCount
            // 
            this.MaxChildrenCount.AutoSize = true;
            this.MaxChildrenCount.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.MaxChildrenCount.Location = new System.Drawing.Point(7, 73);
            this.MaxChildrenCount.Name = "MaxChildrenCount";
            this.MaxChildrenCount.Size = new System.Drawing.Size(283, 16);
            this.MaxChildrenCount.TabIndex = 2;
            this.MaxChildrenCount.Text = "Максимальное количество детей в семье:";
            // 
            // WomanCount
            // 
            this.WomanCount.AutoSize = true;
            this.WomanCount.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.WomanCount.Location = new System.Drawing.Point(7, 47);
            this.WomanCount.Name = "WomanCount";
            this.WomanCount.Size = new System.Drawing.Size(197, 16);
            this.WomanCount.TabIndex = 1;
            this.WomanCount.Text = "Количество женщин в роду: ";
            // 
            // ManCount
            // 
            this.ManCount.AutoSize = true;
            this.ManCount.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.ManCount.Location = new System.Drawing.Point(7, 22);
            this.ManCount.Name = "ManCount";
            this.ManCount.Size = new System.Drawing.Size(196, 16);
            this.ManCount.TabIndex = 0;
            this.ManCount.Text = "Количество мужчин в роду: ";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(204, 475);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // GenericStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 502);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.startPersonGroupBox);
            this.Controls.Add(this.PeopleByGeneration);
            this.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "GenericStatistic";
            this.Text = "GenericStatistic";
            ((System.ComponentModel.ISupportInitialize)(this.PeopleByGeneration)).EndInit();
            this.startPersonGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart PeopleByGeneration;
        private System.Windows.Forms.GroupBox startPersonGroupBox;
        private System.Windows.Forms.ComboBox startPersonComboBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DivorcedConunt;
        private System.Windows.Forms.Label MaxChildrenCount;
        private System.Windows.Forms.Label WomanCount;
        private System.Windows.Forms.Label ManCount;
        private System.Windows.Forms.Button okButton;
    }
}