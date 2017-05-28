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
        const int dWidth = 200, dWidthCouple = 150, dHeight = 150, dText = 20, hLine = 10;
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
        }

        public void AddPerson(Person p)
        {
            data.AddPerson(p);
        }

        private void turnOffPanels()
        {
            dataGridView.Visible = false;
            treePanel2.Visible = false;
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
                fillStartPersonComboBox();
            }
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tryAddPerson(-1);
            showActivePanel();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            data.save();
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

        private Pair<bool, Person> tryAddPerson(int id = -1, bool man = true, bool fixedGender = false)
        {
            AddPerson myForm = new AddPerson(this, id);
            if (!man)
            {
                myForm.enableWoman();
            }
            if (fixedGender)
            {
                myForm.fixGender();
            }
            DialogResult res = myForm.ShowDialog();
            if (res == DialogResult.OK)
            {
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
                ToolStripMenuItem tAdd = (ToolStripMenuItem) addConneсtionStrip.Items[0];
                ToolStripMenuItem fromDataBase = (ToolStripMenuItem) tAdd.DropDownItems[0];
                ToolStripMenuItem newPerson = (ToolStripMenuItem) tAdd.DropDownItems[1];
                if (chosenPerson.man)
                {
                    fromDataBase.DropDownItems[6].Text = "Жену";
                    newPerson.DropDownItems[6].Text = "Жену";
                }
                else
                {
                    fromDataBase.DropDownItems[6].Text = "Мужа";
                    newPerson.DropDownItems[6].Text = "Мужа";
                }
                addConneсtionStrip.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void drawLine(params Point[] p)
        {
            if (p.Length == 0)
            {
                Debug.WriteLine("FAIL, array is empty");
                return;
            }
            Pen pen = new Pen(Color.Gray, 2);
            for (int i = 0; i + 1 < p.Length; ++i)
            {
                int minX = Math.Min(p[i].X, p[i + 1].X);
                int minY = Math.Min(p[i].Y, p[i + 1].Y);
                /*Bitmap bitmap = new Bitmap(Math.Abs(p[i].X - p[i + 1].X) + 2, Math.Abs(p[i].Y - p[i + 1].Y) + 2);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawLine(pen, new Point(p[i].X - minX + 1, p[i].Y - minY + 1), new Point(p[i + 1].X - minX + 1, p[i + 1].Y - minY + 1));
                }*/
                PictureBox pb = new PictureBox();
                //pb.Image = bitmap;
                pb.Left = minX;
                pb.Top = minY;
                pb.Size = new Size(Math.Abs(p[i].X - p[i + 1].X) + 2, Math.Abs(p[i].Y - p[i + 1].Y) + 2);
                pb.BackColor = Color.Gray;
                treePanel.Controls.Add(pb);
            }
        }

        public static Image drawBorder(Image im, bool isDead = false)
        {
            Bitmap bitmap = new Bitmap(im);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 5), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                if (isDead)
                {
                    g.DrawLine(new Pen(Brushes.Black, 4), new Point(0, 20), new Point(20, 0));
                }
            }
            return bitmap;
        }

        private int showPerson(Person p, int x, int y, int maxL = 50)
        {

            Debug.WriteLine(string.Format("({0} {1})", x, y));
            PictureBox pb = new PictureBox();
            pb.Name = "Person" + Convert.ToString(p.id);
            if (!p.incognito)
            {
                pb.Click += new System.EventHandler(showMenu);
            }
            pb.Image = Image.FromFile(p.getPathToAvatar());
            pb.Image = drawBorder(pb.Image, !p.alive);
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
            if (x <= 50)
            {
                maxL = x - 10;
            }
            if (l.Left + maxL < x)
            {
                int dX = x - maxL - l.Left;
                l.Left += dX;
                pb.Left += dX;
            }
            this.treePanel.Controls.Add(pb);
            this.treePanel.Controls.Add(l);
            return l.Left + l.Width;
        }

        private int showCouple(Person father, Person mother, int x, int y)
        {
            int pos = showPerson(father, x, y);
            PictureBox p1 = getPbById(father.id);
            int posX = Math.Max(x + dWidthCouple, p1.Right + 10 + 2 * (pos - p1.Right));
            showPerson(mother, posX, y, (posX - p1.Right) / 2);
            PictureBox p2 = getPbById(mother.id);
            int y1 = (p1.Top + p2.Bottom) / 2;
            drawLine(new Point(p1.Right, y1), new Point(p2.Left, y1));
            return p2.Left - p1.Right;
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

        private void drawConnection(PictureBox p1, PictureBox p2, bool rev, int distToCouple = 0)
        {
            Pen pen = new Pen(Color.Gray, 2);
            int x1 = (p1.Left + p1.Right) / 2;
            int x2 = (p2.Left + p2.Right) / 2;
            if (!rev)
            {
                int y1 = p1.Bottom + dText, f = 0;
                int y2 = p2.Top - 5;
                if (distToCouple != 0)
                {
                    x1 = (p1.Right + p1.Right + distToCouple) / 2;
                    f = p1.Height / 2 + dText;
                    y1 -= f;
                }
                drawLine(new Point(x1, y1), new Point(x1, y1 + f + hLine), new Point(x2, y1 + f + hLine), new Point(x2, y2 - 1));                
            }
            else
            {
                int y1 = p1.Top - 5, f = 0;
                int y2 = p2.Bottom + dText;
                if (distToCouple != 0)
                {
                    x1 = (p1.Right + p1.Right + distToCouple) / 2;
                    f = p1.Height / 2 + 5;
                    y1 += f;
                }
                drawLine(new Point(x1, y1), new Point(x1, y1 - hLine - f), new Point(x2, y1 - hLine - f), new Point(x2, y2));                
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
            int nX = Math.Max(x + dWidth, showPerson(p, x, 10 + realLevel * dHeight) + dWidth / 2);
            PictureBox cur = getPbById(p.id);
            if (isFather)
            {
                drawConnection(cur, getPbById(p.father), rev);
            }
            if (isMother)
            {
                drawConnection(cur, getPbById(p.mother), rev);
            }
            return new Pair<int, int> (x, Math.Max(res1.Second, Math.Max(res2.Second, nX)));
        }

        private Pair<int, int> buildTreeOfDescendants(Person p, int level, int x, int maxLevel, int height, bool rev)
        {
            List<Pair<int, int> > res = new List<Pair<int, int>>();
            int startX = x;
            bool areChildren = (p.children.Count > 0 && level + 1 < maxLevel);
            if (areChildren)
            {
                for (int i = 0; i < p.children.Count; ++i)
                {
                    res.Add(buildTreeOfDescendants(data.allPeople[p.children[i]], level + 1, startX, maxLevel, height, rev));
                    startX = res[i].Second;
                }
            }
            if (areChildren)
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
                    mother.id = int.MaxValue - father.id;
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
                    father.id = int.MaxValue - mother.id;
                }
                else
                {
                    father = data.allPeople[p.partner];
                }
            }
            int pWidth = dWidth, distToCouple = 0;
            if (p.partner != -1 || areChildren)
            {
                distToCouple = showCouple(father, mother, x, 10 + realLevel * dHeight);
                pWidth += distToCouple;
                PictureBox cur = getPbById(father.id);
                pWidth += cur.Width;
            }
            else
            {
                showPerson(p, x, 10 + realLevel * dHeight);
            }
            if (areChildren)
            {
                //Debug.WriteLine(father.FullName + " " + mother.FullName + " " + Convert.ToString(father.id) + " " + Convert.ToString(mother.id));
                PictureBox cur = getPbById(father.id);
                for (int i = 0; i < p.children.Count; ++i)
                {
                    drawConnection(cur, getPbById(data.allPeople[p.children[i]].id), rev, distToCouple);
                }
            }
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
            string tp = "Предки";
            if (typeOfTree == DESCENDANTS)
            {
                tp = "Потомки";
            }
            else if (typeOfTree == HOURGLASS)
            {
                tp = "Песочные часы";
            }
            treePanel2.Text = data.allPeople[startId].ShortName + ": " + tp;
            if (typeOfTree == ANCESTORS)
            {
                h = Math.Min(maxH - 1, getHeightOfAncestors(data.allPeople[startId], 0));
                buildTreeOfAncestors(data.allPeople[startId], 0, 40, maxH, h, ancestorsToUp);
            }
            else if (typeOfTree == DESCENDANTS)
            {
                h = Math.Min(maxH - 1, getHeightOfDescendants(data.allPeople[startId], 0));
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
            treePanel2.Visible = true;
            treePanel.Visible = true;
        }
       
        private void деревоПредковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buildTree();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson(chosenPerson.id);
            if (p.First == true)
            {
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

        private void fillStartPersonComboBox()
        {
            startPersonComboBox.Items.Clear();
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                Debug.WriteLine(i);
                startPersonComboBox.Items.Add(data.allPeople[i].FullName);
            }
            if (startPersonComboBox.Text == "")
            {
                startPersonComboBox.Text = "Асландуков Матвей Николаевич";
            }
        }

        private void деревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffPanels();
            treeSettingsPanel.Visible = true;
            fillStartPersonComboBox();
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

        private bool isMale(string s, bool male)
        {
            return s == "father" || s == "son" || s == "brother" || (s == "partner" && !male);
        }

        private bool dfs(int v1, int v2, bool[] used)
        {
            if (v1 == v2)
            {
                return true;
            }
            if (v1 == -1 || used[v1])
            {
                return false;
            }
            used[v1] = true;
            Person p = data.allPeople[v1];
            bool res = dfs(p.father, v2, used);
            res |= dfs(p.mother, v2, used);
            res |= dfs(p.partner, v2, used);
            for (int i = 0; i < p.children.Count; ++i)
            {
                res |= dfs(p.children[i], v2, used);
            }
            for (int i = 0; i < p.siblings.Count; ++i)
            {
                res |= dfs(p.siblings[i], v2, used);
            }
            return res;
        }

        private bool pathExists(int v1, int v2)
        {
            bool[] used = new bool[data.allPeople.Count];
            for (int i = 0; i < used.Length; ++i)
            {
                used[i] = false;
            }
            return dfs(v1, v2, used);
        }

        private void addConnection(Person chosenPerson, string typeOfConnection, bool fromDataBase)
        {
            if ((typeOfConnection == "father" && chosenPerson.father != -1) || (typeOfConnection == "mother" && chosenPerson.mother != -1) || (typeOfConnection == "partner" && chosenPerson.partner != -1))
            {
                string tp = "отец";
                if (typeOfConnection == "mother")
                {
                    tp = "мать";
                }
                else if (typeOfConnection == "partner")
                {
                    tp = "муж";
                    if (chosenPerson.man)
                    {
                        tp = "жена";
                    }
                }
                DialogResult res = MessageBox.Show("У данной персноны уже есть " + tp + ". Хотите заменить?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            int addedId = -1;
            if (fromDataBase) 
            {
                SearchPerson myForm = new SearchPerson(this, isMale(typeOfConnection, chosenPerson.man));
                DialogResult res = myForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    addedId = myForm.resId;
                }
            }
            else
            {
                Pair<bool, Person> p = tryAddPerson(-1, isMale(typeOfConnection, chosenPerson.man), true);
                if (p.First)
                {
                    addedId = p.Second.id;
                }
            }
            if (addedId == -1)
            {
                return;
            }
            if (pathExists(chosenPerson.id, addedId))
            {
                DialogResult res = MessageBox.Show("Невозможно добавить связь, т.к. данные персоны уже косвенно связаны между собой", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            switch (typeOfConnection)
            {
                case "father":
                    chosenPerson.father = addedId;
                    break;
                case "mother":
                    chosenPerson.mother = addedId;
                    break;
                case "partner":
                    chosenPerson.partner = addedId;
                    break;
                case "son":
                    chosenPerson.children.Add(addedId);
                    break;
                case "daughter":
                    chosenPerson.children.Add(addedId);
                    break;
                case "brother":
                    chosenPerson.siblings.Add(addedId);
                    break;
                case "sister":
                    chosenPerson.siblings.Add(addedId);
                    break;
                default:
                    Debug.WriteLine("FAIL, unknown type of connection: " + typeOfConnection);
                    break;
            }
            Debug.WriteLine(string.Format("added id = {0}", addedId));
            data.updateConnections();
            buildTree();
        }

        private void отцаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "father", true);
        }

        private void матьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "mother", true);
        }

        private void сынаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "son", true);
        }

        private void дочьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "daughter", true);
        }

        private void братаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "brother", true);
        }

        private void сеструToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "sister", true);
        }

        private void партнераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "partner", true);
        }

        private void отцаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "father", false);
        }


        private void матьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "mother", false);
        }

        private void сынаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "son", false);
        }

        private void дочьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "daughter", false);
        }

        private void братаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "brother", false);
        }

        private void сеструToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "sister", false);
        }

        private void партнераToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "partner", false);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.save();
            DialogResult res = MessageBox.Show("Изменения успешно сохранены.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти?\nВсе изменения будут сохранены.", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
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
