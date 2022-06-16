using Main;

namespace Health
{
    public class Volleyball : IHealthInfo
    {
        public string Title() => $"Волейбол";

        public string Details(int price) => $"Вы захотели регулярно собираться с друзьями и играть в волейбол" +
                                            $" в специальном манеже.\n" +
                                            "Для покупки необходимо:\n\n" +
                                            $"Цена: {Converter.ConvertToString(price.ToString())}р.\n" +
                                            $"Действует: {ExpirationDate()} месяцев\n" +
                                            $"Свободного времени: {NeedsTime()}ч.";


        public int ExpirationDate() => 5;
        public int NeedsTime() => 8;
    }
}