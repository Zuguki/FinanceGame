using Main;

namespace Assets.Business.Height
{
    public class University : IAsset
    {
        public string Title => "Университет";

        public string Details => $"Вы можете приобрести ведущий в стране университет.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 20_000_000;

        public int NeedsTime => 120;
        public int Income => 1_700_000;
        public Business BusinessInfo => Business.Height;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}