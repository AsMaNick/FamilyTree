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
    public class ID
    {
        public int id;
        public ID(int Id)
        {
            id = Id;
        }
        public override string ToString()
        {
            return Convert.ToString(id);
        }
    }

    public partial class MainPage : Form
    {
        public DataBase data;
        public MainPage()
        {
            InitializeComponent();
            data = new DataBase();
            dataGridView.Visible = false;
        }
        public void AddPerson(Person p)
        {
            data.AddPerson(p);
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPerson myForm = new AddPerson(this);
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine("OK");
            }
            DrawGridView();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            data.writeToFile("data.txt");
        }
        private void DrawGridView()
        {
            dataGridView.Rows.Clear();
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[i].Cells[0].Value = data.allPeople[i].FullName;
                dataGridView.Rows[i].Cells[1].Value = data.allPeople[i].birthPlace;
                dataGridView.Rows[i].Cells[0].Tag = new ID(i);
                dataGridView.Rows[i].ReadOnly = true;
            }
        }
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = true;
            DrawGridView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Double Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < 2)
            {
                AddPerson myForm = new AddPerson(this, e.RowIndex);
                DialogResult res = myForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Debug.WriteLine("OK");
                    DrawGridView();
                }
                else
                {
                    Debug.WriteLine(res);
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                int id = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Tag.ToString());
                DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить информацию о данном человеке?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    data.DeletePerson(id);
                    DrawGridView();
                }
            }
        }
    }
}
