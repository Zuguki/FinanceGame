namespace Main
{
    public class Income
    {
        public string Title { get; }
        public string Description { get; }
        public int Value
        {
            get => (int) (_value * RatioOfUpgrade);
            private set => _value = value;
        }

        private int _value;

        public float RatioOfUpgrade { get; set; }

        public Income(string title, string description, int value, float ratioOfUpgrade = 1)
        {
            Title = title;
            Description = description;
            Value = value;

            RatioOfUpgrade = ratioOfUpgrade;
        }
    }
}