namespace Family_Tree
{
    partial class TotalReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotalReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TotalCount = new System.Windows.Forms.Label();
            this.ManCount = new System.Windows.Forms.Label();
            this.WomanCount = new System.Windows.Forms.Label();
            this.PhotoCount = new System.Windows.Forms.Label();
            this.LabeledPeopleCount = new System.Windows.Forms.Label();
            this.ConnectionsCount = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OK);
            this.groupBox1.Controls.Add(this.ConnectionsCount);
            this.groupBox1.Controls.Add(this.LabeledPeopleCount);
            this.groupBox1.Controls.Add(this.PhotoCount);
            this.groupBox1.Controls.Add(this.WomanCount);
            this.groupBox1.Controls.Add(this.ManCount);
            this.groupBox1.Controls.Add(this.TotalCount);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общая информация";
            // 
            // TotalCount
            // 
            this.TotalCount.AutoSize = true;
            this.TotalCount.Location = new System.Drawing.Point(6, 33);
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.Size = new System.Drawing.Size(127, 16);
            this.TotalCount.TabIndex = 0;
            this.TotalCount.Text = "Дерево содержит ";
            this.TotalCount.Click += new System.EventHandler(this.TotalCount_Click);
            // 
            // ManCount
            // 
            this.ManCount.AutoSize = true;
            this.ManCount.Location = new System.Drawing.Point(6, 60);
            this.ManCount.Name = "ManCount";
            this.ManCount.Size = new System.Drawing.Size(144, 16);
            this.ManCount.TabIndex = 1;
            this.ManCount.Text = "Количество мужчин";
            this.ManCount.Click += new System.EventHandler(this.ManCount_Click);
            // 
            // WomanCount
            // 
            this.WomanCount.AutoSize = true;
            this.WomanCount.Location = new System.Drawing.Point(6, 87);
            this.WomanCount.Name = "WomanCount";
            this.WomanCount.Size = new System.Drawing.Size(145, 16);
            this.WomanCount.TabIndex = 2;
            this.WomanCount.Text = "Количество женщин";
            this.WomanCount.Click += new System.EventHandler(this.WomanCount_Click);
            // 
            // PhotoCount
            // 
            this.PhotoCount.AutoSize = true;
            this.PhotoCount.Location = new System.Drawing.Point(6, 141);
            this.PhotoCount.Name = "PhotoCount";
            this.PhotoCount.Size = new System.Drawing.Size(217, 16);
            this.PhotoCount.TabIndex = 3;
            this.PhotoCount.Text = "Общее количество фотографий";
            this.PhotoCount.Click += new System.EventHandler(this.PhotoCount_Click);
            // 
            // LabeledPeopleCount
            // 
            this.LabeledPeopleCount.AutoSize = true;
            this.LabeledPeopleCount.Location = new System.Drawing.Point(6, 168);
            this.LabeledPeopleCount.Name = "LabeledPeopleCount";
            this.LabeledPeopleCount.Size = new System.Drawing.Size(221, 16);
            this.LabeledPeopleCount.TabIndex = 4;
            this.LabeledPeopleCount.Text = "Количество отмеченных персон";
            // 
            // ConnectionsCount
            // 
            this.ConnectionsCount.AutoSize = true;
            this.ConnectionsCount.Location = new System.Drawing.Point(6, 114);
            this.ConnectionsCount.Name = "ConnectionsCount";
            this.ConnectionsCount.Size = new System.Drawing.Size(223, 16);
            this.ConnectionsCount.TabIndex = 5;
            this.ConnectionsCount.Text = "Количество родственных связей";
            this.ConnectionsCount.Click += new System.EventHandler(this.ConnectionsCount_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(99, 208);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 6;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // TotalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 262);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TotalReport";
            this.Text = "TotalReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label ConnectionsCount;
        private System.Windows.Forms.Label LabeledPeopleCount;
        private System.Windows.Forms.Label PhotoCount;
        private System.Windows.Forms.Label WomanCount;
        private System.Windows.Forms.Label ManCount;
        private System.Windows.Forms.Label TotalCount;
    }
}