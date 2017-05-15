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
            this.MainInfoLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PatronymicLabel = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.DeathDataLabel = new System.Windows.Forms.Label();
            this.PlaceLabel = new System.Windows.Forms.Label();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PatronomicTextBox = new System.Windows.Forms.TextBox();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.BirthdayDate = new System.Windows.Forms.DateTimePicker();
            this.DeathDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // MainInfoLabel
            // 
            this.MainInfoLabel.AutoSize = true;
            this.MainInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainInfoLabel.Location = new System.Drawing.Point(38, 9);
            this.MainInfoLabel.Name = "MainInfoLabel";
            this.MainInfoLabel.Size = new System.Drawing.Size(220, 17);
            this.MainInfoLabel.TabIndex = 0;
            this.MainInfoLabel.Text = "Введите основную информацию";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SurnameLabel.Location = new System.Drawing.Point(12, 44);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(74, 17);
            this.SurnameLabel.TabIndex = 1;
            this.SurnameLabel.Text = "Фамилия:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(12, 71);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(39, 17);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Имя:";
            // 
            // PatronymicLabel
            // 
            this.PatronymicLabel.AutoSize = true;
            this.PatronymicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PatronymicLabel.Location = new System.Drawing.Point(11, 98);
            this.PatronymicLabel.Name = "PatronymicLabel";
            this.PatronymicLabel.Size = new System.Drawing.Size(75, 17);
            this.PatronymicLabel.TabIndex = 3;
            this.PatronymicLabel.Text = "Отчество:";
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.AutoSize = true;
            this.BirthdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BirthdayLabel.Location = new System.Drawing.Point(11, 125);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.Size = new System.Drawing.Size(115, 17);
            this.BirthdayLabel.TabIndex = 4;
            this.BirthdayLabel.Text = "Дата рождения:";
            // 
            // DeathDataLabel
            // 
            this.DeathDataLabel.AutoSize = true;
            this.DeathDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeathDataLabel.Location = new System.Drawing.Point(12, 152);
            this.DeathDataLabel.Name = "DeathDataLabel";
            this.DeathDataLabel.Size = new System.Drawing.Size(97, 17);
            this.DeathDataLabel.TabIndex = 5;
            this.DeathDataLabel.Text = "Дата смерти:";
            // 
            // PlaceLabel
            // 
            this.PlaceLabel.AutoSize = true;
            this.PlaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlaceLabel.Location = new System.Drawing.Point(12, 179);
            this.PlaceLabel.Name = "PlaceLabel";
            this.PlaceLabel.Size = new System.Drawing.Size(122, 17);
            this.PlaceLabel.TabIndex = 6;
            this.PlaceLabel.Text = "Место рождения:";
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Location = new System.Drawing.Point(92, 43);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.SurnameTextBox.TabIndex = 7;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(57, 69);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 8;
            // 
            // PatronomicTextBox
            // 
            this.PatronomicTextBox.Location = new System.Drawing.Point(92, 95);
            this.PatronomicTextBox.Name = "PatronomicTextBox";
            this.PatronomicTextBox.Size = new System.Drawing.Size(100, 20);
            this.PatronomicTextBox.TabIndex = 9;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(140, 179);
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(100, 20);
            this.PlaceTextBox.TabIndex = 12;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(103, 218);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(89, 23);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // BirthdayDate
            // 
            this.BirthdayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BirthdayDate.Location = new System.Drawing.Point(132, 121);
            this.BirthdayDate.Name = "BirthdayDate";
            this.BirthdayDate.Size = new System.Drawing.Size(140, 23);
            this.BirthdayDate.TabIndex = 14;
            // 
            // DeathDate
            // 
            this.DeathDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeathDate.Location = new System.Drawing.Point(115, 150);
            this.DeathDate.Name = "DeathDate";
            this.DeathDate.Size = new System.Drawing.Size(143, 23);
            this.DeathDate.TabIndex = 15;
            // 
            // AddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.DeathDate);
            this.Controls.Add(this.BirthdayDate);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.PatronomicTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.PlaceLabel);
            this.Controls.Add(this.DeathDataLabel);
            this.Controls.Add(this.BirthdayLabel);
            this.Controls.Add(this.PatronymicLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.MainInfoLabel);
            this.Name = "AddPerson";
            this.Text = "AddPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainInfoLabel;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PatronymicLabel;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label DeathDataLabel;
        private System.Windows.Forms.Label PlaceLabel;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PatronomicTextBox;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DateTimePicker BirthdayDate;
        private System.Windows.Forms.DateTimePicker DeathDate;


    }
}