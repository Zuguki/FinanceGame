using Main;

namespace Assets.Realty.Middle
{
    public class AgriculturalFacilities : IAsset
    {
        public string Title => "Сельхозобъекты";
        public string Details => $"Вы можете приобрести различные сельхозобъекты для ферм.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 2_500_000;
        public int NeedsTime => 1;
        public int Income => 20_000;
        public Realty RealtyInfo => Realty.Middle;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}