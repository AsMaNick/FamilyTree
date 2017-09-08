using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class Date
    {
        public int Year, Month, Day;
        public Date()
        {
            Year = Month = Day = 0;
        }
        public Date(int y, int m, int d)
        {
            Year = y;
            Month = m;
            Day = d;
        }

        public static bool leapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
        }

        public static Date dateMaximize(Date d)
        {
            Date result = new Date(d.Year, d.Month, d.Day);
            if (result.Year == 0)
            {
                result.Year = int.MaxValue;
            }
            if (result.Month == 0)
            {
                result.Month = 12;
            }
            if (result.Day == 0)
            {
                int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                if (leapYear(result.Year))
                {
                    ++days[1];
                }
                result.Day = days[result.Month - 1];
            }
            return result;
        }

        public static Date dateMinimize(Date d)
        {
            Date result = new Date(d.Year, d.Month, d.Day);
            if (result.Year == 0)
            {
                result.Year = int.MinValue;
            }
            if (result.Month == 0)
            {
                result.Month = 1;
            }
            if (result.Day == 0)
            {
                result.Day = 1;
            }
            return result;
        }

        public static bool equal(Date d1, Date d2)
        {
            return d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day;
        }

        public static bool operator < (Date d1, Date d2)
        {
            return d1.Year < d2.Year || (d1.Year ==  d2.Year && d1.Month < d2.Month) || (d1.Year == d2.Year && d1.Month == d2.Month && d1.Day < d2.Day);
        }

        public static bool operator > (Date d1, Date d2) {
            return d2 < d1;
        }
    }
}
