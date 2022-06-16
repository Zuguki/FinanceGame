using Main;

namespace Assets.Business.Middle
{
    public class ElectronicsStore : IAsset
    {
        public string Title => "Магазин электроники";

        public string Details => $"Вы можете приобрести магазин по продаже электронных товаров.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 4_000_000;

        public int NeedsTime => 80;
        public int Income => 600_000;
        public Business BusinessInfo => Business.Middle;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}