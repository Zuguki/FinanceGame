using Main;

namespace Assets.Business.Middle
{
    public class SelfServiceCarWash : IAsset
    {
        public string Title => "Автомойка самообслуживания";

        public string Details => $"Вы можете приобрести автомойку самообслуживания.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 1_400_000;

        public int NeedsTime => 50;
        public int Income => 200_000;
        public Business BusinessInfo => Business.Middle;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}