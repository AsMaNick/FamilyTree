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
            this.построитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деревоПредковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExtraInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.addConneсtionStrip.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(706, 24);
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
            this.деревоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьToolStripMenuItem});
            this.деревоToolStripMenuItem.Name = "деревоToolStripMenuItem";
            this.деревоToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.деревоToolStripMenuItem.Text = "Дерево";
            // 
            // построитьToolStripMenuItem
            // 
            this.построитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.деревоПредковToolStripMenuItem});
            this.построитьToolStripMenuItem.Name = "построитьToolStripMenuItem";
            this.построитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.построитьToolStripMenuItem.Text = "Построить";
            // 
            // деревоПредковToolStripMenuItem
            // 
            this.деревоПредковToolStripMenuItem.Name = "деревоПредковToolStripMenuItem";
            this.деревоПредковToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.деревоПредковToolStripMenuItem.Text = "Дерево предков";
            this.деревоПредковToolStripMenuItem.Click += new System.EventHandler(this.деревоПредковToolStripMenuItem_Click);
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
            this.dataGridView.Size = new System.Drawing.Size(678, 390);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Имя";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnExtraInfo
            // 
            this.ColumnExtraInfo.HeaderText = "Доп. инфо";
            this.ColumnExtraInfo.Name = "ColumnExtraInfo";
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
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Family_Tree.Properties.Resources.delete_min1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 23;
            // 
            // treePanel
            // 
            this.treePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePanel.AutoScroll = true;
            this.treePanel.Location = new System.Drawing.Point(14, 30);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(678, 389);
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
            this.addConneсtionStrip.Size = new System.Drawing.Size(159, 92);
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
            this.матьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 432);
            this.Controls.Add(this.treePanel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.addConneсtionStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem построитьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtraInfo;
        private System.Windows.Forms.DataGridViewImageColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolStripMenuItem деревоПредковToolStripMenuItem;
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

    }
}

