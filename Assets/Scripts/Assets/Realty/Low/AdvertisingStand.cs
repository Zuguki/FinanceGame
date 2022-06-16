using Main;

namespace Assets.Realty.Low
{
    public class AdvertisingStand : IAsset
    {
        public string Title => "Рекламный стенд";
        public string Details => $"Вы можете приобрести стенд для размещения рекламных баннеров.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 500_000;
        public int NeedsTime => 1;
        public int Income => 15_000;
        public Realty RealtyInfo => Realty.Low;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}