using Main;

namespace Assets.Realty.Middle
{
    public class CommercialBuilding : IAsset
    {
        public string Title => "Торговое здание";
        public string Details => $"Вы можете приобрести здание, предназначенное под торговлю.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 4_000_000;
        public int NeedsTime => 1;
        public int Income => 25_000;
        public Realty RealtyInfo => Realty.Middle;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}