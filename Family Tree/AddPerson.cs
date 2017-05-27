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
    public partial class AddPerson : Form
    {
        private int id;
        private MainPage parent;
        public Person addedPerson;

        public AddPerson(MainPage mainPage, int Id = -1)
        {
            InitializeComponent();
            parent = mainPage;
            id = Id;
            if (id != -1)
            {
                InitializeForm();
            }
            manRadioButton.TabStop = false;
            Debug.WriteLine(manRadioButton.TabStop);
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
            this.birthdayDate.Value = p.birthDate;
            this.deathDate.Value = p.deathDate;
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
                this.avatarPictureBox.Image = (Image) (new Bitmap(Image.FromFile(DataBase.pathToAvatars + p.fileAvatar), new Size(w, h)));
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
            Person p = new Person(nameTextBox.Text, surnameTextBox.Text, patronomicTextBox.Text, maidenNameTextBox.Text, manRadioButton.Checked, aliveRadioButton.Checked, contactsTextBox.Text, birthPlaceTextBox.Text, burialPlaceTextBox.Text, birthdayDate.Value, deathDate.Value, additionalInfoRichTextBox.Lines, fileAvatar, nid);
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
            this.deathDate.Visible = value;
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
                int h = this.avatarPictureBox.Image.Height;
                int w = this.avatarPictureBox.Image.Width;
                this.avatarPictureBox.Image = (Image) (new Bitmap(Image.FromFile(fileDialog.FileName), new Size(w, h)));
                this.avatarPictureBox.Tag = new ID(parent.data.AddAvatar(this.avatarPictureBox.Image));
                Debug.WriteLine(this.avatarPictureBox.Tag.ToString());
            }
        }
    }
}
