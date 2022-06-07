namespace Main
{
    public class Asset
    {
        public string Title { get; }
        public int Price { get; }
        public int IncomeValue { get; }
        public int HealthValue { get; }
        public int ExpirationDate { get; set; }
        public int NeedsTime { get; }

        public Asset(string title, int price, int incomeValue, int healthValue, int expirationDate, int needsTime)
        {
            Title = title;
            Price = price;
            IncomeValue = incomeValue;
            HealthValue = healthValue;
            ExpirationDate = expirationDate;
            NeedsTime = needsTime;
        }
    }
}