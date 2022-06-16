using Main;

namespace Assets.Business
{
    public class Kiosk : IAsset
    {
        public string Title => "Киоск";

        public string Details => $"Вы можете приобрести киоск по продаже журналов, игрушек, газет.\n" +
                                 "Для покупки необходимо:\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}\n";

        public int Price => 200_000;

        public int NeedsTime => 15;
        public int Income => 20_000;
        public Business BusinessInfo => Business.Low;
        public Realty.Realty RealtyInfo => Realty.Realty.None;

    }
}