namespace Main
{
    public class Asset
    {
        public string Title { get; }
        public int Price { get; }
        public int CurrentPrice { get; set; }
        public int IncomeValue { get; }
        public int HealthValue { get; }
        public int ExpirationDate { get; set; }
        public int NeedsTime { get; }
        public float RatioOfUpgrade { get; set; }

        public Asset(string title, int price, int incomeValue, int healthValue, int expirationDate, int needsTime)
        {
            Title = title;
            Price = price;
            CurrentPrice = price;
            IncomeValue = incomeValue;
            HealthValue = healthValue;
            ExpirationDate = expirationDate;
            NeedsTime = needsTime;

            RatioOfUpgrade = 1;
        }
    }
}