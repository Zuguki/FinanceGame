using Main;

namespace Assets.Business.Height
{
    public class CarDealership : IAsset
    {
        public string Title => "Автосалон";

        public string Details => $"Вы можете приобрести автосалон.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 35_000_000;

        public int NeedsTime => 120;
        public int Income => 3_000_000;
        public Business BusinessInfo => Business.Height;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}