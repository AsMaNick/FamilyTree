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
    public partial class EditPerson : Form
    {
        private int id;
        private MainPage parent;

        public EditPerson(MainPage mainPage, int Id)
        {
            InitializeComponent();
            id = Id;
            parent = mainPage;
            Person p = mainPage.data.allPeople[id];
            this.NameTextBox.Text = p.name;
            this.SurnameTextBox.Text = p.surname;
            this.PatronomicTextBox.Text = p.patronymic;
            this.PlaceTextBox.Text = p.birthPlace;
            this.BirthdayDate.Value = p.birthDate;
            this.DeathDate.Value = p.deathDate;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Person p = new Person(NameTextBox.Text, SurnameTextBox.Text, PatronomicTextBox.Text, PlaceTextBox.Text, BirthdayDate.Value, DeathDate.Value);
            Debug.WriteLine(p.BasicInfo());
            parent.data.allPeople[id] = p;
            this.DialogResult = DialogResult.OK;
        }
    }
}
