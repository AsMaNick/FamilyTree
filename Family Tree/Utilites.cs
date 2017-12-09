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
using System.Threading;
using System.IO;

namespace Family_Tree
{
    class Utilites
    {
        public static List<T> distinct<T>(List<T> a)
        {
            List<T> res = new List<T>();
            IEnumerable<T> b = a.Distinct();
            foreach (T x in b)
            {
                res.Add(x);
            }
            return res;
        }

        public static string DeleteCharachter(string s, char c) 
        {
            string res = "";
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != c)
                {
                    res += s[i];
                }
            }
            return res;
        }

        public static bool Contains(string a, string b, bool deleteSpaces = true)
        {
            if (deleteSpaces) 
            {
                a = DeleteCharachter(a, ' ');
                b = DeleteCharachter(b, ' ');
            }
            return a.Contains(b);
        }

        public static int GetMonth(string month, ComboBox BirthMonth)
        {
            if (month == "")
            {
                return 0;
            }
            for (int i = 0; i < BirthMonth.Items.Count; ++i)
            {
                if (BirthMonth.Items[i].ToString() == month)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public static bool MyTryParse(string s, out int x)
        {
            if (s == "")
            {
                x = 0;
                return true;
            }
            return int.TryParse(s, out x);
        }

        public static bool dateExists(int y, int m, int d)
        {
            if (d == 0)
            {
                return true;
            }
            if (m == 0)
            {
                return 1 <= d && d <= 31;
            }
            --m;
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (Date.leapYear(y))
            {
                ++days[1];
            }
            return d >= 1 && d <= days[m];
        }

        public static Date GetDate(TextBox Day, ComboBox Month, TextBox Year)
        {
            int d, m, y;
            bool okDay = MyTryParse(Day.Text, out d);
            m = GetMonth(Month.Text, Month);
            bool okYear = MyTryParse(Year.Text, out y);
            if (okDay && m != -1 && okYear)
            {
                if (y >= 0 && y < 3000 && dateExists(y, m, d))
                {
                    return new Date(y, m, d);
                }
            }
            throw new System.ArgumentException("Wrong field");
        }

        public static Date readDate(ref StreamReader input)
        {
            string[] s = input.ReadLine().Split(' ');
            int day = Int32.Parse(s[0]);
            int month = Int32.Parse(s[1]);
            int year = Int32.Parse(s[2]);
            Date d = new Date(year, month, day);
            return d;
        }

        public static void FillDate(TextBox Day, ComboBox Month, TextBox Year, Date d)
        {
            if (d.Day != 0)
            {
                Day.Text = Convert.ToString(d.Day);
            }

            if (d.Month != 0)
            {
                Month.Text = Month.Items[d.Month - 1].ToString();
            }

            if (d.Year != 0)
            {
                Year.Text = Convert.ToString(d.Year);
            }
        }

        public static DateTime GetDateTime(Date d) 
        {
            int year = 1, month = 1, day = 1;
            if (d.Year > 0) {
                year = d.Year;
            }
            if (d.Month > 0) {
                month = d.Month;
            }
            if (d.Day > 0) {
                day = d.Day;
            }
            return new DateTime(year, month, day);
        }
    }
}
