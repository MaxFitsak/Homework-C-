using System.Diagnostics;
using System.Numerics;

namespace Fiopl
{
    class Date
    {
        int day;
        int month;
        int year;
        private int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


        public int Day{ set; get; }
        public int Month{ set; get; }
        public int Year{ set; get; }

        public Date()
        {
            day = 1;
            month = 1;
            year = 1;
        }

        public Date(int _date, int _month, int _year)
        {
            day = _date;
            month = _month;
            year = _year;
        }

        private bool IsLeap(int y) => (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);

        public static int operator -(Date day, Date day2) 
        {
           return Math.Abs(day.GetTotalDays() - day2.GetTotalDays());
        }

        private int GetDaysInMonth(int m, int y)
        {
            if (m == 2 && IsLeap(y)) return 29;
            return daysInMonth[m];
        }

        public int GetTotalDays()
        {
            int total = day;
            for (int y = 1; y < year; y++) total += IsLeap(y) ? 366 : 365;
            for (int m = 1; m < month; m++)
            {
                if (m == 2 && IsLeap(year)) total += 29;
                else total += daysInMonth[m];
            }
            return total;
        }

        public static Date operator +(Date start, int count)
        {
            Date res = new Date(start.Day, start.Month, start.Year);
            res.Day += count;

            while (res.Day > res.GetDaysInMonth(res.Month, res.Year))
            {
                res.Day -= res.GetDaysInMonth(res.Month, res.Year);
                res.Month++;
                if (res.Month > 12)
                {
                    res.Month = 1;
                    res.Year++;
                }
            }
            return res;
        }

        public string GetDayOfWeek()
        {
            int d = day, m = month, y = year;
            if (m < 3) { m += 12; y--; }
            int k = y % 100;
            int j = y / 100;
            int h = (d + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
            
            string[] names = { "Saturday", "Sunday", "Monday", "Thuesday", "Wendsay", "Thurday", "Friday" };
            return names[h];
        }

        public static bool operator >(Date d1, Date d2)
        {
            return d1.GetTotalDays() > d2.GetTotalDays();
        }

        public static bool operator <(Date d1, Date d2)
        {
            return d1.GetTotalDays() < d2.GetTotalDays();
        }

        public static bool operator ==(Date d1, Date d2)
        {
            if (ReferenceEquals(d1, d2)) return true;
            if (d1 is null || d2 is null) return false;
            return d1.GetTotalDays() == d2.GetTotalDays();
        }

        public static bool operator !=(Date d1, Date d2)
        {
            return !(d1 == d2);
        }

        public static Date operator ++(Date day) => day + 1;
        public static Date operator --(Date day) => day + (-1);

        public void Print()
        {
            Console.WriteLine("{0}:{1}:{2} Day -> {3}", day, month, year, GetDayOfWeek());
        }
    }
}