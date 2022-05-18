namespace DefaultNamespace
{
    public class Asset
    {
        public string Title { get; }
        public int Price { get; }
        public int Value { get; }
        public int NeedsTime { get; }

        public Asset(string title, int price, int value, int needsTime)
        {
            Title = title;
            Price = price;
            Value = value;
            NeedsTime = needsTime;
        }
    }
}