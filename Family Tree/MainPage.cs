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
using System.IO;

namespace Family_Tree
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void AddPerson(Person p)
        {
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(p.BasicInfo());
            output.Close();
            Debug.WriteLine(p.BasicInfo());
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPerson myForm = new AddPerson(this);
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine("OK");
            }
        }
    }
}
