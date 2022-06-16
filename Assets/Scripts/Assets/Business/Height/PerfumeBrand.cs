using Main;

namespace Assets.Business.Height
{
    public class PerfumeBrand : IAsset
    {
        public string Title => "Парфюмерный бренд";

        public string Details => $"Вы можете выкупить у одного предпринимателя бренд парфюмерной продукции.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 15_000_000;

        public int NeedsTime => 100;
        public int Income => 1_500_000;
        public Business BusinessInfo => Business.Height;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}