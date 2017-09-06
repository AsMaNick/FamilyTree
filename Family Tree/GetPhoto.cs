using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Family_Tree
{
    public partial class GetPhoto : Form
    {
        private const double pw = 1.2;
        public Image Result;
        private int lastX, lastY;
        TransparentPictureBox choosenRegion;

        public GetPhoto()
        {
            InitializeComponent();
        }

        public static Image drawBorder(int h, int w)
        {
            Bitmap bitmap = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                //g.FillRectangle(Brushes.Gray, 0, 0, w, h);
                g.DrawRectangle(new Pen(Brushes.White, 5), 0, 0, w - 1, h - 1);
                //Font font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
            return bitmap;
        }

        public GetPhoto(string s)
        {
            InitializeComponent();
            lastX = lastY = -1;
            int h = this.photo.Height;
            int w = this.photo.Width;
            //this.photo.Image = (Image) (new Bitmap(Image.FromFile(s), new Size(w, h)));
            this.photo.Image = (Image)(new Bitmap(Image.FromFile(s)));
            Result = (Image)(new Bitmap(Image.FromFile(s)));
            if (Result.Height > photo.Height)
            {
                double k = 1.0 * Result.Height / photo.Height;
                Size nsz = new Size(Convert.ToInt32(this.photo.Image.Width / k), Convert.ToInt32(this.photo.Image.Height / k));
                this.photo.Image = (Image)(new Bitmap(this.photo.Image, nsz));
            }
            /*while (this.photo.Image.Height > 1000 || this.photo.Image.Width > 1000)
            {
                Size nsz = new Size(this.photo.Image.Width / 2, this.photo.Image.Height / 2);
                this.photo.Image = (Image)(new Bitmap(this.photo.Image, nsz));
            }*/
            this.photo.Size = this.photo.Image.Size;
            this.MaximumSize = new Size(this.photo.Width + 70, this.photo.Height + 125);
            this.choosenRegion = new TransparentPictureBox(Color.FromArgb(50, 0, 0, 0));
            this.choosenRegion.MouseDown += choosenRegion_MouseDown;
            this.choosenRegion.MouseUp += choosenRegion_MouseUp;
            this.choosenRegion.MouseMove += choosenRegion_MouseMove;
            this.choosenRegion.MouseDoubleClick += choosenRegion_MouseDoubleClick;
            this.choosenRegion.MouseClick += choosenRegion_MouseClick;
            this.choosenRegion.Size = new Size(AddPerson.widthAvatar, AddPerson.heightAvatar);
            this.choosenRegion.Image = drawBorder(this.choosenRegion.Height, this.choosenRegion.Width);
            this.photo.Controls.Add(this.choosenRegion);
        }

        public Image Crop(Image image, Rectangle selection)
        {
            Bitmap bmp = image as Bitmap;
            selection.Width = Math.Min(selection.Width, image.Width - selection.Left);
            selection.Height = Math.Min(selection.Height, image.Height - selection.Top);
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);
            image.Dispose();
            return cropBmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int left = choosenRegion.Left;
            int width = choosenRegion.Width;
            int top = choosenRegion.Top;
            int height = choosenRegion.Height;
            AddPhoto.updateCoordinates(ref left, this.photo.Width, this.Result.Width);
            AddPhoto.updateCoordinates(ref width, this.photo.Width, this.Result.Width);
            AddPhoto.updateCoordinates(ref top, this.photo.Height, this.Result.Height);
            AddPhoto.updateCoordinates(ref height, this.photo.Height, this.Result.Height);
            Result = Crop(this.Result, new Rectangle(left, top, width, height));
            Result = (Image)(new Bitmap(Result, AddPerson.widthAvatar, AddPerson.heightAvatar));
            this.DialogResult = DialogResult.OK;
        }

        private bool isIn(int pX, int pY, int w = 0, int h = 0)
        {
            return this.choosenRegion.Left + pX >= -w && this.choosenRegion.Top + pY >= -h &&
                   this.choosenRegion.Left + pX + this.choosenRegion.Width < this.photo.Image.Width + w &&
                   this.choosenRegion.Top + pY + this.choosenRegion.Height < this.photo.Image.Height + h;
        }

        private int inRange(int x, int l, int r)
        {
            x = Math.Min(x, r);
            x = Math.Max(x, l);
            return x;
        }

        private void choosenRegion_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isIn(e.X - lastX, e.Y - lastY))
            {
                //lastX = -1;
                //lastY = -1;
                //return;
            }

            if (lastX != -1)
            {
                this.choosenRegion.Left += e.X - lastX;
                this.choosenRegion.Top += e.Y - lastY;
                int nLeft = inRange(this.choosenRegion.Left, 0, this.photo.Width - this.choosenRegion.Width);
                int nTop = inRange(this.choosenRegion.Top, 0, this.photo.Height - this.choosenRegion.Height);
                lastX -= nLeft - this.choosenRegion.Left;
                lastY -= nTop - this.choosenRegion.Top;
                this.choosenRegion.Left = nLeft;
                this.choosenRegion.Top = nTop;
                return;
            }
            return;
        }

        private void choosenRegion_MouseUp(object sender, MouseEventArgs e)
        {
            lastX = -1;
            lastY = -1;
        }

        private void changeSize(double pw)
        {
            int w = Convert.ToInt32(this.choosenRegion.Width * pw);
            int h = Convert.ToInt32(this.choosenRegion.Height * pw);
            if (w >= 20)
            {
                this.choosenRegion.Size = new Size(w, h);
                this.choosenRegion.Image = drawBorder(this.choosenRegion.Height, this.choosenRegion.Width);
            }
            if (!isIn(0, 0))
            {
                w = Convert.ToInt32(this.choosenRegion.Width / pw);
                h = Convert.ToInt32(this.choosenRegion.Height / pw);
                this.choosenRegion.Size = new Size(w, h);
                this.choosenRegion.Image = drawBorder(this.choosenRegion.Height, this.choosenRegion.Width);
            }
        }

        private void choosenRegion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                changeSize(pw);
            }
        }

        private void choosenRegion_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                changeSize(1 / pw);
            }
        }

        private void choosenRegion_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                lastX = me.X;
                lastY = me.Y;
            }
        }

        private void GetPhoto_Activated(object sender, EventArgs e)
        {
            this.photoPanel.Focus();
        }
    }
}
