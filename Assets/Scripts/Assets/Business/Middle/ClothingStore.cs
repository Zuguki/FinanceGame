using Main;

namespace Assets.Business.Middle
{
    public class ClothingStore : IAsset
    {
        public string Title => "Магазин одежды";

        public string Details => $"Вы можете приобрести магазин по продаже премиальной одежды.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 3_000_000;

        public int NeedsTime => 75;
        public int Income => 400_000;
        public Business BusinessInfo => Business.Middle;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}