namespace DefaultNamespace
{
    public class Asset
    {
        public string Title { get; }
        public int Price { get; }
        public int Value { get; }
        public int Time { get; }

        public Asset(string title, int price, int value, int time)
        {
            Title = title;
            Price = price;
            Value = value;
            Time = time;
        }
    }
}