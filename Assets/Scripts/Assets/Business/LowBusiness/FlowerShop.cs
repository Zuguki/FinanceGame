using Main;

namespace Assets.Business
{
    public class FlowerShop : IAsset
    {
        public string Title => "Цветочный магазин";

        public string Details => $"Вы можете приобрести цветочный магазин.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 400_000;

        public int NeedsTime => 30;
        public int Income => 50_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}