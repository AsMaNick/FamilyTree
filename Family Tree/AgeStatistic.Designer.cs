namespace Family_Tree
{
    partial class AgeStatistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgeStatistic));
            this.PeopleByAge = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Woman = new System.Windows.Forms.Label();
            this.Man = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleByAge)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PeopleByAge
            // 
            chartArea1.Name = "ChartArea1";
            this.PeopleByAge.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.PeopleByAge.Legends.Add(legend1);
            this.PeopleByAge.Location = new System.Drawing.Point(12, 12);
            this.PeopleByAge.Name = "PeopleByAge";
            this.PeopleByAge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.PeopleByAge.Series.Add(series1);
            this.PeopleByAge.Size = new System.Drawing.Size(401, 247);
            this.PeopleByAge.TabIndex = 0;
            this.PeopleByAge.Text = "Возрастная статистика";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Woman);
            this.groupBox1.Controls.Add(this.Man);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(13, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Долгожители";
            // 
            // Woman
            // 
            this.Woman.AutoSize = true;
            this.Woman.Location = new System.Drawing.Point(6, 63);
            this.Woman.Name = "Woman";
            this.Woman.Size = new System.Drawing.Size(20, 16);
            this.Woman.TabIndex = 1;
            this.Woman.Text = "Ж";
            // 
            // Man
            // 
            this.Man.AutoSize = true;
            this.Man.Location = new System.Drawing.Point(6, 29);
            this.Man.Name = "Man";
            this.Man.Size = new System.Drawing.Size(20, 16);
            this.Man.TabIndex = 0;
            this.Man.Text = "М";
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.OkButton.Location = new System.Drawing.Point(177, 372);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AgeStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 398);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PeopleByAge);
            this.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AgeStatistic";
            this.Text = "Возрастная статистика";
            ((System.ComponentModel.ISupportInitialize)(this.PeopleByAge)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart PeopleByAge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Woman;
        private System.Windows.Forms.Label Man;
        private System.Windows.Forms.Button OkButton;
    }
}