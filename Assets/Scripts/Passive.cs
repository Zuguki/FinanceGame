namespace DefaultNamespace
{
    public class Passive
    {
        public string Title { get; }
        public int MoneyForMonth { get; private set; }
        public int TimeForMonth { get; private set; }
        public int MonthLength { get; set; }

        public Passive(string title, int moneyForMonth, int timeForMonth, int monthLength)
        {
            Title = title;
            MoneyForMonth = moneyForMonth;
            TimeForMonth = timeForMonth;
            MonthLength = monthLength;
        }
    }
}