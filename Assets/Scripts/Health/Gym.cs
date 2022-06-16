using Main;

namespace Health
{
    public class Gym : IHealthInfo
    {
        public string Title() => $"Тренажерный зал";

        public string Details(int price) => $"Вы решили приобрести абонемент в тренажерный зал с тренером.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 12;
        public int NeedsTime() => 12;
    }
}