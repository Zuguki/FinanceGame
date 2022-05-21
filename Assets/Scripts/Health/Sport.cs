namespace DefaultNamespace
{
    public class Sport : IHealthInfo
    {
        public string Title() => $"Пора записаться в зал";

        public string Details(int price) =>
            $"Вы немного запустили себя и очень хотите пойти в зал, цена {Time()} месячного абонимента: {price}";

        public int Time() => 12;
    }
}