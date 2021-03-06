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
using System.IO;

namespace Family_Tree
{
    //Основная форма
    public partial class MainPage : Form
    {
        const int dWidth = 200;//Расстояние между двумя персонами при отображении дерева
        const int dWidthCouple = 150;//Растояние между родителями при отображении дерева потомков
        const int dHeight = 150;//Высота одного уровня
        const int dText = 20;//Высота текста ФИО при отображении дерева
        const int hLine = 30 - dText;//Вертикальный отступ линии от изображения
        const int ANCESTORS = 1;//Тип дерева предков
        const int DESCENDANTS = 2;//Тип дерева потомков
        const int HOURGLASS = 3;//Тип дерева песочные часы
        const bool ancestorsToUp = true;//Константа, указывающая в какую сторону отображать дерево предков (вверх/вниз)
        const string runningFile = "running.txt";

        public DataBase data;//База всех персон
        private Person chosenPerson;//Выбранный человек для дальнейшого редактирования
        private Graphics g;
        private Scroll treeScroll;

        //Конструктор, вызываемый при создании формы
        public MainPage()
        {
            InitializeComponent();
            if (System.IO.File.Exists(runningFile))
            {
                MessageBox.Show("Другая программа уже запущена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.OK;
                return;
            }
            System.IO.File.Create(runningFile).Close();
            data = new DataBase();
            turnOffPanels();
            dataGridView.Visible = true;
            UpdateBirthPlaceParameter();
            DrawGridView();
            enableSavingTree(false);

            treeScroll = new Scroll();
            treePanel.MouseDown += treeScroll.MouseDown;
            treePanel.MouseMove += treeScroll.MouseMove;
            treePanel.MouseUp += treeScroll.MouseUp;
            //System.Diagnostics.Process.Start("..\\..\\images/avatars/26.jpg");
        }

        //Метод добавления нового человека в базу
        public void AddPerson(Person p)
        {
            data.AddPerson(p);
        }

        //Метод, рисующий границу на фотографии
        public static Image drawBorder(Image im, bool isDead = false)
        {
            Bitmap bitmap = new Bitmap(im);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawRectangle(new Pen(Brushes.Gray, 5), new Rectangle(0, 0, bitmap.Width - 1, bitmap.Height - 1));
                if (isDead)
                {
                    g.DrawLine(new Pen(Brushes.Black, 4), new Point(0, 20), new Point(20, 0));
                }
            }
            return bitmap;
        }

        //Метод, разрещающий сохранять построенное дерево в файл
        private void enableSavingTree(bool value)
        {
            ToolStripMenuItem file = (ToolStripMenuItem)mainMenuStrip.Items[0];
            file.DropDownItems[1].Visible = value;
        }

        //Метод, делающей все панели невидимыми
        private void turnOffPanels()
        {
            dataGridView.Visible = false;
            treeGroupBox.Visible = false;
            treePanel.Visible = false;
            treeSettingsPanel.Visible = false;
            enableSavingTree(false);
            SearchParameters.Visible = false;
            treePanel.Controls.Clear();
        }

        //Метод, перерисовывающий активную панель
        private void showActivePanel()
        {
            if (dataGridView.Visible)
            {
                UpdateBirthPlaceParameter();
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

        //Метод, позволяющий добавить нового человека в базу
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tryAddPerson(-1);
            showActivePanel();
        }

        private void processBeforeExiting()
        {
            data.save();
            System.IO.File.Delete(runningFile);
        }

        //Метод, срабатывающий при закрытии окна; сохраняет данные
        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти?\nВсе изменения будут сохранены.", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            processBeforeExiting();
        }

        private string Number(int x, int len)
        {
            string s = Convert.ToString(x);
            while (s.Length < len)
            {
                s = "0" + s;
            }
            return s;
        }

        private void UpdateBirthPlaceParameter()
        {
            BirthPlaceParameter.Items.Clear();
            foreach (string place in Utilites.GetAllBirthPlaces(data))
            {
                if (place != "")
                {
                    BirthPlaceParameter.Items.Add(place);
                }
            }
        }

        private void ClearSearchParameters()
        {
            posSearch = 0;
            UpdateBirthPlaceParameter();
            FullNameParameter.Text = "";
            BirthPlaceParameter.Text = "";
            BirthDayParameterL.Text = "";
            BirthMonthParameterL.Text = "";
            BirthYearParameterL.Text = "";
            BirthDayParameterR.Text = "";
            BirthMonthParameterR.Text = "";
            BirthYearParameterR.Text = "";
            AnyRadioButton.Checked = true;
        }

        private int GenderParameter()
        {
            if (WomanRadioButton.Checked)
            {
                return 0;
            }
            if (ManRadioButton.Checked)
            {
                return 1;
            }
            return 2; // any
        }

