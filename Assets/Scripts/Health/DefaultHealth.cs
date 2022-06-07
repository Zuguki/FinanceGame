namespace Health
{
    public class DefaultHealth : IHealthInfo
    {
        public string Title() => "Вы здоровы";

        public string Details(int price) => "У вас все хорошо со здоросьем";

        public int Time() => 0;
        public int NeedsTime() => 0;
    }
}