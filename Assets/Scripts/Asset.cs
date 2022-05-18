namespace DefaultNamespace
{
    public class Asset
    {
        public string Title { get; }
        public int Price { get; }
        public int IncomeValue { get; }
        
        public int NeedsTime { get; }

        public Asset(string title, int price, int incomeValue, int needsTime)
        {
            Title = title;
            Price = price;
            IncomeValue = incomeValue;
            NeedsTime = needsTime;
        }
    }
}