namespace Family_Tree
{
    partial class AddPerson
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
            this.mainInfoLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.patronymicLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.deathDataLabel = new System.Windows.Forms.Label();
            this.birthPlaceLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.patronomicTextBox = new System.Windows.Forms.TextBox();
            this.birthPlaceTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.birthdayDate = new System.Windows.Forms.DateTimePicker();
            this.deathDate = new System.Windows.Forms.DateTimePicker();
            this.manRadioButton = new System.Windows.Forms.RadioButton();
            this.womanRadioButton = new System.Windows.Forms.RadioButton();
            this.aliveRadioButton = new System.Windows.Forms.RadioButton();
            this.deadRadioButton = new System.Windows.Forms.RadioButton();
            this.mainInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.maidenNameTextBox = new System.Windows.Forms.TextBox();
            this.maidenNameLabel = new System.Windows.Forms.Label();
            this.aliveInfo = new System.Windows.Forms.GroupBox();
            this.contactsTextBox = new System.Windows.Forms.TextBox();
            this.contactsLabel = new System.Windows.Forms.Label();
            this.burialPlaceTextBox = new System.Windows.Forms.TextBox();
            this.burialPlaceLabel = new System.Windows.Forms.Label();
            this.avaterGroupBox = new System.Windows.Forms.GroupBox();
            this.addPhotoButton = new System.Windows.Forms.Button();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.additionalInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.additionalInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.mainInfoGroupBox.SuspendLayout();
            this.aliveInfo.SuspendLayout();
            this.avaterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.additionalInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainInfoLabel
            // 
            this.mainInfoLabel.AutoSize = true;
            this.mainInfoLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainInfoLabel.Location = new System.Drawing.Point(128, 10);
            this.mainInfoLabel.Name = "mainInfoLabel";
            this.mainInfoLabel.Size = new System.Drawing.Size(218, 16);
            this.mainInfoLabel.TabIndex = 0;
            this.mainInfoLabel.Text = "Введите основную информацию";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameLabel.Location = new System.Drawing.Point(7, 50);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(72, 16);
            this.surnameLabel.TabIndex = 1;
            this.surnameLabel.Text = "Фамилия:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(198, 50);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(40, 16);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Имя:";
            // 
            // patronymicLabel
            // 
            this.patronymicLabel.AutoSize = true;
            this.patronymicLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patronymicLabel.Location = new System.Drawing.Point(7, 106);
            this.patronymicLabel.Name = "patronymicLabel";
            this.patronymicLabel.Size = new System.Drawing.Size(74, 16);
            this.patronymicLabel.TabIndex = 3;
            this.patronymicLabel.Text = "Отчество:";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthdayLabel.Location = new System.Drawing.Point(7, 163);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(114, 16);
            this.birthdayLabel.TabIndex = 4;
            this.birthdayLabel.Text = "Дата рождения:";
            // 
            // deathDataLabel
            // 
            this.deathDataLabel.AutoSize = true;
            this.deathDataLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deathDataLabel.Location = new System.Drawing.Point(7, 42);
            this.deathDataLabel.Name = "deathDataLabel";
            this.deathDataLabel.Size = new System.Drawing.Size(95, 16);
            this.deathDataLabel.TabIndex = 5;
            this.deathDataLabel.Text = "Дата смерти:";
            this.deathDataLabel.Visible = false;
            // 
            // birthPlaceLabel
            // 
            this.birthPlaceLabel.AutoSize = true;
            this.birthPlaceLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthPlaceLabel.Location = new System.Drawing.Point(198, 163);
            this.birthPlaceLabel.Name = "birthPlaceLabel";
            this.birthPlaceLabel.Size = new System.Drawing.Size(124, 16);
            this.birthPlaceLabel.TabIndex = 6;
            this.birthPlaceLabel.Text = "Место рождения:";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(7, 71);
            this.surnameTextBox.MaxLength = 20;
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(116, 20);
            this.surnameTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(198, 71);
            this.nameTextBox.MaxLength = 20;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(135, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // patronomicTextBox
            // 
            this.patronomicTextBox.Location = new System.Drawing.Point(7, 125);
            this.patronomicTextBox.MaxLength = 20;
            this.patronomicTextBox.Name = "patronomicTextBox";
            this.patronomicTextBox.Size = new System.Drawing.Size(116, 20);
            this.patronomicTextBox.TabIndex = 4;
            // 
            // birthPlaceTextBox
            // 
            this.birthPlaceTextBox.Location = new System.Drawing.Point(198, 184);
            this.birthPlaceTextBox.MaxLength = 50;
            this.birthPlaceTextBox.Name = "birthPlaceTextBox";
            this.birthPlaceTextBox.Size = new System.Drawing.Size(135, 20);
            this.birthPlaceTextBox.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(199, 507);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(103, 25);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // birthdayDate
            // 
            this.birthdayDate.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthdayDate.Location = new System.Drawing.Point(7, 184);
            this.birthdayDate.Name = "birthdayDate";
            this.birthdayDate.Size = new System.Drawing.Size(182, 22);
            this.birthdayDate.TabIndex = 6;
            // 
            // deathDate
            // 
            this.deathDate.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deathDate.Location = new System.Drawing.Point(7, 64);
            this.deathDate.Name = "deathDate";
            this.deathDate.Size = new System.Drawing.Size(182, 22);
            this.deathDate.TabIndex = 3;
            this.deathDate.Visible = false;
            // 
            // manRadioButton
            // 
            this.manRadioButton.AutoSize = true;
            this.manRadioButton.Checked = true;
            this.manRadioButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.manRadioButton.Location = new System.Drawing.Point(7, 20);
            this.manRadioButton.Name = "manRadioButton";
            this.manRadioButton.Size = new System.Drawing.Size(84, 18);
            this.manRadioButton.TabIndex = 110;
            this.manRadioButton.TabStop = true;
            this.manRadioButton.Text = "Мужчина";
            this.manRadioButton.UseVisualStyleBackColor = true;
            this.manRadioButton.CheckedChanged += new System.EventHandler(this.manRadioButton_CheckedChanged);
            // 
            // womanRadioButton
            // 
            this.womanRadioButton.AutoSize = true;
            this.womanRadioButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.womanRadioButton.Location = new System.Drawing.Point(198, 20);
            this.womanRadioButton.Name = "womanRadioButton";
            this.womanRadioButton.Size = new System.Drawing.Size(84, 18);
            this.womanRadioButton.TabIndex = 122;
            this.womanRadioButton.Text = "Женщина";
            this.womanRadioButton.UseVisualStyleBackColor = true;
            this.womanRadioButton.CheckedChanged += new System.EventHandler(this.womanRadioButton_CheckedChanged);
            // 
            // aliveRadioButton
            // 
            this.aliveRadioButton.AutoSize = true;
            this.aliveRadioButton.Checked = true;
            this.aliveRadioButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aliveRadioButton.Location = new System.Drawing.Point(7, 20);
            this.aliveRadioButton.Name = "aliveRadioButton";
            this.aliveRadioButton.Size = new System.Drawing.Size(52, 18);
            this.aliveRadioButton.TabIndex = 0;
            this.aliveRadioButton.TabStop = true;
            this.aliveRadioButton.Text = "Жив";
            this.aliveRadioButton.UseVisualStyleBackColor = true;
            this.aliveRadioButton.CheckedChanged += new System.EventHandler(this.aliveRadioButton_CheckedChanged);
            // 
            // deadRadioButton
            // 
            this.deadRadioButton.AutoSize = true;
            this.deadRadioButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deadRadioButton.Location = new System.Drawing.Point(198, 20);
            this.deadRadioButton.Name = "deadRadioButton";
            this.deadRadioButton.Size = new System.Drawing.Size(57, 18);
            this.deadRadioButton.TabIndex = 1;
            this.deadRadioButton.Text = "Умер";
            this.deadRadioButton.UseVisualStyleBackColor = true;
            this.deadRadioButton.CheckedChanged += new System.EventHandler(this.deadRadioButton_CheckedChanged);
            // 
            // mainInfoGroupBox
            // 
            this.mainInfoGroupBox.Controls.Add(this.maidenNameTextBox);
            this.mainInfoGroupBox.Controls.Add(this.maidenNameLabel);
            this.mainInfoGroupBox.Controls.Add(this.manRadioButton);
            this.mainInfoGroupBox.Controls.Add(this.womanRadioButton);
            this.mainInfoGroupBox.Controls.Add(this.surnameLabel);
            this.mainInfoGroupBox.Controls.Add(this.birthdayDate);
            this.mainInfoGroupBox.Controls.Add(this.birthPlaceTextBox);
            this.mainInfoGroupBox.Controls.Add(this.surnameTextBox);
            this.mainInfoGroupBox.Controls.Add(this.birthPlaceLabel);
            this.mainInfoGroupBox.Controls.Add(this.nameLabel);
            this.mainInfoGroupBox.Controls.Add(this.nameTextBox);
            this.mainInfoGroupBox.Controls.Add(this.patronomicTextBox);
            this.mainInfoGroupBox.Controls.Add(this.patronymicLabel);
            this.mainInfoGroupBox.Controls.Add(this.birthdayLabel);
            this.mainInfoGroupBox.Location = new System.Drawing.Point(145, 47);
            this.mainInfoGroupBox.Name = "mainInfoGroupBox";
            this.mainInfoGroupBox.Size = new System.Drawing.Size(341, 225);
            this.mainInfoGroupBox.TabIndex = 0;
            this.mainInfoGroupBox.TabStop = false;
            // 
            // maidenNameTextBox
            // 
            this.maidenNameTextBox.Location = new System.Drawing.Point(198, 124);
            this.maidenNameTextBox.MaxLength = 20;
            this.maidenNameTextBox.Name = "maidenNameTextBox";
            this.maidenNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.maidenNameTextBox.TabIndex = 5;
            // 
            // maidenNameLabel
            // 
            this.maidenNameLabel.AutoSize = true;
            this.maidenNameLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.maidenNameLabel.Location = new System.Drawing.Point(198, 105);
            this.maidenNameLabel.Name = "maidenNameLabel";
            this.maidenNameLabel.Size = new System.Drawing.Size(132, 16);
            this.maidenNameLabel.TabIndex = 18;
            this.maidenNameLabel.Text = "Фамилия до брака:";
            // 
            // aliveInfo
            // 
            this.aliveInfo.Controls.Add(this.contactsTextBox);
            this.aliveInfo.Controls.Add(this.contactsLabel);
            this.aliveInfo.Controls.Add(this.burialPlaceTextBox);
            this.aliveInfo.Controls.Add(this.burialPlaceLabel);
            this.aliveInfo.Controls.Add(this.aliveRadioButton);
            this.aliveInfo.Controls.Add(this.deadRadioButton);
            this.aliveInfo.Controls.Add(this.deathDate);
            this.aliveInfo.Controls.Add(this.deathDataLabel);
            this.aliveInfo.Location = new System.Drawing.Point(145, 279);
            this.aliveInfo.Name = "aliveInfo";
            this.aliveInfo.Size = new System.Drawing.Size(341, 108);
            this.aliveInfo.TabIndex = 1;
            this.aliveInfo.TabStop = false;
            // 
            // contactsTextBox
            // 
            this.contactsTextBox.Location = new System.Drawing.Point(7, 64);
            this.contactsTextBox.MaxLength = 100;
            this.contactsTextBox.Name = "contactsTextBox";
            this.contactsTextBox.Size = new System.Drawing.Size(182, 20);
            this.contactsTextBox.TabIndex = 2;
            // 
            // contactsLabel
            // 
            this.contactsLabel.AutoSize = true;
            this.contactsLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.contactsLabel.Location = new System.Drawing.Point(7, 42);
            this.contactsLabel.Name = "contactsLabel";
            this.contactsLabel.Size = new System.Drawing.Size(78, 16);
            this.contactsLabel.TabIndex = 22;
            this.contactsLabel.Text = "Контакты:";
            // 
            // burialPlaceTextBox
            // 
            this.burialPlaceTextBox.Location = new System.Drawing.Point(198, 65);
            this.burialPlaceTextBox.MaxLength = 100;
            this.burialPlaceTextBox.Name = "burialPlaceTextBox";
            this.burialPlaceTextBox.Size = new System.Drawing.Size(135, 20);
            this.burialPlaceTextBox.TabIndex = 4;
            this.burialPlaceTextBox.Visible = false;
            // 
            // burialPlaceLabel
            // 
            this.burialPlaceLabel.AutoSize = true;
            this.burialPlaceLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.burialPlaceLabel.Location = new System.Drawing.Point(198, 44);
            this.burialPlaceLabel.Name = "burialPlaceLabel";
            this.burialPlaceLabel.Size = new System.Drawing.Size(141, 16);
            this.burialPlaceLabel.TabIndex = 20;
            this.burialPlaceLabel.Text = "Место захоронения:";
            this.burialPlaceLabel.Visible = false;
            // 
            // avaterGroupBox
            // 
            this.avaterGroupBox.BackColor = System.Drawing.Color.Snow;
            this.avaterGroupBox.Controls.Add(this.addPhotoButton);
            this.avaterGroupBox.Controls.Add(this.avatarPictureBox);
            this.avaterGroupBox.Location = new System.Drawing.Point(14, 47);
            this.avaterGroupBox.Name = "avaterGroupBox";
            this.avaterGroupBox.Size = new System.Drawing.Size(124, 339);
            this.avaterGroupBox.TabIndex = 3;
            this.avaterGroupBox.TabStop = false;
            // 
            // addPhotoButton
            // 
            this.addPhotoButton.BackColor = System.Drawing.Color.Transparent;
            this.addPhotoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addPhotoButton.Image = global::Family_Tree.Properties.Resources.camera_40;
            this.addPhotoButton.Location = new System.Drawing.Point(44, 106);
            this.addPhotoButton.Name = "addPhotoButton";
            this.addPhotoButton.Size = new System.Drawing.Size(33, 23);
            this.addPhotoButton.TabIndex = 1;
            this.addPhotoButton.TabStop = false;
            this.addPhotoButton.UseVisualStyleBackColor = false;
            this.addPhotoButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Image = global::Family_Tree.Properties.Resources.man2;
            this.avatarPictureBox.Location = new System.Drawing.Point(22, 19);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(79, 103);
            this.avatarPictureBox.TabIndex = 0;
            this.avatarPictureBox.TabStop = false;
            // 
            // additionalInfoGroupBox
            // 
            this.additionalInfoGroupBox.Controls.Add(this.additionalInfoRichTextBox);
            this.additionalInfoGroupBox.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additionalInfoGroupBox.Location = new System.Drawing.Point(14, 393);
            this.additionalInfoGroupBox.Name = "additionalInfoGroupBox";
            this.additionalInfoGroupBox.Size = new System.Drawing.Size(471, 108);
            this.additionalInfoGroupBox.TabIndex = 2;
            this.additionalInfoGroupBox.TabStop = false;
            this.additionalInfoGroupBox.Text = "Дополнительная информация";
            // 
            // additionalInfoRichTextBox
            // 
            this.additionalInfoRichTextBox.Location = new System.Drawing.Point(7, 20);
            this.additionalInfoRichTextBox.Name = "additionalInfoRichTextBox";
            this.additionalInfoRichTextBox.Size = new System.Drawing.Size(457, 80);
            this.additionalInfoRichTextBox.TabIndex = 0;
            this.additionalInfoRichTextBox.Text = "";
            // 
            // AddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 537);
            this.Controls.Add(this.additionalInfoGroupBox);
            this.Controls.Add(this.avaterGroupBox);
            this.Controls.Add(this.aliveInfo);
            this.Controls.Add(this.mainInfoGroupBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.mainInfoLabel);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AddPerson";
            this.Text = "AddPerson";
            this.mainInfoGroupBox.ResumeLayout(false);
            this.mainInfoGroupBox.PerformLayout();
            this.aliveInfo.ResumeLayout(false);
            this.aliveInfo.PerformLayout();
            this.avaterGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.additionalInfoGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainInfoLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label patronymicLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.Label deathDataLabel;
        private System.Windows.Forms.Label birthPlaceLabel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox patronomicTextBox;
        private System.Windows.Forms.TextBox birthPlaceTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DateTimePicker birthdayDate;
        private System.Windows.Forms.DateTimePicker deathDate;
        private System.Windows.Forms.RadioButton manRadioButton;
        private System.Windows.Forms.RadioButton womanRadioButton;
        private System.Windows.Forms.RadioButton aliveRadioButton;
        private System.Windows.Forms.RadioButton deadRadioButton;
        private System.Windows.Forms.GroupBox mainInfoGroupBox;
        private System.Windows.Forms.GroupBox aliveInfo;
        private System.Windows.Forms.GroupBox avaterGroupBox;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.GroupBox additionalInfoGroupBox;
        private System.Windows.Forms.RichTextBox additionalInfoRichTextBox;
        private System.Windows.Forms.Label burialPlaceLabel;
        private System.Windows.Forms.Label contactsLabel;
        private System.Windows.Forms.TextBox burialPlaceTextBox;
        private System.Windows.Forms.TextBox maidenNameTextBox;
        private System.Windows.Forms.Label maidenNameLabel;
        private System.Windows.Forms.TextBox contactsTextBox;
        private System.Windows.Forms.Button addPhotoButton;


    }
}