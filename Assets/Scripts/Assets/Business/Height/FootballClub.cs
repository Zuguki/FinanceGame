using Main;

namespace Assets.Business.Height
{
    public class FootballClub : IAsset
    {
        public string Title => "Футбольный клуб";

        public string Details => $"Вы можете стать владельцем футбольного клуба.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 10_000_000;

        public int NeedsTime => 90;
        public int Income => 900_000;
        public Business BusinessInfo => Business.Height;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}