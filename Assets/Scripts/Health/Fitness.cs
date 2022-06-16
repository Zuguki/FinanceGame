using Main;

namespace Health
{
    public class Fitness : IHealthInfo
    {
        public string Title() => $"Фитнес";

        public string Details(int price) => $"Вы можете приобрести абонемент в фитнес-зал с тренером.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 9;
        public int NeedsTime() => 8;
    }
}