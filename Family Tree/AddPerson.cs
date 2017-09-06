﻿using System;
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
    public partial class AddPerson : Form
    {
        const int minPhotoHeight = 100, distanceBetweenPhotos = 5;
        public const int widthAvatar = 78, heightAvatar = 103;
        private int id;
        private MainPage parent;
        public Person addedPerson;
        private PictureBox choosenPhoto;

        public AddPerson(MainPage mainPage, int Id = -1)
        {
            InitializeComponent();
            parent = mainPage;
            id = Id;
            if (Id == -2)
            {
                mainInfoToolStripMenuItem.Visible = false;
                Person p = new Person();
                for (int i = 0; i < parent.data.allPhotos.Count; ++i)
                {
                    p.allPhotosIds.Add(i);
                }
                photoPanel.BringToFront();
                photoPanel.Visible = true;
                placeAllPhotos(p, parent.data.allPhotos);
                photoPanel.Focus();
                return;
            } 
            else if (id != -1)
            {
                InitializeForm();
            }
            else
            {
                fillAliveMenu(true);
                fillDeadMenu(false);
            }
            manRadioButton.TabStop = false;
        }

        private void updateDate(int y, int m, int d, TextBox Year, ComboBox Month, TextBox Day)
        {
            Year.Text = Convert.ToString(y);
            if (y == 0)
            {
                Year.Text = "";
            }
            Month.Text = "";
            if (m > 0)
            {
                Month.Text = this.BirthMonth.Items[m - 1].ToString();
            }
            Day.Text = Convert.ToString(d);
            if (d == 0)
            {
                Day.Text = "";
            }
        }

        public void InitializeForm()
        {
            Person p = parent.data.allPeople[id];
            this.nameTextBox.Text = p.name;
            this.surnameTextBox.Text = p.surname;
            this.patronomicTextBox.Text = p.patronymic;
            this.maidenNameTextBox.Text = p.maidenName;
            if (p.man)
            {
                this.womanRadioButton.Checked = false;
                this.manRadioButton.Checked = true;
            }
            else
            {
                this.womanRadioButton.Checked = true;
                this.manRadioButton.Checked = false;
            }
            if (p.alive)
            {
                this.aliveRadioButton.Checked = true;
                this.deadRadioButton.Checked = false;
            }
            else
            {
                this.aliveRadioButton.Checked = false;
                this.deadRadioButton.Checked = true;
            }
            this.contactsTextBox.Text = p.contacts;
            this.birthPlaceTextBox.Text = p.birthPlace;
            this.burialPlaceTextBox.Text = p.burialPlace;
            updateDate(p.birthDate.Year, p.birthDate.Month, p.birthDate.Day, this.BirthYear, this.BirthMonth, this.BirthDay);
            updateDate(p.deathDate.Year, p.deathDate.Month, p.deathDate.Day, this.DeathYear, this.DeathMonth, this.DeathDay);
            Debug.WriteLine(p.deathDate.Year);
            Debug.WriteLine(DeathYear.Text);
            this.additionalInfoRichTextBox.Text = "";
            for (int i = 0; i < p.additionalInfo.Length; ++i)
            {
                this.additionalInfoRichTextBox.Text += p.additionalInfo[i];
                if (i + 1 < p.additionalInfo.Length)
                {
                    this.additionalInfoRichTextBox.Text += "\n";
                }
            }
            for (int i = 0; i < this.additionalInfoRichTextBox.Lines.Length; ++i)
            {
                Debug.WriteLine(string.Format("{0} {1}", i, this.additionalInfoRichTextBox.Lines[i]));
            }
            this.addButton.Text = "OK";
            if (p.fileAvatar != "")
            {
                int h = this.avatarPictureBox.Image.Height;
                int w = this.avatarPictureBox.Image.Width;
                this.avatarPictureBox.Image = (Image) (new Bitmap(Image.FromFile(DataBase.pathToAvatarss + p.fileAvatar), new Size(w, h)));
                this.avatarPictureBox.Image = MainPage.drawBorder(this.avatarPictureBox.Image);
                this.avatarPictureBox.Tag = new ID(p.fileAvatar);
            }
            addedPerson = new Person();
            addedPerson.mother = p.mother;
            addedPerson.father = p.father;
            addedPerson.partner = p.partner;
            addedPerson.siblings = new List<int> ();
            for (int i = 0; i < p.siblings.Count; ++i)
            {
                addedPerson.siblings.Add(p.siblings[i]);
            }
            addedPerson.children = new List<int>();
            for (int i = 0; i < p.children.Count; ++i)
            {
                addedPerson.children.Add(p.children[i]);
            }
            fillAliveMenu(p.alive);
            fillDeadMenu(!p.alive);
        }

        private int getMonth(string month)
        {
            if (month == "")
            {
                return 0;
            }
            for (int i = 0; i < BirthMonth.Items.Count; ++i)
            {
                if (BirthMonth.Items[i].ToString() == month)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        private bool MyTryParse(string s, out int x) 
        {
            if (s == "")
            {
                x = 0;
                return true;
            }
            return int.TryParse(s, out x);
        }

        private bool leapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
        }

        private bool dateExists(int y, int m, int d)
        {
            if (d == 0)
            {
                return true;
            }
            if (m == 0)
            {
                return 1 <= d && d <= 31;
            }
            --m;
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (leapYear(y))
            {
                ++days[1];
            }
            return d >= 1 && d <= days[m];
        }

        private Date getDate(TextBox Year, ComboBox Month, TextBox Day)
        {
            int d, m, y;
            bool okDay = MyTryParse(Day.Text, out d);
            m = getMonth(Month.Text);
            bool okYear = MyTryParse(Year.Text, out y);
            if (okDay && m != -1 && okYear)
            {
                if (y >= 0 && y < 3000 && dateExists(y, m, d))
                {
                    return new Date(y, m, d);
                }
            }
            throw new System.ArgumentException("Wrong field");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string fileAvatar = "";
            if (avatarPictureBox.Tag != null)
            {
                fileAvatar = avatarPictureBox.Tag.ToString();
            }
            int nid = id;
            if (id == -1)
            {
                nid = parent.data.allPeople.Count;
            }
            Date BirthDate, DeathDate;
            try
            {
                BirthDate = getDate(BirthYear, BirthMonth, BirthDay);
            }
            catch (ArgumentException exc)
            {
                string error = exc.Message;
                DialogResult res = MessageBox.Show("Неверно заполнено поле \"Дата рожения\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DeathDate = getDate(DeathYear, DeathMonth, DeathDay);
            }
            catch (ArgumentException exc)
            {
                string error = exc.Message;
                DialogResult res = MessageBox.Show("Неверно заполнено поле \"Дата смерти\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Person p = new Person(nameTextBox.Text, surnameTextBox.Text, patronomicTextBox.Text, maidenNameTextBox.Text, manRadioButton.Checked, aliveRadioButton.Checked, contactsTextBox.Text, birthPlaceTextBox.Text, burialPlaceTextBox.Text, BirthDate, DeathDate, additionalInfoRichTextBox.Lines, fileAvatar, nid);
            if (addedPerson != null)
            {
                p.mother = addedPerson.mother;
                p.father = addedPerson.father;
                p.partner = addedPerson.partner;
                p.siblings = new List<int>();
                for (int i = 0; i < addedPerson.siblings.Count; ++i)
                {
                    p.siblings.Add(addedPerson.siblings[i]);
                }
                p.children = new List<int>();
                for (int i = 0; i < addedPerson.children.Count; ++i)
                {
                    p.children.Add(addedPerson.children[i]);
                }
            }
            addedPerson = p;
            Debug.WriteLine(p.BasicInfo());
            for (int i = 0; i < additionalInfoRichTextBox.Lines.Length; ++i)
            {
                Debug.WriteLine(additionalInfoRichTextBox.Lines[i]);
            }
            if (id == -1)
            {
                parent.AddPerson(p);
            }
            else
            {
                parent.data.allPeople[id] = p;
            }
            this.DialogResult = DialogResult.OK;
        }

        public void enableWoman()
        {
            if (!this.womanRadioButton.Checked)
            {
                this.womanRadioButton.Checked = true;
                return;
            }
            if (this.avatarPictureBox.Tag == null)
            {
                this.avatarPictureBox.Image = Family_Tree.Properties.Resources.woman2;
            }
            this.maidenNameLabel.Text = "Девичья фамилия";
            this.aliveRadioButton.Text = "Жива";
            this.deadRadioButton.Text = "Умерла";
            this.womanRadioButton.TabStop = false;
        }

        public void enableMan()
        {
            if (!this.manRadioButton.Checked)
            {
                this.manRadioButton.Checked = true;
                return;
            }
            if (this.avatarPictureBox.Tag == null)
            {
                this.avatarPictureBox.Image = Family_Tree.Properties.Resources.man2;
            }
            this.maidenNameLabel.Text = "Фамилия до брака";
            this.aliveRadioButton.Text = "Жив";
            this.deadRadioButton.Text = "Умер";
            this.manRadioButton.TabStop = false;
        }

        public void fixGender()
        {
            this.manRadioButton.Enabled = false;
            this.womanRadioButton.Enabled = false;
        }

        private void womanRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.womanRadioButton.Checked)
            {
                enableWoman();
            }
        }

        private void manRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manRadioButton.Checked)
            {
                enableMan();
            }
        }

        private void fillAliveMenu(bool value) 
        {
            this.contactsLabel.Visible = value;
            this.contactsTextBox.Visible = value;
        }

        private void fillDeadMenu(bool value)
        {
            this.burialPlaceLabel.Visible = value;
            this.burialPlaceTextBox.Visible = value;
            this.deathDataLabel.Visible = value;
            this.DeathYear.Visible = value;
            this.DeathMonth.Visible = value;
            this.DeathDay.Visible = value;
        }

        private void deadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            fillAliveMenu(false);
            fillDeadMenu(true);
        }

        private void aliveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            fillDeadMenu(false);
            fillAliveMenu(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Все изображения|*.jpg;*.bmp;*.gif;*.png";
            DialogResult res = fileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine(fileDialog.FileName);
                GetPhoto getPhoto = new GetPhoto(fileDialog.FileName);
                DialogResult res2 = getPhoto.ShowDialog();
                if (res2 == DialogResult.OK) {
                    int w = this.avatarPictureBox.Image.Width;
                    int h = this.avatarPictureBox.Image.Height;
                    this.avatarPictureBox.Image = (Image) (new Bitmap(getPhoto.Result, new Size(w, h)));
                    this.avatarPictureBox.Tag = new ID(parent.data.AddAvatar(this.avatarPictureBox.Image));
                    this.avatarPictureBox.Image = MainPage.drawBorder(this.avatarPictureBox.Image);
                    Debug.WriteLine(this.avatarPictureBox.Tag.ToString());
                }
            }
        }

        private void основнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            photoPanel.Visible = false;
        }

        private void placeAllPhotos(Person p, List<Photo> allPhotos)
        {
            List<int> allIds = new List<int> ();
            for (int i = 0; i < p.allPhotosIds.Count; ++i)
            {
                if (!allPhotos[p.allPhotosIds[i]].deleted)
                {
                    allIds.Add(p.allPhotosIds[i]);
                }
            }
            int h = distanceBetweenPhotos;
            List<PictureBox> allPb = new List<PictureBox>();
            for (int i = 0; i < allIds.Count; )
            {
                int cnt = 0, sum = 0;
                for (int j = i; j < allIds.Count; ++j)
                {
                    int id = allIds[j];
                    int totalWidth = (cnt + 2) * distanceBetweenPhotos + sum + (allPhotos[id].img.Width * minPhotoHeight) / allPhotos[id].img.Height;
                    if (totalWidth >= photoPanel.Width)
                    {
                        break;
                    }
                    ++cnt;
                    sum += (allPhotos[id].img.Width * minPhotoHeight) / allPhotos[id].img.Height;
                }
                cnt = Math.Max(cnt, 1);
                double k = 1.0 * (photoPanel.Width - 15 - (cnt + 1) * distanceBetweenPhotos) / sum;
                Debug.WriteLine("{0} {1}", i, k);
                sum = 0;
                int plH = 0;
                for (int j = i; j < i + cnt; ++j)
                {
                    int id = allIds[j];
                    PictureBox pb = new PictureBox();
                    pb.Image = Photo.Scale(allPhotos[id].img, k * minPhotoHeight / allPhotos[id].img.Height);
                    pb.Size = pb.Image.Size;
                    pb.Left = (j - i) * distanceBetweenPhotos + sum;
                    pb.Top = h;
                    pb.MouseDoubleClick += photo_MouseDoubleClick;
                    pb.Tag = id;
                    plH = pb.Height;
                    pb.MouseClick += photo_MouseClick;
                    allPb.Add(pb);
                    sum += pb.Width;
                }
                h += plH + distanceBetweenPhotos;
                i += cnt;
            }
            this.photoPanel.Controls.Clear();
            for (int i = 0; i < allPb.Count; ++i)
            {
                this.photoPanel.Controls.Add(allPb[i]);
            }
        }

        void photo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                choosenPhoto = (PictureBox)sender;
                deletePhotoMenuStrip.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        void photo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            PictureBox pb = (PictureBox)(sender);
            int id = (int)pb.Tag;
            AddPhoto addPhoto = new AddPhoto(parent.data.allPhotos[id], parent.data);
            DialogResult res2 = addPhoto.ShowDialog();
            if (res2 == DialogResult.OK)
            {
                
            }
        }

        private bool photoClick = false;

        private void фотографииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == -2)
            {
                photoPanel.Focus();
                return;
            }
            Debug.WriteLine(id);
            if (id == -1 || parent.data.allPeople[id].allPhotosIds.Count == 0 || parent.data.allPhotos.Count == 0)
            {
                DialogResult res = MessageBox.Show("У данной персоны нет загруженных фотографий.", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            photoPanel.BringToFront();
            photoPanel.Visible = true;
            photoPanel.Focus();
            if (photoClick)
            {
                return;
            }
            photoClick = true;
            placeAllPhotos(parent.data.allPeople[id], parent.data.allPhotos);
        }

        private void AddPerson_Activated(object sender, EventArgs e)
        {
            if (id == -2)
            {
                this.photoPanel.Focus();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pb = choosenPhoto;
            int delId = (int)pb.Tag;
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данную фотографию?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                parent.data.deletePhoto(delId);
            }
            if (id == -2)
            {
                Person p = new Person();
                for (int i = 0; i < parent.data.allPhotos.Count; ++i)
                {
                    p.allPhotosIds.Add(i);
                }
                placeAllPhotos(p, parent.data.allPhotos);
            }
            else
            {
                placeAllPhotos(parent.data.allPeople[id], parent.data.allPhotos);
            }
        }
    }
}
