namespace DefaultNamespace
{
    public class Income
    {
        public int Title { get; }
        public int Value { get; }
        
        public int Time { get; }

        public Income(int title, int value, int time)
        {
            Title = title;
            Value = value;
            Time = time;
        }
    }
}