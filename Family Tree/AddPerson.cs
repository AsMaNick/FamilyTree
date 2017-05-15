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
        private MainPage parent;

        public AddPerson(MainPage mainPage)
        {
            InitializeComponent();
            parent = mainPage;
        }
        
        private DateTime GetDate(string s) 
        {
            DateTime res = new DateTime(1999, 9, 23);
            return res;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(this.NameTextBox.Text);
            Debug.WriteLine(this.SurnameTextBox.Text);
            Debug.WriteLine(this.PatronomicTextBox.Text);
            Debug.WriteLine(this.BirthdayDate.Text);
            Debug.WriteLine(this.DeathDate.Text);
            Debug.WriteLine(this.PlaceTextBox.Text);
            Person p = new Person(NameTextBox.Text, SurnameTextBox.Text, PatronomicTextBox.Text, PlaceTextBox.Text, GetDate(BirthdayDate.Text), GetDate(DeathDate.Text));
            parent.AddPerson(p);
            this.DialogResult = DialogResult.OK;
        }
    }
}
