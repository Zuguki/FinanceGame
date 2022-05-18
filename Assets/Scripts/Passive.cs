namespace DefaultNamespace
{
    public class Passive
    {
        public int MoneyForMonth { get; private set; }
        public int TimeForMonth { get; private set; }
        public int MonthLength { get; set; }

        public Passive(int moneyForMonth, int timeForMonth, int monthLength)
        {
            MoneyForMonth = moneyForMonth;
            TimeForMonth = timeForMonth;
            MonthLength = monthLength;
        }
    }
}