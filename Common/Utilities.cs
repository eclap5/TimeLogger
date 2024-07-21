using System.Globalization;

namespace TimeLogger.Common
{
    public class Utilities
    {
        public static int GetWeekNumber(DateOnly? dateOnly)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;

            CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek;
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

            string strDateOnly = dateOnly.ToString()!;
            DateTime date = DateTime.Parse(strDateOnly);
            int weekNum = calendar.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);

            return weekNum;
        }

        public static int GetYear(DateOnly? dateOnly)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            string strDateOnly = dateOnly.ToString()!;
            DateTime date = DateTime.Parse(strDateOnly);
            return calendar.GetYear(date);
        }

        public static string GetWeekDay(DateOnly? date)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            string strDate = date.ToString()!;
            DateTime dateTime = DateTime.Parse(strDate);
            DayOfWeek dayOfWeek = calendar.GetDayOfWeek(dateTime);
            return dayOfWeek.ToString();
        }
    }
}
