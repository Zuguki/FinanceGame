namespace Main
{
    public class Expense
    {
        public string Title { get; }
        public int Value { get; }
        public int Time { get; }

        public Expense(string title, int value, int time)
        {
            Title = title;
            Value = value;
            Time = time;
        }
    }
}