namespace Family_Tree
{
    partial class GetPhoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetPhoto));
            this.button1 = new System.Windows.Forms.Button();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.photo = new System.Windows.Forms.PictureBox();
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.photoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.button1.Location = new System.Drawing.Point(202, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.photoPanel.Size = new System.Drawing.Size(447, 457);
            this.photoPanel.TabIndex = 2;
            // 
            // photo
            // 
            this.photo.Location = new System.Drawing.Point(4, 4);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(438, 450);
            this.photo.TabIndex = 0;
            this.photo.TabStop = false;
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoGroupBox.Controls.Add(this.photoPanel);
            this.photoGroupBox.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.photoGroupBox.Location = new System.Drawing.Point(13, 13);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Size = new System.Drawing.Size(459, 492);
            this.photoGroupBox.TabIndex = 3;
            this.photoGroupBox.TabStop = false;
            // 
            // GetPhoto
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 537);
            this.Controls.Add(this.photoGroupBox);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetPhoto";
            this.Text = "Выбор фотографии";
            this.Activated += new System.EventHandler(this.GetPhoto_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetPhoto_FormClosing);
            this.photoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.photoGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.PictureBox photo;
    }
}