        private bool isSatisfied(Person p)
        {
            if (!Utilites.Contains(p.FullName, FullNameParameter.Text))
            {
                return false;
            }
            if (!Utilites.Contains(p.birthPlace, BirthPlaceParameter.Text))
            {
                return false;
            }
            try
            {
                Date from = Utilites.GetDate(BirthDayParameterL, BirthMonthParameterL, BirthYearParameterL);
                Date to = Utilites.GetDate(BirthDayParameterR, BirthMonthParameterR, BirthYearParameterR);
                from = Date.dateMinimize(from);
                to = Date.dateMaximize(to);
                if (!(from <= p.birthDate && p.birthDate <= to)) {
                    return false;
                }    
            } catch (Exception e) 
            {
                return false;
            }
            int gender = GenderParameter();
            if (gender != 2 && gender != Convert.ToInt32(p.man))
            {
                return false;
            }
            return true;
        }

        private string lastName = "", lastBirthPlace = "";
        private Date lastDateL = new Date(0, 0, 0), lastDateR = new Date(0, 0, 0);
        private int lastGender = -1;

        private bool changedSearchParameters()
        {
            string nlastName, nlastBirthPlace;
            Date nlastDateL, nlastDateR;
            int nlastGender;
            nlastName = FullNameParameter.Text;
            nlastBirthPlace = BirthPlaceParameter.Text;
            try
            {
                nlastDateL = Utilites.GetDate(BirthDayParameterL, BirthMonthParameterL, BirthYearParameterL);
                nlastDateR = Utilites.GetDate(BirthDayParameterR, BirthMonthParameterR, BirthYearParameterR);
            }
            catch (Exception e)
            {
                return true;
            }
            nlastGender = GenderParameter();
            bool res = (lastName == nlastName) && 
                (lastBirthPlace == nlastBirthPlace) && 
                (lastDateL == nlastDateL) &&
                (lastDateR == nlastDateR) && 
                (lastGender == nlastGender);
            lastName = nlastName;
            lastBirthPlace = nlastBirthPlace;
            lastDateL = nlastDateL;
            lastDateR = nlastDateR;
            lastGender = nlastGender;
            return !res;
        }

        //Метод, перерисовывающий список всех персон из базы
        private void DrawGridView()
        {
            SearchParameters.Visible = true;
            updateSizeGridView();
            treePanel.Controls.Clear();
            dataGridView.Visible = false;
            dataGridView.Rows.Clear();
            Cursor = Cursors.WaitCursor;
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                if (!isSatisfied(data.allPeople[i]))
                {
                    continue;
                }
                int num = dataGridView.Rows.Count;
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[num].Cells[0].Value = Number(i + 1, 4);
                dataGridView.Rows[num].Cells[1].Value = data.allPeople[i].FullNameYears;
                dataGridView.Rows[num].Cells[2].Value = data.allPeople[i].birthPlace;
                dataGridView.Rows[num].Cells[0].Tag = new ID(i);
                dataGridView.Rows[num].ReadOnly = true;
            }
            dataGridView.Visible = true;
            posSearch = dataGridView.Rows.Count;
            Cursor = Cursors.Default;
            if (data.allPeople.Count > 0 && dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("К сожалению, ни одной персоны, удовлетворяющей заданным критериям поиска, найдено не было", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView.Focus();
        }

        //Метод, срабатывающий при выборе пункта База - Поиск; отображает таблицу всех персон
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffPanels();
            dataGridView.Visible = true;
            DrawGridView();
        }

        //Метод получения id заданной персоны в базе
        private int getId(int rowIndex)
        {
            return Int32.Parse(dataGridView.Rows[rowIndex].Cells[0].Tag.ToString());
        }

        //Метод, создающий новую форму добавления нового человека; возвращает true если новый человек успешно добавлен
        private Pair<bool, Person> tryAddPerson(int id = -1, bool man = true, bool fixedGender = false)
        {
            Cursor = Cursors.WaitCursor;
            AddPerson myForm = new AddPerson(this, id);
            Cursor = Cursors.Default;
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

        //Метод, срабатывающийся при двойном клике на персону; отображает информацию
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Double Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < 2)
            {
                Pair<bool, Person> p = tryAddPerson(getId(e.RowIndex));
                DrawGridView();
            }
        }

        //Метод, срабатывающийся при клике на ячейку таблицы
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
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

