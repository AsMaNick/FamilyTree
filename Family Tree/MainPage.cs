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
        const int dWidth = 200, dWidthCouple = 130, dHeight = 150, dText = 20, hLine = 10;
        const int ANCESTORS = 1, DESCENDANTS = 2, HOURGLASS = 3;
        const bool ancestorsToUp = true;
        
        public DataBase data;
        private Person chosenPerson;
        private Graphics g;

        public MainPage()
        {
            InitializeComponent();
            data = new DataBase();
            dataGridView.Visible = false;
            //Paint += PaintEvent;
            Resize += PaintEvent;
        }

        public void AddPerson(Person p)
        {
            data.AddPerson(p);
        }

        private void turnOffPanels()
        {
            dataGridView.Visible = false;
            treePanel.Visible = false;
            treeSettingsPanel.Visible = false;
            treePanel.Controls.Clear();
        }

        private void showActivePanel()
        {
            if (dataGridView.Visible)
            {
                DrawGridView();
            }
            else if (treePanel.Visible)
            {
                buildTree();
            }
            else if (treeSettingsPanel.Visible)
            {
            }
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPerson myForm = new AddPerson(this);
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine("OK");
            }
            showActivePanel();
            
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
            turnOffPanels();
            dataGridView.Visible = true;
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
            Debug.WriteLine(string.Format("({0} {1})", x, y));
            PictureBox pb = new PictureBox();
            pb.Name = "Person" + Convert.ToString(p.id);
            pb.Click += new System.EventHandler(showMenu);
            Debug.WriteLine(string.Format("incognito: {0}, name: {1}", p.incognito, p.FullName));
            pb.Image = Image.FromFile(p.getPathToAvatar());
            pb.Image = drawBorder(pb.Image);
            pb.Height = pb.Image.Height;
            pb.Width = pb.Image.Width;
            pb.Left = x;
            pb.Top = y;
            pb.Tag = p;
            Label l = new Label();
            l.Text = p.ShortName;
            l.Left = x - 10;
            l.Top = y + pb.Height + 5;
            l.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            l.Size = TextRenderer.MeasureText(l.Text, l.Font);
            l.Left = x + (pb.Width - l.Size.Width) / 2;
            this.treePanel.Controls.Add(pb);
            this.treePanel.Controls.Add(l);
        }

        private void showCouple(Person father, Person mother, int x, int y)
        {
            showPerson(father, x, y);
            showPerson(mother, x + dWidthCouple, y);
        }

        private PictureBox getPbById(int id) {
            Debug.WriteLine(id);
            PictureBox p = (PictureBox) this.treePanel.Controls.Find("Person" + Convert.ToString(id), true)[0];
            /*if (p.Length == 0)
            {
                Debug.WriteLine(string.Format("cann't find such person, id = {0}", id));
                return null;
            }*/
            return p;
        }

        private void drawConnection(PictureBox p1, PictureBox p2, bool rev)
        {
            Pen pen = new Pen(Color.Gray, 2);
            int x1 = (p1.Left + p1.Right) / 2;
            int x2 = (p2.Left + p2.Right) / 2;
            if (!rev)
            {
                int y1 = p1.Bottom + dText;
                int y2 = p2.Top - 5;
                g.DrawLine(pen, new Point(x1, y1), new Point(x1, y1 + hLine));
                g.DrawLine(pen, new Point(x1, y1 + hLine), new Point(x2, y1 + hLine));
                g.DrawLine(pen, new Point(x2, y1 + hLine), new Point(x2, y2));
            }
            else
            {
                int y1 = p1.Top - 5;
                int y2 = p2.Bottom + dText;
                g.DrawLine(pen, new Point(x1, y1), new Point(x1, y1 - hLine));
                g.DrawLine(pen, new Point(x1, y1 - hLine), new Point(x2, y1 - hLine));
                g.DrawLine(pen, new Point(x2, y1 - hLine), new Point(x2, y2));
            }
        }

        private int getHeightOfAncestors(Person p, int level)
        {
            int res = level;
            if (p.father != -1) 
            {
                res = Math.Max(res, getHeightOfAncestors(data.allPeople[p.father], level + 1));
            }
            if (p.mother != -1)
            {
                res = Math.Max(res, getHeightOfAncestors(data.allPeople[p.mother], level + 1));
            }
            return res;
        }

        private int getHeightOfDescendants(Person p, int level)
        {
            int res = level;
            for (int i = 0; i < p.children.Count; ++i)
            {
                res = Math.Max(res, getHeightOfDescendants(data.allPeople[p.children[i]], level + 1));
            }
            return res;
        }

        private Pair<int, int> buildTreeOfAncestors(Person p, int level, int x, int maxLevel, int height, bool rev) 
        {
            Pair<int, int> res1 = new Pair<int, int> (0, x);
            Pair<int, int> res2 = new Pair<int, int>(0, x);
            bool isFather = (p.father != -1 && level + 1 < maxLevel);
            bool isMother = (p.mother != -1 && level + 1 < maxLevel);
            if (isFather)
            {
                res1 = buildTreeOfAncestors(data.allPeople[p.father], level + 1, x, maxLevel, height, rev);
            }
            if (isMother)
            {
                res2 = buildTreeOfAncestors(data.allPeople[p.mother], level + 1, res1.Second, maxLevel, height, rev);
            }
            if (!isFather && !isMother)
            {
            }
            else if (!isFather || !isMother)
            {
                x = res1.First + res2.First;
            }
            else
            {
                x = (res1.First + res2.First) / 2;
            }
            int realLevel = level;
            if (rev)
            {
                realLevel = height - level;
            }
            showPerson(p, x, 10 + realLevel * dHeight);
            Debug.WriteLine(string.Format("lev = {0}, x = {1}", level, x));
            return new Pair<int, int> (x, Math.Max(res1.Second, Math.Max(res2.Second, x + dWidth)));
        }

        private void buildLinesOfAncestors(Person p, int level, int maxLevel, bool rev)
        {
            bool isFather = (p.father != -1 && level + 1 < maxLevel);
            bool isMother = (p.mother != -1 && level + 1 < maxLevel);
            PictureBox cur = getPbById(p.id);
            if (isFather)
            {
                drawConnection(cur, getPbById(p.father), rev);
                buildLinesOfAncestors(data.allPeople[p.father], level + 1, maxLevel + 1, rev);
            }
            if (isMother)
            {
                drawConnection(cur, getPbById(p.mother), rev);
                buildLinesOfAncestors(data.allPeople[p.mother], level + 1, maxLevel + 1, rev);
            }
        }

        private Pair<int, int> buildTreeOfDescendants(Person p, int level, int x, int maxLevel, int height, bool rev)
        {
            List<Pair<int, int> > res = new List<Pair<int, int>>();
            int startX = x;
            for (int i = 0; i < p.children.Count; ++i)
            {
                res.Add(buildTreeOfDescendants(data.allPeople[p.children[i]], level + 1, startX, maxLevel, height, rev));
                startX = res[i].Second;
            }
            if (p.children.Count > 0)
            {
                int last = p.children.Count - 1;
                x = (res[0].First + res[last].First) / 2;
            }
            int realLevel = level;
            if (rev)
            {
                realLevel = height - level;
            }
            Person father, mother;
            if (p.man)
            {
                father = p;
                if (p.partner == -1)
                {
                    mother = new Person(true, false);
                }
                else
                {
                    mother = data.allPeople[p.partner];
                }
            }
            else
            {
                mother = p;
                if (p.partner == -1)
                {
                    father = new Person(true, true);
                }
                else
                {
                    father = data.allPeople[p.partner];
                }
            }
            int pWidth = dWidth;
            if (p.children.Count != 0)
            {
                pWidth += dWidthCouple;
                showCouple(father, mother, x, 10 + realLevel * dHeight);
            }
            else
            {
                showPerson(p, x, 10 + realLevel * dHeight);
            }
            /*PictureBox cur = getPbById(p.id);
            if (p.father != -1 && level + 1 < maxLevel)
            {
                drawConnection(cur, getPbById(p.father));
            }
            if (p.mother != -1 && level + 1 < maxLevel)
            {
                drawConnection(cur, getPbById(p.mother));
            }*/
            Debug.WriteLine(string.Format("lev = {0}, x = {1}", level, x));
            return new Pair<int, int> (x, Math.Max(startX, x + pWidth));
        }

        private string getParametersOfTree(ref int typeOfTree, ref int startId, ref int maxH) 
        {
            if (ancestorsRadioButton.Checked)
            {
                typeOfTree = 1;
            }
            else if (descendantsRadioButton.Checked)
            {
                typeOfTree = 2;
            }
            else
            {
                typeOfTree = 3;
            }
            string s = startPersonComboBox.Text;
            Debug.WriteLine(s);
            startId = -1;
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                if (data.allPeople[i].FullName == s)
                {
                    startId = i;
                    break;
                }
            }
            if (allGenerationsRadioButton.Checked)
            {
                maxH = 100;
            }
            else
            {
                try
                {
                    maxH = Convert.ToInt32(generationsComboBox.Text);
                }
                catch (FormatException)
                {
                    return "Выберите целое число поколений - от 1 до 15";
                }
                if (!(1 <= maxH && maxH <= 15))
                {
                    return "Выберите целое число поколений - от 1 до 15";
                }
            }
            if (startId == -1)
            {
                return "Введенное исходное лицо отсутствует в базе";
            }
            return "";
        }
        private void buildTree()
        {
            int typeOfTree = 0, startId = 0, maxH = 0;
            string error = getParametersOfTree(ref typeOfTree, ref startId, ref maxH);
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            turnOffPanels();
            treePanel.Controls.Clear();
            int h;
            if (typeOfTree == ANCESTORS)
            {
                h = getHeightOfAncestors(data.allPeople[startId], 0);
                buildTreeOfAncestors(data.allPeople[startId], 0, 40, maxH, h, ancestorsToUp);
            }
            else if (typeOfTree == DESCENDANTS)
            {
                h = getHeightOfDescendants(data.allPeople[startId], 0);
                buildTreeOfDescendants(data.allPeople[startId], 0, 40, maxH, h, !ancestorsToUp);
            }
            else if (typeOfTree == HOURGLASS)
            {
                MessageBox.Show("Not implemented yet", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Неизвестный тип дерева", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            treePanel.Visible = true;
            g = treePanel.CreateGraphics();
            buildLinesOfAncestors(data.allPeople[startId], 0, h, ancestorsToUp);
        }

        void PaintEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("!!!");
            if (treePanel.Visible)
            {
                int typeOfTree = 0, startId = 0, maxH = 0; 
                string error = getParametersOfTree(ref typeOfTree, ref startId, ref maxH);
                if (error == "")
                {
                    Debug.WriteLine("Painting#");
                    if (g != null)
                    {
                        g.Dispose();
                    }
                    g = treePanel.CreateGraphics();
                    int h = getHeightOfAncestors(data.allPeople[startId], 0);
                    buildLinesOfAncestors(data.allPeople[startId], 0, h, ancestorsToUp);
                }
                else
                {
                    Debug.WriteLine(String.Format("Painting@{0}@", error));
                }
            }
        }

        private void деревоПредковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buildTree();
        }

        private void отцаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson();
            if (p.First == true)
            {
                Debug.WriteLine(p.Second.BasicInfo());
                chosenPerson.father = p.Second.id;
                buildTree();
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson(chosenPerson.id);
            if (p.First == true)
            {
                buildTree();
            }
        }

        private void матьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson(-1, false);
            if (p.First == true)
            {
                Debug.WriteLine(p.Second.BasicInfo());
                chosenPerson.mother = p.Second.id;
                buildTree();
            }
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

        private void деревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffPanels();
            treeSettingsPanel.Visible = true;
            startPersonComboBox.Items.Clear();
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                Debug.WriteLine(i);
                startPersonComboBox.Items.Add(data.allPeople[i].FullName);
            }
            startPersonComboBox.Text = "Асландуков Матвей Николаевич";
        }

        private void limitToRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (limitToRadioButton.Checked)
            {
                generationsComboBox.Visible = true;
            }
            else
            {
                generationsComboBox.Visible = false;
            }
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            buildTree();
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
