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
        private MainPage parent;

        public AddPerson(MainPage mainPage)
        {
            InitializeComponent();
            parent = mainPage;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Person p = new Person(NameTextBox.Text, SurnameTextBox.Text, PatronomicTextBox.Text, PlaceTextBox.Text, BirthdayDate.Value, DeathDate.Value);
            Debug.WriteLine(p.BasicInfo());
            parent.AddPerson(p);
            this.DialogResult = DialogResult.OK;
        }
    }
}
