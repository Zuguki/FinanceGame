namespace DefaultNamespace
{
    public class Passive
    {
        public string Title { get; }
        public int Value { get; private set; }
        public int Time { get; private set; }
        public int MonthLength { get; set; }

        public Passive(string title, int value, int time, int monthLength)
        {
            Title = title;
            Value = value;
            Time = time;
            MonthLength = monthLength;
        }
    }
}