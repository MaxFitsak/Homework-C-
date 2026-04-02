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

        public int Difference(Date other)
        {
            return Math.Abs(this.GetTotalDays() - other.GetTotalDays());
        }

        private int GetDaysInCurrentMonth()
        {
            if (month == 2 && IsLeap(year)) return 29;
            return daysInMonth[month];
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

         public void AddDays(int count)
        {
            day += count;
            while (day > GetDaysInCurrentMonth())
            {
                day -= GetDaysInCurrentMonth();
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }
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

        public void Print()
        {
            Console.WriteLine("{0}:{1}:{2} Day -> {3}", day, month, year, GetDayOfWeek());
        }
    }
}