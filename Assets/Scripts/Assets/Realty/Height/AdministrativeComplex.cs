using Main;

namespace Assets.Realty.Height
{
    public class AdministrativeComplex : IAsset
    {
        public string Title => "Административный комплекс";
        public string Details => $"Вы можете приобрести административный комплекс.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 60_000_000;
        public int NeedsTime => 1;
        public int Income => 1_000_000;
        public Realty RealtyInfo => Realty.Height;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}