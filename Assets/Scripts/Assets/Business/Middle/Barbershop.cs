using Main;

namespace Assets.Business.Middle
{
    public class Barbershop : IAsset
    {
        public string Title => "Барбершоп";

        public string Details => $"Вы можете приобрести парикмахерскую.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 4_500_000;

        public int NeedsTime => 80;
        public int Income => 550_000;
        public Business BusinessInfo => Business.Middle;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}