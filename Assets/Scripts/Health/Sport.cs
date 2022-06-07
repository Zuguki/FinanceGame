namespace Health
{
    public class Sport : IHealthInfo
    {
        public string Title() => $"Пора записаться в зал";

        public string Details(int price) =>
            $"Вы немного запустили себя и очень хотите пойти в зал, \nцена {Time()} месячного абонимента: {price}" +
            $"Требуется свободного времени: {NeedsTime()}";

        public int Time() => 12;
        public int NeedsTime() => 12;
    }
}