using Main;

namespace Assets.Business
{
    public class OfficeStore : IAsset
    {
        public string Title => "Магазин канцелярии";

        public string Details => $"Вы можете приобрести магазин по продаже канцелярских товаров.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 550_000;

        public int NeedsTime => 40;
        public int Income => 60_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}