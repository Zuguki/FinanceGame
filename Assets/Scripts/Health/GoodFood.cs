namespace DefaultNamespace
{
    public class GoodFood : IHealthInfo
    {
        public string Title() => "Пора кушать";

        public string Details(int price) => $"Вы думаете перейти на {Time()} месяц на ПП\nЦена: {price}р" +
                                            $"\nСвободное время: {NeedsTime()}";

        public int Time() => 1;
        public int NeedsTime() => 4;
    }
}