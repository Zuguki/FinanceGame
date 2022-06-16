using Main;

namespace Health
{
    public class Athletics : IHealthInfo
    {
        public string Title() => $"Легкая атлетика";

        public string Details(int price) => $"Вы решили записаться в секцию по легкой атлетике.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 12;
        public int NeedsTime() => 8;
    }
}