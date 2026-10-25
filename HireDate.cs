namespace EmployeeApp;

public class HireDate
{
    private int _day = 1;
    private int _month = 1;
    private int _year = 2000;

    public HireDate() { }

    public HireDate(int day, int month, int year)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentOutOfRangeException(nameof(Year), "Year must be between 1900 and the current year.");
            _year = value;
        }
    }

    public int Month
    {
        get => _month;
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentOutOfRangeException(nameof(Month), "Month must be between 1 and 12.");
            _month = value;
        }
    }

    public int Day
    {
        get => _day;
        set
        {
            if (value < 1 || value > DateTime.DaysInMonth(_year, _month))
                throw new ArgumentOutOfRangeException(nameof(Day), "Invalid day for this month.");
            _day = value;
        }
    }

    public static bool IsValid(int day, int month, int year) =>
        year >= 1900 && year <= DateTime.Now.Year &&
        month >= 1 && month <= 12 &&
        day >= 1 && day <= DateTime.DaysInMonth(year, month);

    public override string ToString() => $"{Day:00}/{Month:00}/{Year}";
}
