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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьДеревоВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExtraInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.treeGroupBox = new System.Windows.Forms.GroupBox();
            this.treePanel = new System.Windows.Forms.Panel();
            this.addConneсtionStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьСвязьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отцаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.матьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сынаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дочьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.братаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сеструToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.партнераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новогоЧеловекаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отцаToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.матьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сынаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.дочьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.братаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сеструToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.партнераToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.treeSettingsPanel = new System.Windows.Forms.Panel();
            this.buildButton = new System.Windows.Forms.Button();
            this.numberOfGenerationsGroupBox = new System.Windows.Forms.GroupBox();
            this.allGenerationsRadioButton = new System.Windows.Forms.RadioButton();
            this.limitToRadioButton = new System.Windows.Forms.RadioButton();
            this.generationsComboBox = new System.Windows.Forms.ComboBox();
            this.startPersonGroupBox = new System.Windows.Forms.GroupBox();
            this.startPersonComboBox = new System.Windows.Forms.ComboBox();
            this.typeOfTreeGroupBox = new System.Windows.Forms.GroupBox();
            this.ancestorsRadioButton = new System.Windows.Forms.RadioButton();
            this.descendantsRadioButton = new System.Windows.Forms.RadioButton();
            this.hourglassRadioButton = new System.Windows.Forms.RadioButton();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.treeGroupBox.SuspendLayout();
            this.addConneсtionStrip.SuspendLayout();
            this.treeSettingsPanel.SuspendLayout();
            this.numberOfGenerationsGroupBox.SuspendLayout();
            this.startPersonGroupBox.SuspendLayout();
            this.typeOfTreeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.базаToolStripMenuItem,
            this.деревоToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(659, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.сохранитьДеревоВФайлToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьДеревоВФайлToolStripMenuItem
            // 
            this.сохранитьДеревоВФайлToolStripMenuItem.Name = "сохранитьДеревоВФайлToolStripMenuItem";
            this.сохранитьДеревоВФайлToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.сохранитьДеревоВФайлToolStripMenuItem.Text = "Сохранить дерево в файл";
            this.сохранитьДеревоВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьДеревоВФайлToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
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
            this.dataGridView.Location = new System.Drawing.Point(14, 29);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(483, 342);
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
            // treeGroupBox
            // 
            this.treeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGroupBox.Controls.Add(this.treePanel);
            this.treeGroupBox.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeGroupBox.Location = new System.Drawing.Point(14, 30);
            this.treeGroupBox.Name = "treeGroupBox";
            this.treeGroupBox.Size = new System.Drawing.Size(631, 369);
            this.treeGroupBox.TabIndex = 2;
            this.treeGroupBox.TabStop = false;
            this.treeGroupBox.Visible = false;
            // 
            // treePanel
            // 
            this.treePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePanel.AutoScroll = true;
            this.treePanel.Location = new System.Drawing.Point(9, 28);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(616, 335);
            this.treePanel.TabIndex = 0;
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
            this.сынаToolStripMenuItem,
            this.дочьToolStripMenuItem,
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
            // сынаToolStripMenuItem
            // 
            this.сынаToolStripMenuItem.Name = "сынаToolStripMenuItem";
            this.сынаToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.сынаToolStripMenuItem.Text = "Сына";
            this.сынаToolStripMenuItem.Click += new System.EventHandler(this.сынаToolStripMenuItem_Click);
            // 
            // дочьToolStripMenuItem
            // 
            this.дочьToolStripMenuItem.Name = "дочьToolStripMenuItem";
            this.дочьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.дочьToolStripMenuItem.Text = "Дочь";
            this.дочьToolStripMenuItem.Click += new System.EventHandler(this.дочьToolStripMenuItem_Click);
            // 
            // братаToolStripMenuItem
            // 
            this.братаToolStripMenuItem.Name = "братаToolStripMenuItem";
            this.братаToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.братаToolStripMenuItem.Text = "Брата";
            this.братаToolStripMenuItem.Click += new System.EventHandler(this.братаToolStripMenuItem_Click);
            // 
            // сеструToolStripMenuItem
            // 
            this.сеструToolStripMenuItem.Name = "сеструToolStripMenuItem";
            this.сеструToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.сеструToolStripMenuItem.Text = "Сестру";
            this.сеструToolStripMenuItem.Click += new System.EventHandler(this.сеструToolStripMenuItem_Click);
            // 
            // партнераToolStripMenuItem
            // 
            this.партнераToolStripMenuItem.Name = "партнераToolStripMenuItem";
            this.партнераToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.партнераToolStripMenuItem.Text = "Партнера";
            this.партнераToolStripMenuItem.Click += new System.EventHandler(this.партнераToolStripMenuItem_Click);
            // 
            // новогоЧеловекаToolStripMenuItem
            // 
            this.новогоЧеловекаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отцаToolStripMenuItem2,
            this.матьToolStripMenuItem1,
            this.сынаToolStripMenuItem1,
            this.дочьToolStripMenuItem1,
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
            // сынаToolStripMenuItem1
            // 
            this.сынаToolStripMenuItem1.Name = "сынаToolStripMenuItem1";
            this.сынаToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.сынаToolStripMenuItem1.Text = "Сына";
            this.сынаToolStripMenuItem1.Click += new System.EventHandler(this.сынаToolStripMenuItem1_Click);
            // 
            // дочьToolStripMenuItem1
            // 
            this.дочьToolStripMenuItem1.Name = "дочьToolStripMenuItem1";
            this.дочьToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.дочьToolStripMenuItem1.Text = "Дочь";
            this.дочьToolStripMenuItem1.Click += new System.EventHandler(this.дочьToolStripMenuItem1_Click);
            // 
            // братаToolStripMenuItem1
            // 
            this.братаToolStripMenuItem1.Name = "братаToolStripMenuItem1";
            this.братаToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.братаToolStripMenuItem1.Text = "Брата";
            this.братаToolStripMenuItem1.Click += new System.EventHandler(this.братаToolStripMenuItem1_Click);
            // 
            // сеструToolStripMenuItem1
            // 
            this.сеструToolStripMenuItem1.Name = "сеструToolStripMenuItem1";
            this.сеструToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.сеструToolStripMenuItem1.Text = "Сестру";
            this.сеструToolStripMenuItem1.Click += new System.EventHandler(this.сеструToolStripMenuItem1_Click);
            // 
            // партнераToolStripMenuItem1
            // 
            this.партнераToolStripMenuItem1.Name = "партнераToolStripMenuItem1";
            this.партнераToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.партнераToolStripMenuItem1.Text = "Партнера";
            this.партнераToolStripMenuItem1.Click += new System.EventHandler(this.партнераToolStripMenuItem1_Click);
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
            this.treeSettingsPanel.Controls.Add(this.buildButton);
            this.treeSettingsPanel.Controls.Add(this.numberOfGenerationsGroupBox);
            this.treeSettingsPanel.Controls.Add(this.startPersonGroupBox);
            this.treeSettingsPanel.Controls.Add(this.typeOfTreeGroupBox);
            this.treeSettingsPanel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.treeSettingsPanel.Location = new System.Drawing.Point(14, 29);
            this.treeSettingsPanel.Name = "treeSettingsPanel";
            this.treeSettingsPanel.Size = new System.Drawing.Size(255, 343);
            this.treeSettingsPanel.TabIndex = 3;
            this.treeSettingsPanel.Visible = false;
            // 
            // buildButton
            // 
            this.buildButton.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.buildButton.Location = new System.Drawing.Point(73, 237);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(80, 21);
            this.buildButton.TabIndex = 13;
            this.buildButton.Text = "Построить";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // numberOfGenerationsGroupBox
            // 
            this.numberOfGenerationsGroupBox.Controls.Add(this.allGenerationsRadioButton);
            this.numberOfGenerationsGroupBox.Controls.Add(this.limitToRadioButton);
            this.numberOfGenerationsGroupBox.Controls.Add(this.generationsComboBox);
            this.numberOfGenerationsGroupBox.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.numberOfGenerationsGroupBox.Location = new System.Drawing.Point(3, 161);
            this.numberOfGenerationsGroupBox.Name = "numberOfGenerationsGroupBox";
            this.numberOfGenerationsGroupBox.Size = new System.Drawing.Size(249, 71);
            this.numberOfGenerationsGroupBox.TabIndex = 12;
            this.numberOfGenerationsGroupBox.TabStop = false;
            this.numberOfGenerationsGroupBox.Text = "Количество поколений";
            // 
            // allGenerationsRadioButton
            // 
            this.allGenerationsRadioButton.AutoSize = true;
            this.allGenerationsRadioButton.Checked = true;
            this.allGenerationsRadioButton.Location = new System.Drawing.Point(30, 18);
            this.allGenerationsRadioButton.Name = "allGenerationsRadioButton";
            this.allGenerationsRadioButton.Size = new System.Drawing.Size(111, 18);
            this.allGenerationsRadioButton.TabIndex = 7;
            this.allGenerationsRadioButton.TabStop = true;
            this.allGenerationsRadioButton.Text = "Все поколения";
            this.allGenerationsRadioButton.UseVisualStyleBackColor = true;
            // 
            // limitToRadioButton
            // 
            this.limitToRadioButton.AutoSize = true;
            this.limitToRadioButton.Location = new System.Drawing.Point(30, 41);
            this.limitToRadioButton.Name = "limitToRadioButton";
            this.limitToRadioButton.Size = new System.Drawing.Size(114, 18);
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
            this.generationsComboBox.Location = new System.Drawing.Point(143, 38);
            this.generationsComboBox.Name = "generationsComboBox";
            this.generationsComboBox.Size = new System.Drawing.Size(47, 22);
            this.generationsComboBox.TabIndex = 9;
            this.generationsComboBox.Visible = false;
            // 
            // startPersonGroupBox
            // 
            this.startPersonGroupBox.Controls.Add(this.startPersonComboBox);
            this.startPersonGroupBox.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.startPersonGroupBox.Location = new System.Drawing.Point(3, 104);
            this.startPersonGroupBox.Name = "startPersonGroupBox";
            this.startPersonGroupBox.Size = new System.Drawing.Size(249, 52);
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
            this.startPersonComboBox.Location = new System.Drawing.Point(5, 18);
            this.startPersonComboBox.Name = "startPersonComboBox";
            this.startPersonComboBox.Size = new System.Drawing.Size(238, 22);
            this.startPersonComboBox.Sorted = true;
            this.startPersonComboBox.TabIndex = 5;
            // 
            // typeOfTreeGroupBox
            // 
            this.typeOfTreeGroupBox.Controls.Add(this.ancestorsRadioButton);
            this.typeOfTreeGroupBox.Controls.Add(this.descendantsRadioButton);
            this.typeOfTreeGroupBox.Controls.Add(this.hourglassRadioButton);
            this.typeOfTreeGroupBox.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.typeOfTreeGroupBox.Location = new System.Drawing.Point(3, 4);
            this.typeOfTreeGroupBox.Name = "typeOfTreeGroupBox";
            this.typeOfTreeGroupBox.Size = new System.Drawing.Size(249, 95);
            this.typeOfTreeGroupBox.TabIndex = 10;
            this.typeOfTreeGroupBox.TabStop = false;
            this.typeOfTreeGroupBox.Text = "Тип дерева";
            // 
            // ancestorsRadioButton
            // 
            this.ancestorsRadioButton.AutoSize = true;
            this.ancestorsRadioButton.Checked = true;
            this.ancestorsRadioButton.Location = new System.Drawing.Point(30, 18);
            this.ancestorsRadioButton.Name = "ancestorsRadioButton";
            this.ancestorsRadioButton.Size = new System.Drawing.Size(70, 18);
            this.ancestorsRadioButton.TabIndex = 1;
            this.ancestorsRadioButton.TabStop = true;
            this.ancestorsRadioButton.Text = "Предки";
            this.ancestorsRadioButton.UseVisualStyleBackColor = true;
            // 
            // descendantsRadioButton
            // 
            this.descendantsRadioButton.AutoSize = true;
            this.descendantsRadioButton.Location = new System.Drawing.Point(30, 41);
            this.descendantsRadioButton.Name = "descendantsRadioButton";
            this.descendantsRadioButton.Size = new System.Drawing.Size(78, 18);
            this.descendantsRadioButton.TabIndex = 2;
            this.descendantsRadioButton.Text = "Потомки";
            this.descendantsRadioButton.UseVisualStyleBackColor = true;
            // 
            // hourglassRadioButton
            // 
            this.hourglassRadioButton.AutoSize = true;
            this.hourglassRadioButton.Enabled = false;
            this.hourglassRadioButton.Location = new System.Drawing.Point(30, 64);
            this.hourglassRadioButton.Name = "hourglassRadioButton";
            this.hourglassRadioButton.Size = new System.Drawing.Size(117, 18);
            this.hourglassRadioButton.TabIndex = 3;
            this.hourglassRadioButton.Text = "Песочные часы";
            this.hourglassRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 412);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.treeSettingsPanel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.treeGroupBox);
            this.Font = new System.Drawing.Font("Georgia", 8.25F);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(550, 430);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.treeGroupBox.ResumeLayout(false);
            this.addConneсtionStrip.ResumeLayout(false);
            this.treeSettingsPanel.ResumeLayout(false);
            this.numberOfGenerationsGroupBox.ResumeLayout(false);
            this.numberOfGenerationsGroupBox.PerformLayout();
            this.startPersonGroupBox.ResumeLayout(false);
            this.typeOfTreeGroupBox.ResumeLayout(false);
            this.typeOfTreeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деревоToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.GroupBox treeGroupBox;
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
        private System.Windows.Forms.GroupBox numberOfGenerationsGroupBox;
        private System.Windows.Forms.GroupBox startPersonGroupBox;
        private System.Windows.Forms.GroupBox typeOfTreeGroupBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.ComboBox startPersonComboBox;
        private System.Windows.Forms.ToolStripMenuItem сынаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дочьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сынаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дочьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.ToolStripMenuItem сохранитьДеревоВФайлToolStripMenuItem;

    }
}

