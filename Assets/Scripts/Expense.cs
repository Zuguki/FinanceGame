namespace DefaultNamespace
{
    public class Expense
    {
        public string Title { get; }
        public int Value { get; }

        public Expense(string title, int value)
        {
            Title = title;
            Value = value;
        }
    }
}