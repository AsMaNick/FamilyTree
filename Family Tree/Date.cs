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
    }
}
