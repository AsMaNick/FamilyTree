namespace Family_Tree
{
    partial class treeSettings
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
            this.treeSettingsPanel = new System.Windows.Forms.Panel();
            this.generationsComboBox = new System.Windows.Forms.ComboBox();
            this.limitToRadioButton = new System.Windows.Forms.RadioButton();
            this.allGenerationsRadioButton = new System.Windows.Forms.RadioButton();
            this.numberOfGenerationsLabel = new System.Windows.Forms.Label();
            this.startPersonComboBox = new System.Windows.Forms.ComboBox();
            this.startPersonLabel = new System.Windows.Forms.Label();
            this.hourglassRadioButton = new System.Windows.Forms.RadioButton();
            this.descendantsRadioButton = new System.Windows.Forms.RadioButton();
            this.ancestorsRadioButton = new System.Windows.Forms.RadioButton();
            this.typeOfTreeLabel = new System.Windows.Forms.Label();
            this.treeSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeSettingsPanel
            // 
            this.treeSettingsPanel.Controls.Add(this.generationsComboBox);
            this.treeSettingsPanel.Controls.Add(this.limitToRadioButton);
            this.treeSettingsPanel.Controls.Add(this.allGenerationsRadioButton);
            this.treeSettingsPanel.Controls.Add(this.numberOfGenerationsLabel);
            this.treeSettingsPanel.Controls.Add(this.startPersonComboBox);
            this.treeSettingsPanel.Controls.Add(this.startPersonLabel);
            this.treeSettingsPanel.Controls.Add(this.hourglassRadioButton);
            this.treeSettingsPanel.Controls.Add(this.descendantsRadioButton);
            this.treeSettingsPanel.Controls.Add(this.ancestorsRadioButton);
            this.treeSettingsPanel.Controls.Add(this.typeOfTreeLabel);
            this.treeSettingsPanel.Location = new System.Drawing.Point(12, 12);
            this.treeSettingsPanel.Name = "treeSettingsPanel";
            this.treeSettingsPanel.Size = new System.Drawing.Size(495, 284);
            this.treeSettingsPanel.TabIndex = 1;
            // 
            // generationsComboBox
            // 
            this.generationsComboBox.FormattingEnabled = true;
            this.generationsComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.generationsComboBox.Location = new System.Drawing.Point(280, 158);
            this.generationsComboBox.Name = "generationsComboBox";
            this.generationsComboBox.Size = new System.Drawing.Size(47, 21);
            this.generationsComboBox.TabIndex = 9;
            // 
            // limitToRadioButton
            // 
            this.limitToRadioButton.AutoSize = true;
            this.limitToRadioButton.Location = new System.Drawing.Point(159, 162);
            this.limitToRadioButton.Name = "limitToRadioButton";
            this.limitToRadioButton.Size = new System.Drawing.Size(99, 17);
            this.limitToRadioButton.TabIndex = 8;
            this.limitToRadioButton.TabStop = true;
            this.limitToRadioButton.Text = "Ограничить до";
            this.limitToRadioButton.UseVisualStyleBackColor = true;
            // 
            // allGenerationsRadioButton
            // 
            this.allGenerationsRadioButton.AutoSize = true;
            this.allGenerationsRadioButton.Location = new System.Drawing.Point(159, 137);
            this.allGenerationsRadioButton.Name = "allGenerationsRadioButton";
            this.allGenerationsRadioButton.Size = new System.Drawing.Size(101, 17);
            this.allGenerationsRadioButton.TabIndex = 7;
            this.allGenerationsRadioButton.TabStop = true;
            this.allGenerationsRadioButton.Text = "Все поколения";
            this.allGenerationsRadioButton.UseVisualStyleBackColor = true;
            // 
            // numberOfGenerationsLabel
            // 
            this.numberOfGenerationsLabel.AutoSize = true;
            this.numberOfGenerationsLabel.Location = new System.Drawing.Point(4, 141);
            this.numberOfGenerationsLabel.Name = "numberOfGenerationsLabel";
            this.numberOfGenerationsLabel.Size = new System.Drawing.Size(126, 13);
            this.numberOfGenerationsLabel.TabIndex = 6;
            this.numberOfGenerationsLabel.Text = "Количество поколений:";
            // 
            // startPersonComboBox
            // 
            this.startPersonComboBox.FormattingEnabled = true;
            this.startPersonComboBox.Location = new System.Drawing.Point(4, 112);
            this.startPersonComboBox.Name = "startPersonComboBox";
            this.startPersonComboBox.Size = new System.Drawing.Size(121, 21);
            this.startPersonComboBox.TabIndex = 5;
            // 
            // startPersonLabel
            // 
            this.startPersonLabel.AutoSize = true;
            this.startPersonLabel.Location = new System.Drawing.Point(1, 94);
            this.startPersonLabel.Name = "startPersonLabel";
            this.startPersonLabel.Size = new System.Drawing.Size(86, 13);
            this.startPersonLabel.TabIndex = 4;
            this.startPersonLabel.Text = "Исходное лицо:";
            // 
            // hourglassRadioButton
            // 
            this.hourglassRadioButton.AutoSize = true;
            this.hourglassRadioButton.Location = new System.Drawing.Point(4, 73);
            this.hourglassRadioButton.Name = "hourglassRadioButton";
            this.hourglassRadioButton.Size = new System.Drawing.Size(104, 17);
            this.hourglassRadioButton.TabIndex = 3;
            this.hourglassRadioButton.TabStop = true;
            this.hourglassRadioButton.Text = "Песочные часы";
            this.hourglassRadioButton.UseVisualStyleBackColor = true;
            // 
            // descendantsRadioButton
            // 
            this.descendantsRadioButton.AutoSize = true;
            this.descendantsRadioButton.Location = new System.Drawing.Point(4, 48);
            this.descendantsRadioButton.Name = "descendantsRadioButton";
            this.descendantsRadioButton.Size = new System.Drawing.Size(70, 17);
            this.descendantsRadioButton.TabIndex = 2;
            this.descendantsRadioButton.TabStop = true;
            this.descendantsRadioButton.Text = "Потомки";
            this.descendantsRadioButton.UseVisualStyleBackColor = true;
            // 
            // ancestorsRadioButton
            // 
            this.ancestorsRadioButton.AutoSize = true;
            this.ancestorsRadioButton.Location = new System.Drawing.Point(4, 23);
            this.ancestorsRadioButton.Name = "ancestorsRadioButton";
            this.ancestorsRadioButton.Size = new System.Drawing.Size(63, 17);
            this.ancestorsRadioButton.TabIndex = 1;
            this.ancestorsRadioButton.TabStop = true;
            this.ancestorsRadioButton.Text = "Предки";
            this.ancestorsRadioButton.UseVisualStyleBackColor = true;
            // 
            // typeOfTreeLabel
            // 
            this.typeOfTreeLabel.AutoSize = true;
            this.typeOfTreeLabel.Location = new System.Drawing.Point(1, 6);
            this.typeOfTreeLabel.Name = "typeOfTreeLabel";
            this.typeOfTreeLabel.Size = new System.Drawing.Size(68, 13);
            this.typeOfTreeLabel.TabIndex = 0;
            this.typeOfTreeLabel.Text = "Тип дерева:";
            // 
            // treeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 308);
            this.Controls.Add(this.treeSettingsPanel);
            this.Name = "treeSettings";
            this.Text = "treeSettings";
            this.treeSettingsPanel.ResumeLayout(false);
            this.treeSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel treeSettingsPanel;
        private System.Windows.Forms.ComboBox generationsComboBox;
        private System.Windows.Forms.RadioButton limitToRadioButton;
        private System.Windows.Forms.RadioButton allGenerationsRadioButton;
        private System.Windows.Forms.Label numberOfGenerationsLabel;
        private System.Windows.Forms.ComboBox startPersonComboBox;
        private System.Windows.Forms.Label startPersonLabel;
        private System.Windows.Forms.RadioButton hourglassRadioButton;
        private System.Windows.Forms.RadioButton descendantsRadioButton;
        private System.Windows.Forms.RadioButton ancestorsRadioButton;
        private System.Windows.Forms.Label typeOfTreeLabel;

    }
}