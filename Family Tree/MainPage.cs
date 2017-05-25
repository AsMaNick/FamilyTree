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
        private Person chosenPerson;
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
            buildTree();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            data.writeToFile("data.txt");
        }
        private void DrawGridView()
        {
            treePanel.Controls.Clear();
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

        private Pair<bool, Person> tryAddPerson(int id = -1, bool man = true)
        {
            AddPerson myForm = new AddPerson(this, id);
            if (!man)
            {
                myForm.enableWoman();
            }
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine("OK");
                return new Pair<bool, Person> (true, myForm.addedPerson);
            }
            else
            {
                Debug.WriteLine(res);
            }
            return new Pair<bool, Person>(false, myForm.addedPerson);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Double Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < 2)
            {
                Pair<bool, Person> p = tryAddPerson(getId(e.RowIndex));
                DrawGridView();
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

        private void showMenu(object sender, EventArgs ee)
        {
            MouseEventArgs e = (MouseEventArgs) ee;
            if (e.Button == MouseButtons.Right) {
                PictureBox pb = (PictureBox) sender;
                chosenPerson = (Person) pb.Tag;
                addConneсtionStrip.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        public static Image drawBorder(Image im)
        {
            Bitmap bitmap = new Bitmap(im);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 5), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }
            return bitmap;
        }

        private void showPerson(Person p, int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.Click += new System.EventHandler(showMenu);
            pb.Image = Image.FromFile(p.getPathToAvatar());
            pb.Image = drawBorder(pb.Image);
            pb.Height = pb.Image.Height;
            pb.Width = pb.Image.Width;
            pb.Left = x;
            pb.Top = y;
            pb.Tag = p;
            Label l = new Label();
            l.Text = p.FullName;
            l.Left = x - 10;
            l.Top = y + pb.Height + 5;
            l.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            l.Size = TextRenderer.MeasureText(l.Text, l.Font);
            l.Left = x + (pb.Width - l.Size.Width) / 2;
            this.treePanel.Controls.Add(pb);
            this.treePanel.Controls.Add(l);
        }
        
        const int dWidth = 200, dHeight = 150;

        private Pair<int, int> buildTree(Person p, int level = 0, int x = 40) 
        {
            Pair<int, int> res1 = new Pair<int, int> (0, x - dWidth);
            Pair<int, int> res2 = new Pair<int, int>(0, x - dWidth);
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
            Debug.WriteLine(string.Format("lev = {0}, x = {1}", level, x));
            return new Pair<int, int> (x, Math.Max(res1.Second, Math.Max(res2.Second, x)));
        }

        private void buildTree()
        {
            treePanel.Controls.Clear();
            buildTree(data.allPeople[0]);
        }

        private void деревоПредковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treePanel.Visible = true;
            dataGridView.Visible = false;
            buildTree(data.allPeople[0]);
        }

        private void отцаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson();
            if (p.First == true)
            {
                Debug.WriteLine(p.Second.BasicInfo());
                chosenPerson.father = p.Second.id;
            }
            buildTree();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson(chosenPerson.id);
            buildTree();
        }

        private void матьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson(-1, false);
            if (p.First == true)
            {
                Debug.WriteLine(p.Second.BasicInfo());
                chosenPerson.mother = p.Second.id;
            }
            buildTree();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = chosenPerson.id;
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить информацию о данном человеке?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                data.DeletePerson(id);
                buildTree();
            }
        }

        private void отцаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchPerson myForm = new SearchPerson(this);
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                chosenPerson.father = myForm.resId;
                buildTree();
            }
        }

        private void матьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPerson myForm = new SearchPerson(this);
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                chosenPerson.mother = myForm.resId;
                buildTree();
            }
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
