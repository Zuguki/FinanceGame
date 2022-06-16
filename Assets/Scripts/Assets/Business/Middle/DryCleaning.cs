using Main;

namespace Assets.Business.Middle
{
    public class DryCleaning : IAsset
    {
        public string Title => "Химчистка";

        public string Details => $"Вы можете приобрести прачечную.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 5_000_000;

        public int NeedsTime => 85;
        public int Income => 650_000;
        public Business BusinessInfo => Business.Middle;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}