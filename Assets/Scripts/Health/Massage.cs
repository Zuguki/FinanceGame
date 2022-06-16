using Main;

namespace Health
{
    public class Massage : IHealthInfo
    {
        public string Title() => $"Массаж";

        public string Details(int price) => $"Вы захотели ходить на массаж для поддержания ваших мышц в тонусе.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 3;
        public int NeedsTime() => 4;
    }
}