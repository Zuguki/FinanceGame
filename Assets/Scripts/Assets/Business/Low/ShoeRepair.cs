using Main;

namespace Assets.Business.Low
{
    public class ShoeRepair : IAsset
    {
        public string Title => "Ремонт обуви";

        public string Details => $"Вы можете приобрести Мини-магазин по ремонту обуви.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 300_000;

        public int NeedsTime => 30;
        public int Income => 40_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}