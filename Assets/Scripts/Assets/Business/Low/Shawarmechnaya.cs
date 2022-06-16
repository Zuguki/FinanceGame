using Main;

namespace Assets.Business.Low
{
    public class Shawarmechnaya : IAsset
    {
        public string Title => "Шаурмечная";

        public string Details => $"Вы можете приобрести ларек по продаже шаурмы.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 450_000;

        public int NeedsTime => 25;
        public int Income => 60_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}