using Main;

namespace Health
{
    public class SwimmingPool : IHealthInfo
    {
        public string Title() => $"Бассейн";

        public string Details(int price) => $"Вы захотели приобрести абонемент для похода в бассейн.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 9;
        public int NeedsTime() => 6;
    }
}