using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Family_Tree
{
    public partial class AgeStatistic : Form
    {
        public string YearType(int age)
        {
            if (age % 10 == 0 || (5 <= age % 10 && age % 10 <= 9))
            {
                return "лет";
            }
            if (age % 10 == 1)
            {
                return "год";
            }
            if (age % 10 == 2 || age % 10 == 3 || age % 10 == 4)
            {
                return "года";
            }
            return "г.";
        }

        public string BestPerson(Person p) 
        {
            return p.FullName + ", " + Convert.ToString(p.Age()) + " " + YearType(p.Age());
        }

        public AgeStatistic(DataBase data)
        {
            InitializeComponent();
            PeopleByAge.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            int[] from = { 0, 10, 20, 30, 40, 50, 60, 70, 80 };
            int[] to =  { 10, 20, 30, 40, 50, 60, 70, 80, 10000 };
            List<string> titles = new List<string>();
            List<int> cnt = new List<int>();
            for (int i = 0; i < from.Length; ++i)
            {
                if (from[i] == 0)
                {
                    titles.Add(string.Format("до {0}", to[i]));
                }
                else if (to[i] == to[to.Length - 1])
                {
                    titles.Add(string.Format("от {0}", from[i]));
                }
                else
                {
                    titles.Add(string.Format("{0}-{1}", from[i], to[i]));
                }
                cnt.Add(0);
            }
            int bestMan = -1, bestWoman = -1;
            for (int i = 0; i < data.allPeople.Count; ++i)
            {
                int age = data.allPeople[i].Age();
                if (age != -1)
                {
                    if (age > 80)
                    {
                        Debug.WriteLine(age);
                        Debug.WriteLine(data.allPeople[i].FullNameYears);
                    }
                    for (int j = 0; j < to.Length; ++j)
                    {
                        if (age < to[j])
                        {
                            ++cnt[j];
                            break;
                        }
                    }
                    if (data.allPeople[i].man)
                    {
                        if (bestMan == -1 || data.allPeople[bestMan].Age() < age)
                        {
                            bestMan = i;
                        }
                    }
                    else
                    {
                        if (bestWoman == -1 || data.allPeople[bestWoman].Age() < age)
                        {
                            bestWoman = i;
                        }
                    }
                }
            }
            for (int i = 0; i < cnt.Count; ++i)
            {
                Debug.WriteLine(cnt[i]);
            }
            PeopleByAge.Series["ColumnSeries"].Points.DataBindXY(titles, cnt);
            PeopleByAge.ChartAreas[0].Area3DStyle.Enable3D = true;
            Man.Text = "Ни одного мужчины не найдено";
            Woman.Text = "Ни одной женщины не найдено";
            if (bestMan != -1)
            {
                Man.Text = BestPerson(data.allPeople[bestMan]);
            }
            if (bestWoman != -1)
            {
                Woman.Text = BestPerson(data.allPeople[bestWoman]);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
