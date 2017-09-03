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
            this.button1 = new System.Windows.Forms.Button();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.photo = new System.Windows.Forms.PictureBox();
            this.photoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.button1.Location = new System.Drawing.Point(213, 434);
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
            this.photoPanel.Location = new System.Drawing.Point(12, 12);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(482, 416);
            this.photoPanel.TabIndex = 2;
            // 
            // photo
            // 
            this.photo.Location = new System.Drawing.Point(4, 4);
            this.photo.MinimumSize = new System.Drawing.Size(475, 400);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(475, 406);
            this.photo.TabIndex = 0;
            this.photo.TabStop = false;
            // 
            // GetPhoto
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 460);
            this.Controls.Add(this.photoPanel);
            this.Controls.Add(this.button1);
            this.Name = "GetPhoto";
            this.Text = "getPhoto";
            this.Activated += new System.EventHandler(this.GetPhoto_Activated);
            this.photoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.PictureBox photo;
    }
}