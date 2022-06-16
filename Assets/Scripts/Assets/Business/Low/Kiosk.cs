using Main;

namespace Assets.Business.Low
{
    public class Kiosk : IAsset
    {
        public string Title => "Киоск";

        public string Details => $"Вы можете приобрести киоск по продаже журналов, игрушек, газет.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 200_000;

        public int NeedsTime => 15;
        public int Income => 20_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}