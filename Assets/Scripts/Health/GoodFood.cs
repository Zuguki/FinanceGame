using Main;

namespace Health
{
    public class GoodFood : IHealthInfo
    {
        public string Title() => "Правильное Питание";

        public string Details(int price) => "Вы решили перейти на правильное питание. " +
                                            "Вы можете оформить подписку, по которой " +
                                            "вам будут привозить еду.\n" + 
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";

        public int ExpirationDate() => 6;
        public int NeedsTime() => 8;
    }
}