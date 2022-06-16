using Main;

namespace Assets.Realty.Middle
{
    public class Flat : IAsset
    {
        public string Title => "Квартира";
        public string Details => $"Вы можете приобрести квариту для сдачи в аренду.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 5_000_000;
        public int NeedsTime => 1;
        public int Income => 35_000;
        public Realty RealtyInfo => Realty.Middle;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}