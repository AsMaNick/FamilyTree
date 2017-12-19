namespace Family_Tree
{
    partial class AddPhoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhoto));
            this.photoPanel = new System.Windows.Forms.Panel();
            this.photo = new System.Windows.Forms.PictureBox();
            this.additionalInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CreationYear = new System.Windows.Forms.TextBox();
            this.CreationMonth = new System.Windows.Forms.ComboBox();
            this.CreationDay = new System.Windows.Forms.TextBox();
            this.AdditionalInfoLabel = new System.Windows.Forms.Label();
            this.PlaceCreationLabel = new System.Windows.Forms.Label();
            this.YearCreationLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.labeledPeoplePanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteLabelMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaceOfCreationComboBox = new System.Windows.Forms.ComboBox();
            this.photoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.photoGroupBox.SuspendLayout();
            this.deleteLabelMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // photoPanel
            // 
            this.photoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoPanel.AutoScroll = true;
            this.photoPanel.Controls.Add(this.photo);
            this.photoPanel.Location = new System.Drawing.Point(6, 19);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(365, 346);
            this.photoPanel.TabIndex = 0;
            // 
            // photo
            // 
            this.photo.Location = new System.Drawing.Point(4, 4);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(284, 239);
            this.photo.TabIndex = 0;
            this.photo.TabStop = false;
            this.photo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.photo_MouseDown);
            this.photo.MouseLeave += new System.EventHandler(this.photo_MouseLeave);
            this.photo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.photo_MouseMove);
            this.photo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.photo_MouseUp);
            // 
            // additionalInfo
            // 
            this.additionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.additionalInfo.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.additionalInfo.Location = new System.Drawing.Point(6, 128);
            this.additionalInfo.Name = "additionalInfo";
            this.additionalInfo.Size = new System.Drawing.Size(317, 99);
            this.additionalInfo.TabIndex = 2;
            this.additionalInfo.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PlaceOfCreationComboBox);
            this.groupBox1.Controls.Add(this.CreationYear);
            this.groupBox1.Controls.Add(this.CreationMonth);
            this.groupBox1.Controls.Add(this.CreationDay);
            this.groupBox1.Controls.Add(this.AdditionalInfoLabel);
            this.groupBox1.Controls.Add(this.PlaceCreationLabel);
            this.groupBox1.Controls.Add(this.YearCreationLabel);
            this.groupBox1.Controls.Add(this.additionalInfo);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(437, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 231);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о фотографии";
            // 
            // CreationYear
            // 
            this.CreationYear.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.CreationYear.Location = new System.Drawing.Point(121, 40);
            this.CreationYear.MaxLength = 4;
            this.CreationYear.Name = "CreationYear";
            this.CreationYear.Size = new System.Drawing.Size(39, 22);
            this.CreationYear.TabIndex = 128;
            // 
            // CreationMonth
            // 
            this.CreationMonth.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.CreationMonth.FormattingEnabled = true;
            this.CreationMonth.Items.AddRange(new object[] {
            "января",
            "февраля",
            "марта",
            "апреля",
            "мая",
            "июня",
            "июля",
            "августа",
            "сентября",
            "октября",
            "ноября",
            "декабря"});
            this.CreationMonth.Location = new System.Drawing.Point(34, 40);
            this.CreationMonth.MaxLength = 8;
            this.CreationMonth.Name = "CreationMonth";
            this.CreationMonth.Size = new System.Drawing.Size(87, 23);
            this.CreationMonth.TabIndex = 127;
            // 
            // CreationDay
            // 
            this.CreationDay.Font = new System.Drawing.Font("Georgia", 9.25F);
            this.CreationDay.Location = new System.Drawing.Point(7, 40);
            this.CreationDay.MaxLength = 2;
            this.CreationDay.Name = "CreationDay";
            this.CreationDay.Size = new System.Drawing.Size(24, 22);
            this.CreationDay.TabIndex = 126;
            // 
            // AdditionalInfoLabel
            // 
            this.AdditionalInfoLabel.AutoSize = true;
            this.AdditionalInfoLabel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.AdditionalInfoLabel.Location = new System.Drawing.Point(7, 111);
            this.AdditionalInfoLabel.Name = "AdditionalInfoLabel";
            this.AdditionalInfoLabel.Size = new System.Drawing.Size(188, 14);
            this.AdditionalInfoLabel.TabIndex = 7;
            this.AdditionalInfoLabel.Text = "Дополнительная информация";
            // 
            // PlaceCreationLabel
            // 
            this.PlaceCreationLabel.AutoSize = true;
            this.PlaceCreationLabel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.PlaceCreationLabel.Location = new System.Drawing.Point(7, 65);
            this.PlaceCreationLabel.Name = "PlaceCreationLabel";
            this.PlaceCreationLabel.Size = new System.Drawing.Size(89, 14);
            this.PlaceCreationLabel.TabIndex = 6;
            this.PlaceCreationLabel.Text = "Место съемки";
            // 
            // YearCreationLabel
            // 
            this.YearCreationLabel.AutoSize = true;
            this.YearCreationLabel.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.YearCreationLabel.Location = new System.Drawing.Point(7, 23);
            this.YearCreationLabel.Name = "YearCreationLabel";
            this.YearCreationLabel.Size = new System.Drawing.Size(84, 14);
            this.YearCreationLabel.TabIndex = 3;
            this.YearCreationLabel.Text = "Дата съемки";
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.okButton.Location = new System.Drawing.Point(353, 390);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(72, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.plusButton.Image = global::Family_Tree.Properties.Resources.plus;
            this.plusButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.plusButton.Location = new System.Drawing.Point(12, 161);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(24, 24);
            this.plusButton.TabIndex = 4;
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.minusButton.Image = global::Family_Tree.Properties.Resources.minus;
            this.minusButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.minusButton.Location = new System.Drawing.Point(12, 191);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(24, 24);
            this.minusButton.TabIndex = 1;
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // scaleLabel
            // 
            this.scaleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.BackColor = System.Drawing.Color.Transparent;
            this.scaleLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.scaleLabel.Location = new System.Drawing.Point(5, 218);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(43, 16);
            this.scaleLabel.TabIndex = 5;
            this.scaleLabel.Text = "100%";
            // 
            // labeledPeoplePanel
            // 
            this.labeledPeoplePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labeledPeoplePanel.AutoScroll = true;
            this.labeledPeoplePanel.Location = new System.Drawing.Point(6, 19);
            this.labeledPeoplePanel.Name = "labeledPeoplePanel";
            this.labeledPeoplePanel.Size = new System.Drawing.Size(317, 109);
            this.labeledPeoplePanel.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labeledPeoplePanel);
            this.groupBox2.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(437, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 134);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отмеченные персоны";
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoGroupBox.Controls.Add(this.photoPanel);
            this.photoGroupBox.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.photoGroupBox.Location = new System.Drawing.Point(54, 13);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Size = new System.Drawing.Size(377, 371);
            this.photoGroupBox.TabIndex = 7;
            this.photoGroupBox.TabStop = false;
            // 
            // deleteLabelMenuStrip
            // 
            this.deleteLabelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.deleteLabelMenuStrip.Name = "deleteLabelMenuStrip";
            this.deleteLabelMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // PlaceOfCreationComboBox
            // 
            this.PlaceOfCreationComboBox.FormattingEnabled = true;
            this.PlaceOfCreationComboBox.Location = new System.Drawing.Point(7, 83);
            this.PlaceOfCreationComboBox.Name = "PlaceOfCreationComboBox";
            this.PlaceOfCreationComboBox.Size = new System.Drawing.Size(316, 24);
            this.PlaceOfCreationComboBox.TabIndex = 129;
            // 
            // AddPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 418);
            this.Controls.Add(this.photoGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.scaleLabel);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 456);
            this.Name = "AddPhoto";
            this.Text = "Фотография";
            this.Activated += new System.EventHandler(this.AddPhoto_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPhoto_FormClosing);
            this.SizeChanged += new System.EventHandler(this.AddPhoto_SizeChanged);
            this.photoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.photoGroupBox.ResumeLayout(false);
            this.deleteLabelMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.PictureBox photo;
        private System.Windows.Forms.RichTextBox additionalInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.Panel labeledPeoplePanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.ContextMenuStrip deleteLabelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Label AdditionalInfoLabel;
        private System.Windows.Forms.Label PlaceCreationLabel;
        private System.Windows.Forms.Label YearCreationLabel;
        private System.Windows.Forms.TextBox CreationYear;
        private System.Windows.Forms.ComboBox CreationMonth;
        private System.Windows.Forms.TextBox CreationDay;
        private System.Windows.Forms.ComboBox PlaceOfCreationComboBox;
    }
}