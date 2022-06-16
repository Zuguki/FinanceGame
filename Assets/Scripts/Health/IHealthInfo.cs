namespace Health
{
    public interface IHealthInfo
    {
        public string Title();
        public string Details(int price);

        public int ExpirationDate();

        public int NeedsTime();
    }
}