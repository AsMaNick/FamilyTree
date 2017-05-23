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
            treePanel.Visible = false;
            DrawGridView();
        }

        private int getId(int rowIndex)
        {
            return Int32.Parse(dataGridView.Rows[rowIndex].Cells[0].Tag.ToString());
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Double Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < 2)
            {
                AddPerson myForm = new AddPerson(this, getId(e.RowIndex));
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
                int id = getId(e.RowIndex);
                DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить информацию о данном человеке?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    data.DeletePerson(id);
                    DrawGridView();
                }
            }
        }

        private void nothing1(object sender, EventArgs e)
        {
            Debug.WriteLine("QQQ");
        }

        private void showPerson(Person p, int x, int y)
        {
            PictureBox pb = new PictureBox();
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Item 1", new System.EventHandler(nothing1));
            //cm.MenuItems.Add("Item 2", new EventHandler(pb)); 
            pb.ContextMenu = cm;
            pb.Image = Image.FromFile(p.getPathToAvatar());
            pb.Height = pb.Image.Height;
            pb.Width = pb.Image.Width;
            pb.Left = x;
            pb.Top = y;
            Label l = new Label();
            l.Text = p.FullName;
            l.Size = new Size(200, 15);
            l.Left = x - 10;
            l.Top = y + pb.Height + 5;
            this.treePanel.Controls.Add(pb);
            this.treePanel.Controls.Add(l);
        }
        
        const int dWidth = 100, dHeight = 200;

        private Pair<int, int> buildTree(Person p, int level, int x) 
        {
            Pair<int, int> res1 = new Pair<int, int> (0, x);
            Pair<int, int> res2 = new Pair<int, int>(0, x);
            if (p.father != -1)
            {
                res1 = buildTree(data.allPeople[p.father], level + 1, x);
            }
            if (p.mother != -1)
            {
                res2 = buildTree(data.allPeople[p.mother], level + 1, res1.Second + dWidth);
            }
            if (p.father == -1 && p.mother == -1)
            {
            }
            else if (p.father == -1 || p.mother == -1)
            {
                x = res1.First + res2.First;
            }
            else
            {
                x = (res1.First + res2.First) / 2;
            }
            showPerson(p, x, 10 + level * dHeight);
            return new Pair<int, int> (x, Math.Max(res1.Second, Math.Max(res2.Second, x)));
        }
        private void деревоПредковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treePanel.Visible = true;
            dataGridView.Visible = false;
            buildTree(data.allPeople[0], 0, 20);
        }
    }

    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
}
