namespace DefaultNamespace
{
    public class Asset
    {
        public string Title { get; }
        public int Price { get; }
        public int IncomeValue { get; }
        public int HealthValue { get; }
        public int TimeValue { get; }
        public int Time { get; }

        public Asset(string title, int price, int incomeValue, int healthValue, int timeValue, int time)
        {
            Title = title;
            Price = price;
            IncomeValue = incomeValue;
            HealthValue = healthValue;
            TimeValue = timeValue;
            Time = time;
        }
    }
}