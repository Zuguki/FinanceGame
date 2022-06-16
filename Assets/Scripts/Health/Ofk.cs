using Main;

namespace Health
{
    public class Ofk : IHealthInfo
    {
        public string Title() => $"ОФК";

        public string Details(int price) => $"Вы можете приобрести абонемент на оздоровительную физическую культуру.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 6;
        public int NeedsTime() => 10;
    }
}