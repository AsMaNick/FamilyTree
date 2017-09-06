using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Family_Tree
{
    public partial class AddPhoto : Form
    {
        const double stepScale = 1.2;
        public Photo result;
        public double scale;
        private int lastX, lastY;
        private Rectangle choosenRectangle;
        private TransparentPictureBox pb;
        private ComboBox newPersonComboBox;
        private DataBase data;
        List<Label> labeledPeople;
        private int lastLabeledPeopleCount = 0, szScroll = 0;
        private Label choosenLabel;

        public AddPhoto()
        {
            InitializeComponent();
        }

        public void InitializeForm()
        {
            newPersonComboBox = new ComboBox();
            newPersonComboBox.Visible = false;
            newPersonComboBox.Size = new Size(238, 22);
            newPersonComboBox.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            newPersonComboBox.KeyDown += newPersonComboBox_KeyDown;
            pb = new TransparentPictureBox(Color.FromArgb(50, 0, 0, 0));
            pb.Visible = false;
            this.photo.Controls.Add(pb);
            this.photo.Controls.Add(newPersonComboBox);
            labeledPeople = new List<Label>();
            lastX = -1;
            lastY = -1;
            updatePhoto();
        }

        public AddPhoto(string fileName, DataBase Data)
        {
            InitializeComponent();
            data = Data;
            result = new Photo();
            result.img = (Image)(new Bitmap(Image.FromFile(fileName)));
            scale = Math.Min(9.99, 500.0 / result.img.Height);
            InitializeForm();
        }

        public AddPhoto(Photo p, DataBase Data)
        {
            InitializeComponent();
            data = Data;
            result = p;
            additionalInfo.Text = p.additionalInfo;
            scale = Math.Min(9.99, 500.0 / result.img.Height);
            InitializeForm();
            updateInformation();
        }

        private void updatePhoto()
        {
            int w = Convert.ToInt32(scale * result.img.Width);
            int h = Convert.ToInt32(scale * result.img.Height);
            this.photo.Image = (Image) (new Bitmap(result.img, w, h));
            this.photo.Size = this.photo.Image.Size;
            this.scaleLabel.Text = Convert.ToString(Convert.ToInt32(scale * 100)) + "%";
        }

        private void AddPhoto_Activated(object sender, EventArgs e)
        {
            this.photoPanel.Focus();
        }

        private bool okS(double scale)
        {
            double s = this.result.img.Width * this.result.img.Height * scale * scale;
            return 5000 <= s && s <= 25000000 && scale < 10;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            if (okS(scale * stepScale))
            {
                scale *= stepScale;
                updatePhoto();
                updatePhotoPosition();
            }
            this.photoPanel.Focus();
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            if (okS(scale / stepScale))
            {
                scale /= stepScale;
                updatePhoto();
                updatePhotoPosition();
            }
            this.photoPanel.Focus();
        }

        private void photo_MouseDown(object sender, MouseEventArgs e)
        {
            if (!newPersonComboBox.Visible)
            {
                lastX = e.X;
                lastY = e.Y;
            }
        }

        public static void updateCoordinates(ref int x, int len, int okLen)
        {
            x = Math.Max(0, ((x + 1) * okLen) / len - 1);
        }

        private bool isIn(int x, int y, Rectangle r)
        {
            return r.Left <= x && r.Top <= y && x < r.Left + r.Width && y < r.Top + r.Height;
        }

        private void updateBold(int id)
        {
            for (int i = 0; i < result.peopleIds.Count; ++i)
            {
                if (i != id)
                {
                    labeledPeople[i].Font = new System.Drawing.Font("Georgia", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                else
                {
                    labeledPeople[id].Font = new System.Drawing.Font("Georgia", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))); ;
                }
            }
        }

        private void updateZone(int id)
        {
            if (id == -1)
            {
                pb.Visible = false;
                return;
            }
            int mnX = result.zones[id].Left;
            int mnY = result.zones[id].Top;
            int mxX = result.zones[id].Left + result.zones[id].Width - 1;
            int mxY = result.zones[id].Top + result.zones[id].Height - 1;
            updateCoordinates(ref mnX, this.result.img.Width, this.photo.Width);
            updateCoordinates(ref mxX, this.result.img.Width, this.photo.Width);
            updateCoordinates(ref mnY, this.result.img.Height, this.photo.Height);
            updateCoordinates(ref mxY, this.result.img.Height, this.photo.Height);
            pb.Left = mnX;
            pb.Top = mnY;
            pb.Size = new Size(mxX - mnX + 1, mxY - mnY + 1);
            pb.Image = GetPhoto.drawBorder(pb.Height, pb.Width);
            pb.Visible = true;
        }

        private void photo_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastX != -1)
            {
                pb.Visible = true;
                int mnX = Math.Min(lastX, e.X);
                int mnY = Math.Min(lastY, e.Y);
                int mxX = Math.Max(lastX, e.X);
                int mxY = Math.Max(lastY, e.Y);
                pb.Left = mnX;
                pb.Top = mnY;
                pb.Size = new Size(mxX - mnX + 1, mxY - mnY + 1);
                pb.Image = GetPhoto.drawBorder(pb.Height, pb.Width);
            }
            else
            {
                int x = e.X, y = e.Y, id = -1;
                updateCoordinates(ref x, this.photo.Width, result.img.Width);
                updateCoordinates(ref y, this.photo.Height, result.img.Height);
                for (int i = 0; i < result.peopleIds.Count; ++i)
                {
                    Rectangle r = result.zones[i];
                    if (isIn(x, y, r))
                    {
                        id = i;
                    }
                }
                updateBold(id);
            }
        }

        private void fillNewPersonComboBox()
        {
            newPersonComboBox.Items.Clear();
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                newPersonComboBox.Items.Add(data.allPeople[i].FullName);
            }
            newPersonComboBox.Text = "";
            newPersonComboBox.Visible = true;
        }

        private int yPosition(int num)
        {
            int st = 5;
            if (num == 0)
            {
                return st;
            }
            return (7 + labeledPeople[0].Height) * labeledPeople.Count + st;
        }

        private void photo_MouseUp(object sender, MouseEventArgs e)
        {
            if (lastX != -1)
            {
                int mnX = Math.Min(lastX, e.X);
                int mnY = Math.Min(lastY, e.Y);
                int mxX = Math.Max(lastX, e.X);
                int mxY = Math.Max(lastY, e.Y);
                if ((mxX - mnX + 1) * (mxY - mnY + 1) > 200 && mxX - mnX + 1 > 10 && mxY - mnY > 10)
                {
                    fillNewPersonComboBox();
                    newPersonComboBox.Left = mnX + (mxX - mnX + 1 - newPersonComboBox.Width) / 2;
                    newPersonComboBox.Top = mxY + 5;
                    updateCoordinates(ref mnX, this.photo.Width, this.result.img.Width);
                    updateCoordinates(ref mxX, this.photo.Width, this.result.img.Width);
                    updateCoordinates(ref mnY, this.photo.Height, this.result.img.Height);
                    updateCoordinates(ref mxY, this.photo.Height, this.result.img.Height);
                    choosenRectangle = new Rectangle(mnX, mnY, mxX - mnX + 1, mxY - mnY + 1);
                    //pb.Visible = false;
                    newPersonComboBox.Focus();
                    lastX = -1;
                    lastY = -1;
                    Debug.WriteLine(pb.Visible);
                }
                else
                {
                    pb.Visible = false;
                    lastX = -1;
                    lastY = -1;
                }
            }
        }

        private void updateInformation()
        {
            if (result.peopleIds.Count > 0) {
                while (labeledPeople.Count < result.peopleIds.Count)
                {
                    Label l = new Label();
                    l.AutoSize = true;
                    l.Font = new System.Drawing.Font("Georgia", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    l.Left = 0;
                    l.Top = yPosition(labeledPeople.Count);
                    l.MouseEnter += l_MouseEnter;
                    l.MouseLeave += l_MouseLeave;
                    l.MouseClick += l_MouseClick;
                    labeledPeople.Add(l);
                    this.labeledPeoplePanel.Controls.Add(labeledPeople.Last());
                }
                for (int i = 0; i < result.peopleIds.Count; ++i)
                {
                    labeledPeople[i].Tag = i;
                    labeledPeople[i].Text = data.allPeople[result.peopleIds[i]].FullName;
                    labeledPeople[i].Visible = true;
                }
                for (int i = result.peopleIds.Count; i < labeledPeople.Count; ++i)
                {
                    labeledPeople[i].Visible = false;
                }
                if (lastLabeledPeopleCount != labeledPeople.Count)
                {
                    //lastLabeledPeopleCount = labeledPeople.Count;
                    //Point pos = labeledPeoplePanel.AutoScrollPosition;
                    //szScroll = -labeledPeoplePanel.AutoScrollPosition.Y;
                    //labeledPeoplePanel.AutoScrollPosition = pos;
                }
            }
        }

        void l_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                choosenLabel = (Label) sender;
                deleteLabelMenuStrip.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void l_MouseLeave(object sender, EventArgs e)
        {
            pb.Visible = false;
            updateBold(-1);
        }

        private void l_MouseEnter(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            int id = (int) l.Tag;
            updateBold(id);
            updateZone(id);
        }

        private int getPersonId(string fullName)
        {
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                if (data.allPeople[i].FullName == fullName)
                {
                    return i;
                }
            }
            return -1;
        }

        private void newPersonComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pb.Visible = false;
                newPersonComboBox.Visible = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int id = getPersonId(newPersonComboBox.Text);
                if (id == -1)
                {
                    DialogResult res = MessageBox.Show("Введенное исходное лицо отсутствует в базе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newPersonComboBox.Focus();
                    return;
                }
                else
                {
                    result.peopleIds.Add(id);
                    result.zones.Add(choosenRectangle);
                    updateInformation();
                }
                pb.Visible = false;
                newPersonComboBox.Visible = false;
                photoPanel.Focus();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            result.additionalInfo = this.additionalInfo.Text;
            DialogResult = DialogResult.OK;
        }

        private void photo_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < result.peopleIds.Count; ++i)
            {
                labeledPeople[i].Font = new System.Drawing.Font("Georgia", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }

        private void updatePhotoPosition()
        {
            int w = this.photo.Image.Width;
            int h = this.photo.Image.Height;
            int wPanel = this.photoPanel.Width;
            int hPanel = this.photoPanel.Height;
            this.photoPanel.AutoScrollPosition = new Point(0, 0);
            this.photo.Left = Math.Max(4, (wPanel - w) / 2);
            this.photo.Top = Math.Max(4, (hPanel - h) / 2 - 10);
            //Debug.WriteLine("{0} {1}",);
        }

        private void AddPhoto_SizeChanged(object sender, EventArgs e)
        {
            //Form f = (Form)(sender);
            updatePhotoPosition();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данную отметку?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int index = (int)choosenLabel.Tag;
                result.peopleIds.RemoveAt(index);
                result.zones.RemoveAt(index);
                updateInformation();
            }
        }
    }
}
