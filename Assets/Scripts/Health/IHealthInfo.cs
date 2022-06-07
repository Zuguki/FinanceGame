namespace Health
{
    public interface IHealthInfo
    {
        public string Title();
        public string Details(int price);

        public int Time();

        public int NeedsTime();
    }
}