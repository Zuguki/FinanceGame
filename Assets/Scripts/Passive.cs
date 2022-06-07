namespace Main
{
    public class Passive
    {
        public string Title { get; }
        public int Value { get; private set; }
        public int ExpirationDate { get; set; }
        public int MonthLength { get; set; }

        public Passive(string title, int value, int expirationDate, int monthLength)
        {
            Title = title;
            Value = value;
            ExpirationDate = expirationDate;
            MonthLength = monthLength;
        }
    }
}