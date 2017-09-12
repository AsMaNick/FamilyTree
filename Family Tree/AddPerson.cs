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
using System.Threading;

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
        private Thread loadPhotos;
        private int startBadPb;

        public AddPerson(MainPage mainPage, int Id = -1)
        {
            InitializeComponent();
            parent = mainPage;
            id = Id;
            if (id == -2)
            {
                mainInfoToolStripMenuItem.Visible = false;
                documentsToolStripMenuItem.Visible = false;
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
                documentsToolStripMenuItem.Visible = false;
                photosToolStripMenuItem.Visible = false;
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
            addedPerson.siblings = new List<int> (p.siblings);
            addedPerson.children = new List<int> (p.children);
            addedPerson.allPartners = new List<int> (p.allPartners);
            addedPerson.allPhotosIds = new List<int> (p.allPhotosIds);
            addedPerson.secretId = p.secretId;
            addedPerson.divorced = p.divorced;
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
            int[] days = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (Date.leapYear(y))
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
            if (Date.dateMinimize(BirthDate) > Date.dateMaximize(DeathDate))
            {
                DialogResult res = MessageBox.Show("Дата рождения должна быть раньше даты смерти.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Person p = new Person(nameTextBox.Text, surnameTextBox.Text, patronomicTextBox.Text, maidenNameTextBox.Text, manRadioButton.Checked, aliveRadioButton.Checked, contactsTextBox.Text, birthPlaceTextBox.Text, burialPlaceTextBox.Text, BirthDate, DeathDate, additionalInfoRichTextBox.Lines, fileAvatar, nid);
            if (addedPerson != null)
            {
                p.mother = addedPerson.mother;
                p.father = addedPerson.father;
                p.partner = addedPerson.partner;
                p.siblings = new List<int> (addedPerson.siblings);
                p.children = new List<int> (addedPerson.children);
                p.allPartners = new List<int> (addedPerson.allPartners);
                p.allPhotosIds = new List<int> (addedPerson.allPhotosIds);
                p.divorced = addedPerson.divorced;
                p.secretId = addedPerson.secretId;
            }
            if (p.partner != -1 && parent.data.allPeople[p.partner].man == p.man)
            {
                string error;
                if (p.man)
                {
                    error = "Данная персона не может быть мужчиной, т.к. у нее есть муж.";
                }
                else
                {
                    error = "Данная персона не может быть женщиной, т.к. у нее есть жена.";
                }
                DialogResult res = MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < p.children.Count; ++i)
            {
                if (parent.data.allPeople[p.children[i]].father == p.id && !p.man)
                {
                    string error = "Данная персона не может быть женщиной, т.к. она является отцом для другой персоны.";
                    DialogResult res = MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (parent.data.allPeople[p.children[i]].mother == p.id && p.man)
                {
                    string error = "Данная персона не может быть мужчиной, т.к. она является матерью для другой персоны.";
                    DialogResult res = MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            addedPerson = p;
            if (id == -1)
            {
                addedPerson.secretId = parent.data.genSecretId();
            }
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
            if (p.mother != -1)
            {
                parent.data.sortChildrenList(parent.data.allPeople[p.mother]);
            }
            if (p.father != -1)
            {
                parent.data.sortChildrenList(parent.data.allPeople[p.father]);
            }
            Dispose();
            AbortThread();
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
            fileDialog.Filter = Photo.Filter;
            DialogResult res = fileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine(fileDialog.FileName);
                GetPhoto getPhoto = new GetPhoto(fileDialog.FileName);
                DialogResult res2 = getPhoto.ShowDialog();
                if (res2 == DialogResult.OK) {
                    int w = this.avatarPictureBox.Image.Width;
                    int h = this.avatarPictureBox.Image.Height;
                    this.avatarPictureBox.Image = Photo.Resize(getPhoto.Result, w, h);
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

        private void Dispose()
        {
            for (int i = 0; i < photoPanel.Controls.Count; ++i)
            {
                PictureBox pb = (PictureBox)photoPanel.Controls[i];
                Photo.Dispose(pb.Image);
            }
        }

        private void placeAllPhotos(Person p, List<Photo> allPhotos)
        {
            Cursor = Cursors.WaitCursor;
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
                    int totalWidth = (cnt + 2) * distanceBetweenPhotos + sum + (allPhotos[id].width * minPhotoHeight) / allPhotos[id].height;
                    if (totalWidth >= photoPanel.Width)
                    {
                        break;
                    }
                    ++cnt;
                    sum += (allPhotos[id].width * minPhotoHeight) / allPhotos[id].height;
                }
                cnt = Math.Max(cnt, 1);
                double k = 1.0 * (photoPanel.Width - 15 - (cnt + 1) * distanceBetweenPhotos) / sum;
                Debug.WriteLine("{0} {1}, cnt = {2}", i, k, cnt);
                sum = 0;
                int plH = 0;
                for (int j = i; j < i + cnt; ++j)
                {
                    int id = allIds[j];
                    PictureBox pb = new PictureBox();
                    double coef = k * minPhotoHeight / allPhotos[id].height;
                    int nWidth = Convert.ToInt32(allPhotos[id].width * coef);
                    int nHeight = Convert.ToInt32(allPhotos[id].height * coef);
                    //pb.Image = Photo.Scale(parent.data.img(id), coef);
                    //pb.Image = parent.data.img(id, k * minPhotoHeight / parent.data.img(id).Height);
                    //pb.Image = (Image) (new Bitmap(nWidth, nHeight));
                    pb.Size = new Size(nWidth, nHeight);
                    //pb.BackColor = Color.Gray;
                    pb.Left = (j - i) * distanceBetweenPhotos + sum;
                    pb.Top = h;
                    pb.MouseClick += photo_MouseClick;
                    pb.MouseEnter += photo_MouseEnter;
                    pb.MouseLeave += photo_MouseLeave;
                    pb.Tag = id;
                    plH = pb.Height;
                    allPb.Add(pb);
                    sum += pb.Width;
                }
                h += plH + distanceBetweenPhotos;
                i += cnt;
            }
            /*startBadPb = Math.Min(allPb.Count, photoPanel.Controls.Count);
            for (int i = 0; i < Math.Min(allPb.Count, photoPanel.Controls.Count); ++i)
            {
                PictureBox pb = (PictureBox)(photoPanel.Controls[i]);
                int id1 = (int)pb.Tag;
                int id2 = (int)allPb[i].Tag;
                if (id1 != id2)
                {
                    startBadPb = i;
                    break;
                }
            }
            for (int i = startBadPb; i < photoPanel.Controls.Count;)
            {
                PictureBox pb = (PictureBox)(photoPanel.Controls[i]);
                Photo.Dispose(pb.Image);
                photoPanel.Controls.RemoveAt(i);
            }*/
            for (int i = 0; i < this.photoPanel.Controls.Count; ++i)
            {
                this.photoPanel.Controls[i].Visible = false;
            }
            Dispose();
            this.photoPanel.Controls.Clear();
            startBadPb = 0;
            for (int i = startBadPb; i < allPb.Count; ++i)
            {
                this.photoPanel.Controls.Add(allPb[i]);
            }
            Cursor = Cursors.Default;
            //fillAllPictureBoxes();
            loadPhotos = new Thread(fillAllPictureBoxes);
            loadPhotos.Start();
        }

        private void fillAllPictureBoxes()
        {
            List<int> badI = new List<int>();
            for (int i = startBadPb; i < this.photoPanel.Controls.Count; ++i)
            {
                badI.Add(i);
            }
            while (badI.Count > 0)
            {
                List<int> nBad = new List<int>();
                foreach (int i in badI)
                {
                    if (i >= this.photoPanel.Controls.Count)
                    {
                        break;
                    }
                    PictureBox pb = (PictureBox)this.photoPanel.Controls[i];
                    int id = (int)pb.Tag;
                    try
                    {
                        pb.Image = (Image)(new Bitmap(parent.data.img(parent.data.allPhotos[id].pathToLightFile), pb.Width, pb.Height));
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                    finally
                    {
                        if (pb.Image == null)
                        {
                            Debug.WriteLine("{0} {1}", "FAIL", i);
                            nBad.Add(i);
                        }
                    }
                }
                badI = new List<int>(nBad);
            }
        }

        void photo_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        void photo_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        void photo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                choosenPhoto = (PictureBox)sender;
                deletePhotoMenuStrip.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
                PictureBox pb = (PictureBox)(sender);
                int idPhoto = (int)pb.Tag;
                Photo ph = parent.data.allPhotos[idPhoto];
                for (int i = 0; i < ph.peopleIds.Count; ++i)
                {
                    parent.data.allPeople[ph.peopleIds[i]].allPhotosIds.Remove(idPhoto);
                }
                AddPhoto addPhoto = new AddPhoto(ph, parent.data);
                DialogResult res2 = addPhoto.ShowDialog();
                if (res2 == DialogResult.OK)
                {
                    parent.data.allPhotos[idPhoto] = addPhoto.result;
                    ph = parent.data.allPhotos[idPhoto];
                }
                bool thisPhotoPresent = false;
                for (int i = 0; i < ph.peopleIds.Count; ++i)
                {
                    parent.data.allPeople[ph.peopleIds[i]].allPhotosIds.Add(idPhoto);
                    if (ph.peopleIds[i] == id)
                    {
                        thisPhotoPresent = true;
                    }
                }
                if (!thisPhotoPresent && id != -2)
                {
                    placeAllPhotos(parent.data.allPeople[id], parent.data.allPhotos);
                }
            }
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

        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(DataBase.pathToDocuments + addedPerson.secretId))
            {
                System.IO.Directory.CreateDirectory(DataBase.pathToDocuments + addedPerson.secretId);
            }
            System.Diagnostics.Process.Start(DataBase.pathToDocumentsToStart + addedPerson.secretId);
            //System.Diagnostics.Process.Start("..\\..\\images/avatars/26.jpg");
        }
        
        private bool photoClick = false;

        private void добавитьФотографиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.tryAddPhoto();
            photoClick = false;
            if (photoPanel.Visible)
            {
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
                photoClick = true;
                photoPanel.Focus();
            }
        }

        private void просмотрФотографийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == -2)
            {
                photoPanel.Focus();
                return;
            }
            Debug.WriteLine(id);
            if (id == -1 || parent.data.allPeople[id].allPhotosIds.Count == 0 || parent.data.allPhotos.Count == 0)
            {
                DialogResult res = MessageBox.Show("У данной персоны нет загруженных фотографий. Хотите добавить?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    if (!parent.tryAddPhoto())
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
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

        private void показатьВПапкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pb = choosenPhoto;
            int photoId = (int)pb.Tag;
            Process.Start(new ProcessStartInfo("explorer.exe", "/select, " + System.IO.Path.GetFullPath(DataBase.pathToGroupPhotosToStart + parent.data.allPhotos[photoId].pathToFile)));
        }

        private void AbortThread()
        {
            if (loadPhotos != null)
            {
                while (loadPhotos.IsAlive)
                {
                    loadPhotos.Abort();
                }
            }
        }

        private void AddPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            AbortThread();
        }
    }
}
