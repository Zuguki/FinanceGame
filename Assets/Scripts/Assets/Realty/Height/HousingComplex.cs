using Main;

namespace Assets.Realty.Height
{
    public class HousingComplex : IAsset
    {
        public string Title => "Жилищный комплекс";
        public string Details => $"Вы можете приобрести жилищный комплекс под сдачу жилья.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 80_000_000;
        public int NeedsTime => 1;
        public int Income => 2_000_000;
        public Realty RealtyInfo => Realty.Height;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}