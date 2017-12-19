using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Family_Tree
{
    public partial class GenericStatistic : Form
    {
        private DataBase data;

        public GenericStatistic(DataBase datab)
        {
            InitializeComponent();
            data = datab;
            FillLabeledPerson(startPersonComboBox);
            int[] fake = {1};
            DrawChart(fake);
        }

        private void FillLabeledPerson(ComboBox c)
        {
            c.Items.Clear();
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                c.Items.Add(data.allPeople[i].FullNameYears);
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

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int startId = getStartId(startPersonComboBox.Text);
            if (startId == -1)
            {
                MessageBox.Show("Введенное исходное лицо отсутствует в базе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool[] used = new bool[data.allPeople.Count];
            int[] generationsCount = new int[data.allPeople.Count];
            int[] cnt = new int[4];
            dfs(startId, used, generationsCount, cnt);
            ManCount.Text = "Количество мужчин в роду: " + Convert.ToString(cnt[0]);
            WomanCount.Text = "Количество женшин в роду: " + Convert.ToString(cnt[1]);
            MaxChildrenCount.Text = "Максимальное количество детей в семье: " + Convert.ToString(cnt[2]);
            DivorcedConunt.Text = "Количество разводов в роду: " + Convert.ToString(cnt[3]);
            DrawChart(generationsCount);
        }

        private void DrawChart(int[] generationsCount)
        {
            PeopleByGeneration.Series.Clear();
            PeopleByGeneration.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            List<string> titles = new List<string>();
            List<int> cnt = new List<int>();
            int mx_gen = 0;
            for (int i = 0; i < generationsCount.Length; ++i)
            {
                if (generationsCount[i] != 0)
                {
                    mx_gen = i;
                }
            }
            for (int i = 0; i <= mx_gen; ++i)
            {
                titles.Add(Convert.ToString(i + 1));
                cnt.Add(generationsCount[i]);
            }
            PeopleByGeneration.Series["ColumnSeries"].Points.DataBindXY(titles, cnt);
            PeopleByGeneration.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void dfs(int v, bool[] used, int[] generationsCount, int[] cnt, int gen = 0)
        {
            if (v == -1 || used[v])
            {
                return;
            }
            used[v] = true;
            Person p = data.allPeople[v];
            if (p.man)
            {
                ++cnt[0];
            }
            else
            {
                ++cnt[1];
            }
            ++generationsCount[gen];
            if (p.man)
            {
                if (p.allPartners.Count > 0)
                {
                    cnt[3] += p.allPartners.Count - 1;
                    if (p.divorced || p.partner == -1)
                    {
                        cnt[3] += 1;
                    }
                }
            }
            cnt[2] = Math.Max(cnt[2], p.children.Count);
            dfs(p.partner, used, generationsCount, cnt, gen);
            for (int i = 0; i < p.children.Count; ++i)
            {
                dfs(p.children[i], used, generationsCount, cnt, gen + 1);
            }
            for (int i = 0; i < p.siblings.Count; ++i)
            {
                dfs(p.siblings[i], used, generationsCount, cnt, gen);
            }
            for (int i = 0; i < p.allPartners.Count; ++i)
            {
                dfs(p.allPartners[i], used, generationsCount, cnt, gen);
            }
        }
    }
}
