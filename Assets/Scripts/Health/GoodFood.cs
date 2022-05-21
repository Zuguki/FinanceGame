namespace DefaultNamespace
{
    public class GoodFood : IHealthInfo
    {
        public string Title() => "Пора кушать";

        public string Details(int price) => $"Вы думаете перейти на {Time()} месяц на ПП\nЦена: {price}";

        public int Time() => 1;
    }
}