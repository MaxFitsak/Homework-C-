namespace Task
{
    class Date
    {
        int day;
        int month;
        int year;
        private int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


        public int Month
        {
            get { return month; }
            set 
            { 
                if (value < 1 || value > 12)
                    throw new ArgumentException("Місяць має бути від 1 до 12");
                month = value; 
            }
        }  

        public int Year
        {
            get { return year; }
            set 
            { 
                if (value < 1)
                    throw new ArgumentException("Рік не може бути менше 1");
                year = value; 
            }
        }

        public int Day
        {
            get { return day; }
            set 
            {
                int maxDays = GetDaysInMonth(month, year);
                if (value < 1 || value > maxDays)
                    throw new ArgumentException($"День має бути від 1 до {maxDays} для даного місяця");
                day = value; 
            }
        }

        public Date()
        {
            day = 1;
            month = 1;
            year = 1;
        }

        public Date(int _date, int _month, int _year)
        {
            year = _year;
            month = _month;
            day = _date;
        }

        private bool IsLeap(int y) => (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);

        public static int operator -(Date day, Date day2) 
        {
            if (day is null || day2 is null)
                throw new ArgumentNullException("Об'єкти Date не можуть бути null для математичних операцій");

           return Math.Abs(day.GetTotalDays() - day2.GetTotalDays());
        }

        private int GetDaysInMonth(int m, int y)
        {
            if (m < 1 || m > 12) 
                throw new ArgumentOutOfRangeException(nameof(m), "Місяць має бути від 1 до 12");

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
            if (start is null)
                throw new ArgumentNullException("Об'єкти Date не можуть бути null для математичних операцій");

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
            if (d1 is null || d2 is null)
                throw new ArgumentNullException("Об'єкти Date не можуть бути null для математичних операцій");
            return d1.GetTotalDays() > d2.GetTotalDays();
        }

        public static bool operator <(Date d1, Date d2)
        {
            if (d1 is null || d2 is null)
                throw new ArgumentNullException("Об'єкти Date не можуть бути null для математичних операцій");
                
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