        //Метод, показывающий всплывающее меню
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
                    fromDataBase.DropDownItems[7].Text = "Бывшую жену";
                    newPerson.DropDownItems[7].Text = "Бывшую жену";
                }
                else
                {
                    fromDataBase.DropDownItems[6].Text = "Мужа";
                    newPerson.DropDownItems[6].Text = "Мужа";
                    fromDataBase.DropDownItems[7].Text = "Бывшего мужа";
                    newPerson.DropDownItems[7].Text = "Бывшего мужа";
                }
                if (chosenPerson.partner == -1)
                {
                    addConneсtionStrip.Items[3].Visible = false;
                }
                else
                {
                    addConneсtionStrip.Items[3].Visible = true;
                }
                if (chosenPerson.divorced)
                {
                    addConneсtionStrip.Items[3].Text = "Заключить брак";
                }
                else
                {
                    addConneсtionStrip.Items[3].Text = "Рассторгнуть брак";
                }
                addConneсtionStrip.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        //Метод рисующий соединение между людьми при отображении дерева
        private void drawLine(int typeOfConnection, params Point[] p)
        {
            if (p.Length == 0)
            {
                Debug.WriteLine("FAIL, array is empty");
                return;
            }
            Pen pen = new Pen(Color.Gray, 2);
            if (typeOfConnection == 1)
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            else
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }
            for (int i = 0; i + 1 < p.Length; ++i)
            {
                int minX = Math.Min(p[i].X, p[i + 1].X);
                int minY = Math.Min(p[i].Y, p[i + 1].Y);
                Bitmap bitmap = new Bitmap(Math.Abs(p[i].X - p[i + 1].X) + 2, Math.Abs(p[i].Y - p[i + 1].Y) + 2);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawLine(pen, new Point(p[i].X - minX + 1, p[i].Y - minY + 1), new Point(p[i + 1].X - minX + 1, p[i + 1].Y - minY + 1));
                }
                PictureBox pb = new PictureBox();
                pb.Image = bitmap;
                pb.Left = minX;
                pb.Top = minY;
                pb.Size = new Size(Math.Abs(p[i].X - p[i + 1].X) + 2, Math.Abs(p[i].Y - p[i + 1].Y) + 2);
                if (typeOfConnection == 0)
                {
                    pb.BackColor = Color.Gray;
                }
                else
                {
                    pb.BackColor = Color.Transparent;
                }
                treePanel.Controls.Add(pb);
            }
        }

        //Метод, рисующий основную информацию о челевоке при построении дерева
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
            if (!p.incognito)
            {
                pb.MouseEnter += photo_MouseEnter;
                pb.MouseLeave += photo_MouseLeave;
                pb.MouseClick += pb_MouseClick;
            }
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

        void treePanel_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        void treePanel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        void photo_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        void photo_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        void pb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                Person pers = (Person)pb.Tag;
                if (pers.incognito)
                {
                    return;
                }
                string oldStartPerson = pers.FullNameYears;
                Pair<bool, Person> p = tryAddPerson(pers.id);
                if (oldStartPerson == startPersonComboBox.Text)
                {
                    startPersonComboBox.Text = data.allPeople[pers.id].FullNameYears;
                }
                if (p.First == true)
                {
                    Point pos = new Point(treePanel.AutoScrollPosition.X, treePanel.AutoScrollPosition.Y);
                    buildTree();
                    treePanel.AutoScrollPosition = new Point(-pos.X, -pos.Y);
                }
            }
        }

        //Метод, рисующий основную информацию о родителях при построении дерева
        private int showCouple(Person father, Person mother, int x, int y, bool divorced)
        {
            int pos = showPerson(father, x, y);
            PictureBox p1 = getPbById(father.id);
            int posX = Math.Max(x + dWidthCouple, p1.Right + 10 + 2 * (pos - p1.Right));
            showPerson(mother, posX, y, (posX - p1.Right) / 2);
            PictureBox p2 = getPbById(mother.id);
            int y1 = (p1.Top + p2.Bottom) / 2;
            drawLine(Convert.ToInt32(divorced), new Point(p1.Right, y1), new Point(p2.Left, y1));
            return p2.Left - p1.Right;
        }

        //Метод, получающий заданые элемент по его id
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

        //Метод, рисующий связь между двумя задаными людьми
        private void drawConnection(PictureBox p1, PictureBox p2, bool rev, int distToCouple, int typeOfConnection = 0)
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
                    Debug.WriteLine("x1 = {0} {1}", x1, "!");
                    f = p1.Height / 2 + dText;
                    y1 -= f;
                }
                drawLine(typeOfConnection, new Point(x1, y1), new Point(x1, y1 + f + hLine), new Point(x2, y1 + f + hLine), new Point(x2, y2 - 1));
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
                drawLine(typeOfConnection, new Point(x1, y1), new Point(x1, y1 - hLine - f), new Point(x2, y1 - hLine - f), new Point(x2, y2));
            }
        }

        //Метод, определяющий высоту дерева предков
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

        //Метод определяющий высоту дерева потомков
        private int getHeightOfDescendants(Person p, int level)
        {
            int res = level;
            for (int i = 0; i < p.children.Count; ++i)
            {
                res = Math.Max(res, getHeightOfDescendants(data.allPeople[p.children[i]], level + 1));
            }
            return res;
        }

        //Метод строящий дерево предков
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
                drawConnection(cur, getPbById(p.father), rev, 0);
            }
            if (isMother)
            {
                drawConnection(cur, getPbById(p.mother), rev, 0);
            }
            return new Pair<int, int> (x, Math.Max(res1.Second, Math.Max(res2.Second, nX)));
        }

        private Person getPerson(int id, Person p)
        {
            if (id < 0)
            {
                Person res = new Person(true, !p.man);
                res.id = int.MaxValue - p.id;
                return res;
            }
            return data.allPeople[id];
        }
        //Метод, стрящий дерево потомков
        private Pair<int, int> buildTreeOfDescendants(Person p, int level, int x, int maxLevel, int height, bool rev)
        {
            if (p.man)
            {
                int realLevel = level;
                if (rev)
                {
                    realLevel = height - level;
                }
                List<Pair<int, int>> res = new List<Pair<int, int>>();
                int startX = x, lastPartner = -2, firstX = -1, lastX = x - dWidth;
                bool areChildren = false;
                bool[] shownPartners = new bool[p.allPartners.Count];
                SortedDictionary<int, int> nextX = new SortedDictionary<int, int>();
                List<int> allPartners = new List<int>();
                List<int> allXs = new List<int>();
                for (int i = 0; i <= p.children.Count; ++i)
                {
                    int pPartner = -2;
                    if (i < p.children.Count)
                    {
                        pPartner = data.allPeople[p.children[i]].father;
                        if (p.man)
                        {
                            pPartner = data.allPeople[p.children[i]].mother;
                        }
                        if (pPartner == p.partner)
                        {
                            areChildren = true;
                            continue;
                        }
                    }
                    if (pPartner != lastPartner)
                    {
                        if (firstX != -1)
                        {
                            lastX = Math.Max(lastX + dWidth, (firstX + startX) / 2);
                            allPartners.Add(lastPartner);
                            allXs.Add(lastX);
                            showPerson(getPerson(lastPartner, p), lastX, 10 + realLevel * dHeight);
                            for (int j = 0; j < p.allPartners.Count; ++j)
                            {
                                if (lastPartner == p.allPartners[j])
                                {
                                    shownPartners[j] = true;
                                }
                            }
                        }
                        firstX = -1;
                    }
                    startX = Math.Max(startX, lastX + dWidth);
                    if (i == p.children.Count)
                    {
                        break;
                    }
                    lastPartner = pPartner;
                    Pair<int, int> ch = buildTreeOfDescendants(data.allPeople[p.children[i]], level + 1, startX, maxLevel, height, rev);
                    startX = ch.Second;
                    if (firstX == -1)
                    {
                        firstX = ch.First;
                    }
                }
                for (int i = 0; i + 1 < allPartners.Count; ++i)
                {
                    nextX[allPartners[i]] = allXs[i + 1];
                }
                for (int i = 0; i < p.allPartners.Count; ++i)
                {
                    if (!shownPartners[i] && p.allPartners[i] != p.partner)
                    {
                        lastX = Math.Max(40, lastX + dWidth);
                        nextX[lastPartner] = lastX;
                        lastPartner = p.allPartners[i];
                        showPerson(getPerson(p.allPartners[i], p), lastX, 10 + realLevel * dHeight);
                    }
                }
                areChildren &= (p.children.Count > 0 && level + 1 < maxLevel);
                int firstChildrenX = int.MaxValue;
                if (areChildren)
                {
                    for (int i = 0; i < p.children.Count; ++i)
                    {
                        int pPartner = data.allPeople[p.children[i]].father;
                        if (p.man)
                        {
                            pPartner = data.allPeople[p.children[i]].mother;
                        }
                        if (pPartner == p.partner)
                        {
                            firstChildrenX = Math.Min(firstChildrenX, startX);
                            res.Add(buildTreeOfDescendants(data.allPeople[p.children[i]], level + 1, startX, maxLevel, height, rev));
                            startX = res[res.Count - 1].Second;
                        }
                    }
                }
                if (areChildren)
                {
                    int last = res.Count - 1;
                    x = (res[0].First + res[last].First) / 2;
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
                x = Math.Max(x, lastX + dWidth);
                PictureBox cur;
                if (p.partner != -1 || areChildren)
                {
                    distToCouple = showCouple(father, mother, x, 10 + realLevel * dHeight, p.divorced);
                    pWidth += distToCouple;
                    cur = getPbById(father.id);
                    pWidth += cur.Width;
                }
                else
                {
                    showPerson(p, x, 10 + realLevel * dHeight);
                    if (p.man)
                    {
                        cur = getPbById(father.id);
                    }
                    else
                    {
                        cur = getPbById(mother.id);
                    }
                }
                nextX[lastPartner] = cur.Left;
                for (int i = 0; i < p.allPartners.Count; ++i)
                {
                    PictureBox to = getPbById(data.allPeople[p.allPartners[i]].id);
                    if (p.allPartners[i] != p.partner)
                    {
                        drawLine(1, new Point(cur.Left, cur.Top + cur.Height / 2), new Point(to.Right, to.Top + to.Height / 2));
                    }
                }
                for (int i = 0; i < p.children.Count; ++i)
                {
                    int pPartner = data.allPeople[p.children[i]].father;
                    if (p.man)
                    {
                        pPartner = data.allPeople[p.children[i]].mother;
                    }
                    if (pPartner == p.partner)
                    {
                        drawConnection(cur, getPbById(data.allPeople[p.children[i]].id), rev, distToCouple);
                    }
                    else
                    {
                        PictureBox to = getPbById(getPerson(pPartner, p).id);
                        drawLine(1, new Point(cur.Left, cur.Top + cur.Height / 2), new Point(to.Right, to.Top + to.Height / 2));
                        int dist = cur.Left - to.Right - (nextX[pPartner] - to.Right) / 2;
                        dist += cur.Width;
                        Debug.WriteLine("{0} {1}", dist, -firstChildrenX + cur.Left + dWidth / 2);
                        dist = Math.Max(dist, -firstChildrenX + cur.Left + dWidth / 2);
                        dist *= 2;
                        drawConnection(cur, getPbById(data.allPeople[p.children[i]].id), rev, -dist, 0);
                    }
                }
                return new Pair<int, int>(x, Math.Max(startX, x + pWidth));
            }
            else // Copy Paste...
            {
                int realLevel = level;
                if (rev)
                {
                    realLevel = height - level;
                }
                List<Pair<int, int>> res = new List<Pair<int, int>>();
                int startX = x, lastPartner = -2, firstX = -1, lastX = x - dWidth;
                bool areChildren = false;
                bool[] shownPartners = new bool[p.allPartners.Count];
                SortedDictionary<int, int> prevX = new SortedDictionary<int, int>();
                for (int i = 0; i <= p.children.Count; ++i)
                {
                    int pPartner = -2;
                    if (i < p.children.Count)
                    {
                        pPartner = data.allPeople[p.children[i]].father;
                        if (p.man)
                        {
                            pPartner = data.allPeople[p.children[i]].mother;
                        }
                        if (pPartner == p.partner)
                        {
                            areChildren = true;
                            continue;
                        }
                    }
                }
                areChildren &= (p.children.Count > 0 && level + 1 < maxLevel);
                if (areChildren)
                {
                    for (int i = 0; i < p.children.Count; ++i)
                    {
                        int pPartner = data.allPeople[p.children[i]].father;
                        if (p.man)
                        {
                            pPartner = data.allPeople[p.children[i]].mother;
                        }
                        if (pPartner == p.partner)
                        {
                            res.Add(buildTreeOfDescendants(data.allPeople[p.children[i]], level + 1, startX, maxLevel, height, rev));
                            startX = res[res.Count - 1].Second;
                        }
                    }
                }
                int minXForConnection = startX;
                if (areChildren)
                {
                    int last = res.Count - 1;
                    x = (res[0].First + res[last].First) / 2;
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
                PictureBox cur, curM;
                if (p.partner != -1 || areChildren)
                {
                    distToCouple = showCouple(father, mother, x, 10 + realLevel * dHeight, p.divorced);
                    pWidth += distToCouple;
                    cur = getPbById(father.id);
                    pWidth += cur.Width;
                }
                else
                {
                    showPerson(p, x, 10 + realLevel * dHeight);
                    if (p.man)
                    {
                        cur = getPbById(father.id);
                    }
                    else
                    {
                        cur = getPbById(mother.id);
                    }
                }

                curM = getPbById(mother.id);
                lastX = x + pWidth - dWidth;

                for (int i = 0; i <= p.children.Count; ++i)
                {
                    int pPartner = -2;
                    if (i < p.children.Count)
                    {
                        pPartner = data.allPeople[p.children[i]].father;
                        if (p.man)
                        {
                            pPartner = data.allPeople[p.children[i]].mother;
                        }
                        if (pPartner == p.partner)
                        {
                            areChildren = true;
                            continue;
                        }
                    }
                    if (pPartner != lastPartner)
                    {
                        if (firstX != -1)
                        {
                            prevX[lastPartner] = lastX;
                            lastX = Math.Max(lastX, startX - dWidth);
                            lastX = Math.Max(lastX + dWidth, (firstX + startX) / 2);
                            showPerson(getPerson(lastPartner, p), lastX, 10 + realLevel * dHeight);
                            for (int j = 0; j < p.allPartners.Count; ++j)
                            {
                                if (lastPartner == p.allPartners[j])
                                {
                                    shownPartners[j] = true;
                                }
                            }
                        }
                        firstX = -1;
                    }
                    startX = Math.Max(startX, lastX + dWidth);
                    if (i == p.children.Count)
                    {
                        break;
                    }
                    lastPartner = pPartner;
                    Pair<int, int> ch = buildTreeOfDescendants(data.allPeople[p.children[i]], level + 1, startX, maxLevel, height, rev);
                    startX = ch.Second;
                    if (firstX == -1)
                    {
                        firstX = ch.First;
                    }
                }
                for (int i = 0; i < p.allPartners.Count; ++i)
                {
                    if (!shownPartners[i] && p.allPartners[i] != p.partner)
                    {
                        prevX[p.allPartners[i]] = lastX;
                        lastX = Math.Max(40, lastX + dWidth);
                        lastPartner = p.allPartners[i];
                        showPerson(getPerson(p.allPartners[i], p), lastX, 10 + realLevel * dHeight);
                    }
                }
                for (int i = 0; i < p.allPartners.Count; ++i)
                {
                    PictureBox to = getPbById(data.allPeople[p.allPartners[i]].id);
                    if (p.allPartners[i] != p.partner)
                    {
                        drawLine(1, new Point(curM.Right, curM.Top + curM.Height / 2), new Point(to.Left, to.Top + to.Height / 2));
                    }
                }
                for (int i = 0; i < p.children.Count; ++i)
                {
                    int pPartner = data.allPeople[p.children[i]].father;
                    if (p.man)
                    {
                        pPartner = data.allPeople[p.children[i]].mother;
                    }
                    if (pPartner == p.partner)
                    {
                        drawConnection(cur, getPbById(data.allPeople[p.children[i]].id), rev, distToCouple);
                    }
                    else
                    {
                        PictureBox to = getPbById(getPerson(pPartner, p).id);
                        drawLine(1, new Point(curM.Right, curM.Top + curM.Height / 2), new Point(to.Left, to.Top + to.Height / 2));
                        int dist = to.Left - curM.Right - (to.Left - prevX[pPartner] - curM.Width) / 2;
                        //Debug.WriteLine("{0} {1} {2} {3} !!!", to.Left, prevX[pPartner], curM.Width, dist);
                        dist = Math.Max(dist, minXForConnection - dWidth / 2 + curM.Width / 2 - curM.Right);
                        dist *= 2;
                        drawConnection(curM, getPbById(data.allPeople[p.children[i]].id), rev, dist, 0);
                    }
                }
                return new Pair<int, int>(x, Math.Max(lastX + dWidth, Math.Max(startX, x + pWidth)));
            }
        }

        private int getStartId(string s)
        {
            int startId = -1;   
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                if (data.allPeople[i].FullNameYears == s)
                {
                    startId = i;
                    break;
                }
            }
            return startId;
        }

        //Метод загрузки параметров дерева с формы
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
            startId = getStartId(s);
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

        //Метод построения и отображения дерева на форме
        private void buildTree()
        {
            int typeOfTree = 0, startId = 0, maxH = 0;
            string error = getParametersOfTree(ref typeOfTree, ref startId, ref maxH);
            if (error != "")
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (startId == -1)
                {
                    turnOffPanels();
                    treeSettingsPanel.Visible = true;
                    fillStartPersonComboBox();
                }
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
            treeGroupBox.Text = data.allPeople[startId].ShortName + ": " + tp;
            Cursor = Cursors.WaitCursor;
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
                Cursor = Cursors.Default;
                MessageBox.Show("Not implemented yet", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Неизвестный тип дерева", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor = Cursors.Default;
            treeGroupBox.Visible = true;
            treePanel.Visible = true;
            enableSavingTree(true);
            this.treePanel.Focus();
        }

        //Обработчик события клика на кнопку построения дерева
        private void деревоПредковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buildTree();
        }

        //Обработчик события редактирования персоны
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point pos = new Point(treePanel.AutoScrollPosition.X, treePanel.AutoScrollPosition.Y);
            Pair<bool, Person> p = tryAddPerson(chosenPerson.id);
            if (p.First == true)
            {
                buildTree();
                treePanel.AutoScrollPosition = new Point(-pos.X, -pos.Y);
            }
        }

        //Обработчик события удаления персоны
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point pos = new Point(treePanel.AutoScrollPosition.X, treePanel.AutoScrollPosition.Y);
            int id = chosenPerson.id;
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить информацию о данном человеке?", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                treePanel.AutoScrollPosition = pos;
                data.DeletePerson(id);
                buildTree();
                treePanel.AutoScrollPosition = new Point(-pos.X, -pos.Y);
            }
        }

        //Метод, заполняющий пункты выпадющего списка персон
        private void fillStartPersonComboBox()
        {
            startPersonComboBox.Items.Clear();
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                Debug.WriteLine(i + " " + data.allPeople[i].FullNameYears);
                startPersonComboBox.Items.Add(data.allPeople[i].FullNameYears);
            }
            if (getStartId(startPersonComboBox.Text) == -1)
            {
                startPersonComboBox.Text = "";
                if (startPersonComboBox.Items.Count > 0)
                {
                    startPersonComboBox.Text = (string)startPersonComboBox.Items[0];
                }
            }
        }

        //Обработчик события клика на кнопку работы с деревом
        private void деревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turnOffPanels();
            treeSettingsPanel.Visible = true;
            fillStartPersonComboBox();
        }

        //Метод, отображающий нужные элементы в зависимости от типа ограничения поколений
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

        //Обработчик событий клика на кнопку построить дерево
        private void buildButton_Click(object sender, EventArgs e)
        {
            buildTree();
        }

        //Метод, определяющий пол человека в зависимости от типа связи
        private bool isMale(string s, bool male)
        {
            return s == "father" || s == "son" || s == "brother" || (s == "partner" && !male) || (s == "formerPartner" && !male);
        }

        //Метод проверки связи двух персон; возвращает, true если персоны связаны
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
            if (res) { Debug.WriteLine(p.FullNameYears); return true; }
            res |= dfs(p.partner, v2, used);
            if (res) { Debug.WriteLine(p.FullNameYears); return true; }
            for (int i = 0; i < p.children.Count; ++i)
            {
                res |= dfs(p.children[i], v2, used);
                if (res) { Debug.WriteLine(p.FullNameYears); return true; }
            }
            for (int i = 0; i < p.siblings.Count; ++i)
            {
                res |= dfs(p.siblings[i], v2, used);
                if (res) { Debug.WriteLine(p.FullNameYears); return true; }
            }
            for (int i = 0; i < p.allPartners.Count; ++i)
            {
                res |= dfs(p.allPartners[i], v2, used);
                if (res) { Debug.WriteLine(p.FullNameYears); return true; }
            }
            return res;
        }

        //Метод проверки связи двух персон; возвращает, true если персоны связаны
        private bool pathExists(int v1, int v2)
        {
            bool[] used = new bool[data.allPeople.Count];
            for (int i = 0; i < used.Length; ++i)
            {
                used[i] = false;
            }
            return dfs(v1, v2, used);
        }

        //Метод, позволяющий добавить связь между двумя персонами
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
            bool connected = pathExists(chosenPerson.id, addedId);
            if (connected)
            {
                bool ok = false;
                if (typeOfConnection == "father")
                {
                    if (chosenPerson.mother != -1 && data.allPeople[chosenPerson.mother].allPartners.Contains(addedId))
                    {
                        ok = true;
                    }
                }
                else if (typeOfConnection == "mother")
                {
                    if (chosenPerson.father != -1 && data.allPeople[chosenPerson.father].allPartners.Contains(addedId))
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    DialogResult res = MessageBox.Show("Невозможно добавить связь, т.к. данные персоны уже косвенно связаны между собой", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            switch (typeOfConnection)
            {
                case "father":
                    if (chosenPerson.father != -1)
                    {
                        data.allPeople[chosenPerson.father].children.Remove(chosenPerson.id);
                    }
                    chosenPerson.father = addedId;
                    break;
                case "mother":
                    if (chosenPerson.mother != -1)
                    {
                        data.allPeople[chosenPerson.mother].children.Remove(chosenPerson.id);
                    }
                    chosenPerson.mother = addedId;
                    break;
                case "partner":
                    if (chosenPerson.partner != -1)
                    {
                        data.allPeople[chosenPerson.partner].partner = -1;
                    }
                    chosenPerson.partner = addedId;
                    chosenPerson.allPartners.Add(addedId);
                    data.allPeople[addedId].allPartners.Add(chosenPerson.id);
                    data.allPeople[addedId].partner = chosenPerson.id;
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
                case "formerPartner":
                    chosenPerson.allPartners.Add(addedId);
                    data.allPeople[addedId].allPartners.Add(chosenPerson.id);
                    break;
                default:
                    Debug.WriteLine("FAIL, unknown type of connection: " + typeOfConnection);
                    break;
            }
            Debug.WriteLine(string.Format("added id = {0}", addedId));
            data.updateConnections();
            Point pos = new Point(treePanel.AutoScrollPosition.X, treePanel.AutoScrollPosition.Y);
            buildTree();
            treePanel.AutoScrollPosition = new Point(-pos.X, -pos.Y);
        }

        //Обработчик события клика на пункт меню "из базы/добавить отца"
        private void отцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "father", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить мать"
        private void матьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "mother", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить сына"
        private void сынаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "son", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить дочь"
        private void дочьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "daughter", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить брата"
        private void братаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "brother", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить сестру"
        private void сеструToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "sister", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить партнера"
        private void партнераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "partner", true);
        }

        //Обработчик события клика на пункт меню "из базы/добавить бывшего партнера"
        private void бывшегоПартнераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "formerPartner", true);
        }



        //Обработчик события клика на пункт меню "нового человека/добавить отца"
        private void отцаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "father", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить мать"
        private void матьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "mother", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить сына"
        private void сынаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "son", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить дочь"
        private void дочьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "daughter", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить брата"
        private void братаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "brother", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить сестру"
        private void сеструToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "sister", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить партнера"
        private void партнераToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "partner", false);
        }

        //Обработчик события клика на пункт меню "нового человека/добавить бывшего партнера"
        private void бывшегоПартнераToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            addConnection(chosenPerson, "formerPartner", false);
        }



        //Обработчик события сохранения данных
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.save();
            DialogResult res = MessageBox.Show("Изменения успешно сохранены.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Обработчик события выхода из программы
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            /*DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти?\nВсе изменения будут сохранены.", "Подтверждение операции", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }*/
        }

        //Метод вывода текста на элемент
        private void putText(object sender, PaintEventArgs e)
        {
            PictureBox p = (PictureBox) sender;
            Pair<Font, string> parameters = (Pair<Font, string>) p.Tag;
            TextRenderer.DrawText(e.Graphics, parameters.Second, parameters.First, new Point(0, 0), Control.DefaultForeColor);
        }

        //Метод вывода текста на элемент
        private Bitmap writeText(Size size, Font font, string text)
        {
            PictureBox p = new PictureBox();
            p.Size = size;
            p.Paint += new PaintEventHandler(putText);
            p.Tag = new Pair<Font, string> (font, text);
            treePanel.Controls.Add(p);
            p.Refresh();
            treePanel.Controls.Remove(p);
            Bitmap b = new Bitmap(size.Width, size.Height);
            p.DrawToBitmap(b, new Rectangle(new Point(0, 0), size));
            return b;
        }

        //Метод, генерирующий изображение дерева
        private Bitmap generateTreeImage()
        {
            int scX = -treePanel.AutoScrollPosition.X;
            int scY = -treePanel.AutoScrollPosition.Y;
            Bitmap header = writeText(TextRenderer.MeasureText(treeGroupBox.Text, treeGroupBox.Font), treeGroupBox.Font, treeGroupBox.Text);
            int width = 0, height = 0;
            for (int i = 0; i < treePanel.Controls.Count; ++i)
            {
                Control control = treePanel.Controls[i];
                width = Math.Max(width, control.Right + scX);
                height = Math.Max(height, control.Bottom + scY);
                //Debug.WriteLine(string.Format("{0} {1}", control.GetType(), control.Name));
            }
            width += 20;
            int plY = header.Height * 2;
            height += plY;
            Bitmap bitmap = new Bitmap(width, height + header.Height / 2);
            
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Control.DefaultBackColor);
                g.DrawImage(header, new Point((width - header.Width) / 2, header.Height / 2));
                for (int i = 0; i < treePanel.Controls.Count; ++i)
                {
                    Control control = treePanel.Controls[i];
                    if (control.GetType() == new PictureBox().GetType())
                    {
                        PictureBox p = (PictureBox)control;
                        g.DrawImage(p.Image, new Point(p.Left + scX, p.Top + scY + plY));
                    }
                    else if (control.GetType() == new Label().GetType())
                    {
                        Label l = (Label) control;
                        Bitmap b = writeText(l.Size, l.Font, l.Text);
                        g.DrawImage(b, new Point(l.Left + scX, l.Top + scY + plY));
                    }
                }
            }
            return bitmap;
        }

        //Обработчик события клика на пункт "сохранить дерево в файл"
        private void сохранитьДеревоВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = generateTreeImage();
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "png|*.png";
            DialogResult res = fileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                bitmap.Save(fileDialog.FileName);
            }
        }

        public bool tryAddPhoto()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = Photo.Filter;
            DialogResult res = fileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                Debug.WriteLine(fileDialog.FileName);
                AddPhoto addPhoto = new AddPhoto(fileDialog.FileName, data);
                DialogResult res2 = addPhoto.ShowDialog();
                if (res2 == DialogResult.OK)
                {
                    data.addPhoto(addPhoto.result);
                    return true;
                }
            }
            return false;
        }

        private void добавитьФотографиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tryAddPhoto();
        }

        private void просмотрФотографийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pair<bool, Person> p = tryAddPerson(-2);
        }

        private void updateSizeGridView()
        {
            int len = dataGridView.Width - dataGridView.Columns[0].Width - dataGridView.Columns[3].Width;
            len -= 60;
            len /= 2;
            dataGridView.Columns[1].Width = len;
            dataGridView.Columns[2].Width = len;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            updateSizeGridView();
        }

        private void рассторгнутьБракToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chosenPerson.partner != -1)
            {
                chosenPerson.divorced = !chosenPerson.divorced;
                data.allPeople[chosenPerson.partner].divorced = !data.allPeople[chosenPerson.partner].divorced;
                Point pos = new Point(treePanel.AutoScrollPosition.X, treePanel.AutoScrollPosition.Y);
                buildTree();
                treePanel.AutoScrollPosition = new Point(-pos.X, -pos.Y);
            }
        }

        private int posSearch;

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DrawGridView();
        }

        private void ClearParametersButton_Click(object sender, EventArgs e)
        {
            ClearSearchParameters();
            DrawGridView();
        }

        private void ageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgeStatistic a = new AgeStatistic(data);
            a.ShowDialog();
        }

        private void общаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalReport r = new TotalReport(data);
            r.ShowDialog();
        }

        private void GenericStatisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericStatistic g = new GenericStatistic(data);
            g.ShowDialog();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            DrawGridView();
            posSearch = 0;
        }

        private int findNextPosSearch()
        {
            int res = posSearch;
            bool was_min = false, was_max = false;
            while (true)
            {
                res += 1;
                if (res >= dataGridView.Rows.Count)
                {
                    res = 0;
                }
                if (isSatisfied(data.allPeople[getId(res)]))
                {
                    return res;
                }
                Debug.WriteLine(posSearch);
                if (res == 0)
                {
                    was_min = true;
                }
                if (res + 1 == dataGridView.Rows.Count)
                {
                    was_max = true;
                }
                if (was_min && was_max)
                {
                    break;
                }
            }
            return -1;
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            if (changedSearchParameters())
            {
                posSearch = 0;
            }
            posSearch = findNextPosSearch();
            if (posSearch == -1 || posSearch >= dataGridView.Rows.Count)
            {
                MessageBox.Show("Не было найдено ни одной персоны, удовлетворяющей критериям поиска", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (posSearch == -1)
                {
                    posSearch = 0;
                }
                return;
            }
            if (posSearch < dataGridView.Rows.Count)
            {
                dataGridView.CurrentCell = dataGridView[0, posSearch];
            }
        }
    }

    //Вспомагательный класс, хранящий пару элементов
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
