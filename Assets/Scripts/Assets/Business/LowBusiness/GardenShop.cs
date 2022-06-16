using Main;

namespace Assets.Business
{
    public class GardenShop : IAsset
    {
        public string Title => "Садовый магазин";

        public string Details => $"Вы можете приобрести магазин по продаже садовых удобрений и семян.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 250_000;

        public int NeedsTime => 20;
        public int Income => 30_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}