namespace Family_Tree
{
    partial class MainPage
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExtraInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.treePanel = new System.Windows.Forms.Panel();
            this.addConneсtionStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьСвязьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отцаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.матьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.братаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сеструToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.партнераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новогоЧеловекаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отцаToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.матьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.братаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сеструToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.партнераToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.treeSettingsPanel = new System.Windows.Forms.Panel();
            this.buildButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.allGenerationsRadioButton = new System.Windows.Forms.RadioButton();
            this.limitToRadioButton = new System.Windows.Forms.RadioButton();
            this.generationsComboBox = new System.Windows.Forms.ComboBox();
            this.startPersonGroupBox = new System.Windows.Forms.GroupBox();
            this.startPersonComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ancestorsRadioButton = new System.Windows.Forms.RadioButton();
            this.descendantsRadioButton = new System.Windows.Forms.RadioButton();
            this.hourglassRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.addConneсtionStrip.SuspendLayout();
            this.treeSettingsPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.startPersonGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.базаToolStripMenuItem,
            this.деревоToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // базаToolStripMenuItem
            // 
            this.базаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.добавитьToolStripMenuItem});
            this.базаToolStripMenuItem.Name = "базаToolStripMenuItem";
            this.базаToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.базаToolStripMenuItem.Text = "База";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // деревоToolStripMenuItem
            // 
            this.деревоToolStripMenuItem.Name = "деревоToolStripMenuItem";
            this.деревоToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.деревоToolStripMenuItem.Text = "Дерево";
            this.деревоToolStripMenuItem.Click += new System.EventHandler(this.деревоToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnExtraInfo,
            this.DeleteColumn});
            this.dataGridView.Location = new System.Drawing.Point(16, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(775, 446);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Имя";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 200;
            // 
            // ColumnExtraInfo
            // 
            this.ColumnExtraInfo.HeaderText = "Доп. инфо";
            this.ColumnExtraInfo.Name = "ColumnExtraInfo";
            this.ColumnExtraInfo.Width = 200;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "";
            this.DeleteColumn.Image = global::Family_Tree.Properties.Resources.delete_min1;
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeleteColumn.Width = 23;
            // 
            // treePanel
            // 
            this.treePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePanel.AutoScroll = true;
            this.treePanel.Location = new System.Drawing.Point(16, 34);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(774, 445);
            this.treePanel.TabIndex = 2;
            this.treePanel.Visible = false;
            // 
            // addConneсtionStrip
            // 
            this.addConneсtionStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСвязьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.addConneсtionStrip.Name = "addConneсtionStrip";
            this.addConneсtionStrip.Size = new System.Drawing.Size(159, 70);
            // 
            // добавитьСвязьToolStripMenuItem
            // 
            this.добавитьСвязьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отцаToolStripMenuItem,
            this.новогоЧеловекаToolStripMenuItem});
            this.добавитьСвязьToolStripMenuItem.Name = "добавитьСвязьToolStripMenuItem";
            this.добавитьСвязьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.добавитьСвязьToolStripMenuItem.Text = "Добавить связь";
            // 
            // отцаToolStripMenuItem
            // 
            this.отцаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отцаToolStripMenuItem1,
            this.матьToolStripMenuItem,
            this.братаToolStripMenuItem,
            this.сеструToolStripMenuItem,
            this.партнераToolStripMenuItem});
            this.отцаToolStripMenuItem.Name = "отцаToolStripMenuItem";
            this.отцаToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.отцаToolStripMenuItem.Text = "Из базы";
            // 
            // отцаToolStripMenuItem1
            // 
            this.отцаToolStripMenuItem1.Name = "отцаToolStripMenuItem1";
            this.отцаToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.отцаToolStripMenuItem1.Text = "Отца";
            this.отцаToolStripMenuItem1.Click += new System.EventHandler(this.отцаToolStripMenuItem1_Click);
            // 
            // матьToolStripMenuItem
            // 
            this.матьToolStripMenuItem.Name = "матьToolStripMenuItem";
            this.матьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.матьToolStripMenuItem.Text = "Мать";
            this.матьToolStripMenuItem.Click += new System.EventHandler(this.матьToolStripMenuItem_Click);
            // 
            // братаToolStripMenuItem
            // 
            this.братаToolStripMenuItem.Name = "братаToolStripMenuItem";
            this.братаToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.братаToolStripMenuItem.Text = "Брата";
            // 
            // сеструToolStripMenuItem
            // 
            this.сеструToolStripMenuItem.Name = "сеструToolStripMenuItem";
            this.сеструToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.сеструToolStripMenuItem.Text = "Сестру";
            // 
            // партнераToolStripMenuItem
            // 
            this.партнераToolStripMenuItem.Name = "партнераToolStripMenuItem";
            this.партнераToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.партнераToolStripMenuItem.Text = "Партнера";
            // 
            // новогоЧеловекаToolStripMenuItem
            // 
            this.новогоЧеловекаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отцаToolStripMenuItem2,
            this.матьToolStripMenuItem1,
            this.братаToolStripMenuItem1,
            this.сеструToolStripMenuItem1,
            this.партнераToolStripMenuItem1});
            this.новогоЧеловекаToolStripMenuItem.Name = "новогоЧеловекаToolStripMenuItem";
            this.новогоЧеловекаToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.новогоЧеловекаToolStripMenuItem.Text = "Нового человека";
            // 
            // отцаToolStripMenuItem2
            // 
            this.отцаToolStripMenuItem2.Name = "отцаToolStripMenuItem2";
            this.отцаToolStripMenuItem2.Size = new System.Drawing.Size(127, 22);
            this.отцаToolStripMenuItem2.Text = "Отца";
            this.отцаToolStripMenuItem2.Click += new System.EventHandler(this.отцаToolStripMenuItem2_Click);
            // 
            // матьToolStripMenuItem1
            // 
            this.матьToolStripMenuItem1.Name = "матьToolStripMenuItem1";
            this.матьToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.матьToolStripMenuItem1.Text = "Мать";
            this.матьToolStripMenuItem1.Click += new System.EventHandler(this.матьToolStripMenuItem1_Click);
            // 
            // братаToolStripMenuItem1
            // 
            this.братаToolStripMenuItem1.Name = "братаToolStripMenuItem1";
            this.братаToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.братаToolStripMenuItem1.Text = "Брата";
            // 
            // сеструToolStripMenuItem1
            // 
            this.сеструToolStripMenuItem1.Name = "сеструToolStripMenuItem1";
            this.сеструToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.сеструToolStripMenuItem1.Text = "Сестру";
            // 
            // партнераToolStripMenuItem1
            // 
            this.партнераToolStripMenuItem1.Name = "партнераToolStripMenuItem1";
            this.партнераToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.партнераToolStripMenuItem1.Text = "Партнера";
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Family_Tree.Properties.Resources.delete_min1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 23;
            // 
            // treeSettingsPanel
            // 
            this.treeSettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSettingsPanel.Controls.Add(this.buildButton);
            this.treeSettingsPanel.Controls.Add(this.groupBox3);
            this.treeSettingsPanel.Controls.Add(this.startPersonGroupBox);
            this.treeSettingsPanel.Controls.Add(this.groupBox1);
            this.treeSettingsPanel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.treeSettingsPanel.Location = new System.Drawing.Point(16, 33);
            this.treeSettingsPanel.Name = "treeSettingsPanel";
            this.treeSettingsPanel.Size = new System.Drawing.Size(269, 392);
            this.treeSettingsPanel.TabIndex = 3;
            this.treeSettingsPanel.Visible = false;
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(83, 271);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(92, 23);
            this.buildButton.TabIndex = 13;
            this.buildButton.Text = "Построить";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.allGenerationsRadioButton);
            this.groupBox3.Controls.Add(this.limitToRadioButton);
            this.groupBox3.Controls.Add(this.generationsComboBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 81);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Количество поколений";
            // 
            // allGenerationsRadioButton
            // 
            this.allGenerationsRadioButton.AutoSize = true;
            this.allGenerationsRadioButton.Checked = true;
            this.allGenerationsRadioButton.Location = new System.Drawing.Point(34, 21);
            this.allGenerationsRadioButton.Name = "allGenerationsRadioButton";
            this.allGenerationsRadioButton.Size = new System.Drawing.Size(123, 20);
            this.allGenerationsRadioButton.TabIndex = 7;
            this.allGenerationsRadioButton.TabStop = true;
            this.allGenerationsRadioButton.Text = "Все поколения";
            this.allGenerationsRadioButton.UseVisualStyleBackColor = true;
            // 
            // limitToRadioButton
            // 
            this.limitToRadioButton.AutoSize = true;
            this.limitToRadioButton.Location = new System.Drawing.Point(34, 47);
            this.limitToRadioButton.Name = "limitToRadioButton";
            this.limitToRadioButton.Size = new System.Drawing.Size(123, 20);
            this.limitToRadioButton.TabIndex = 8;
            this.limitToRadioButton.Text = "Ограничить до";
            this.limitToRadioButton.UseVisualStyleBackColor = true;
            this.limitToRadioButton.CheckedChanged += new System.EventHandler(this.limitToRadioButton_CheckedChanged);
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
            this.generationsComboBox.Location = new System.Drawing.Point(163, 43);
            this.generationsComboBox.Name = "generationsComboBox";
            this.generationsComboBox.Size = new System.Drawing.Size(53, 24);
            this.generationsComboBox.TabIndex = 9;
            this.generationsComboBox.Visible = false;
            // 
            // startPersonGroupBox
            // 
            this.startPersonGroupBox.Controls.Add(this.startPersonComboBox);
            this.startPersonGroupBox.Location = new System.Drawing.Point(3, 119);
            this.startPersonGroupBox.Name = "startPersonGroupBox";
            this.startPersonGroupBox.Size = new System.Drawing.Size(260, 59);
            this.startPersonGroupBox.TabIndex = 11;
            this.startPersonGroupBox.TabStop = false;
            this.startPersonGroupBox.Text = "Исходное лицо";
            // 
            // startPersonComboBox
            // 
            this.startPersonComboBox.DropDownHeight = 200;
            this.startPersonComboBox.DropDownWidth = 248;
            this.startPersonComboBox.FormattingEnabled = true;
            this.startPersonComboBox.IntegralHeight = false;
            this.startPersonComboBox.Location = new System.Drawing.Point(6, 21);
            this.startPersonComboBox.Name = "startPersonComboBox";
            this.startPersonComboBox.Size = new System.Drawing.Size(248, 24);
            this.startPersonComboBox.Sorted = true;
            this.startPersonComboBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ancestorsRadioButton);
            this.groupBox1.Controls.Add(this.descendantsRadioButton);
            this.groupBox1.Controls.Add(this.hourglassRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 109);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип дерева";
            // 
            // ancestorsRadioButton
            // 
            this.ancestorsRadioButton.AutoSize = true;
            this.ancestorsRadioButton.Checked = true;
            this.ancestorsRadioButton.Location = new System.Drawing.Point(34, 21);
            this.ancestorsRadioButton.Name = "ancestorsRadioButton";
            this.ancestorsRadioButton.Size = new System.Drawing.Size(75, 20);
            this.ancestorsRadioButton.TabIndex = 1;
            this.ancestorsRadioButton.TabStop = true;
            this.ancestorsRadioButton.Text = "Предки";
            this.ancestorsRadioButton.UseVisualStyleBackColor = true;
            // 
            // descendantsRadioButton
            // 
            this.descendantsRadioButton.AutoSize = true;
            this.descendantsRadioButton.Location = new System.Drawing.Point(34, 47);
            this.descendantsRadioButton.Name = "descendantsRadioButton";
            this.descendantsRadioButton.Size = new System.Drawing.Size(86, 20);
            this.descendantsRadioButton.TabIndex = 2;
            this.descendantsRadioButton.Text = "Потомки";
            this.descendantsRadioButton.UseVisualStyleBackColor = true;
            // 
            // hourglassRadioButton
            // 
            this.hourglassRadioButton.AutoSize = true;
            this.hourglassRadioButton.Location = new System.Drawing.Point(34, 73);
            this.hourglassRadioButton.Name = "hourglassRadioButton";
            this.hourglassRadioButton.Size = new System.Drawing.Size(126, 20);
            this.hourglassRadioButton.TabIndex = 3;
            this.hourglassRadioButton.Text = "Песочные часы";
            this.hourglassRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 494);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeSettingsPanel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.treePanel);
            this.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.addConneсtionStrip.ResumeLayout(false);
            this.treeSettingsPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.startPersonGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деревоToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.ContextMenuStrip addConneсtionStrip;
        private System.Windows.Forms.ToolStripMenuItem добавитьСвязьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отцаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отцаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem матьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem братаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сеструToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem партнераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новогоЧеловекаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отцаToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem матьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem братаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сеструToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem партнераToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Panel treeSettingsPanel;
        private System.Windows.Forms.ComboBox generationsComboBox;
        private System.Windows.Forms.RadioButton limitToRadioButton;
        private System.Windows.Forms.RadioButton allGenerationsRadioButton;
        private System.Windows.Forms.RadioButton hourglassRadioButton;
        private System.Windows.Forms.RadioButton descendantsRadioButton;
        private System.Windows.Forms.RadioButton ancestorsRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtraInfo;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColumn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox startPersonGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.ComboBox startPersonComboBox;

    }
}

