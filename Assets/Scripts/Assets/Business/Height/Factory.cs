using Main;

namespace Assets.Business.Height
{
    public class Factory : IAsset
    {
        public string Title => "Завод";

        public string Details => $"Вы можете приобрести предприятие по производству деталей для самолетов.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 30_000_000;

        public int NeedsTime => 130;
        public int Income => 2_500_000;
        public Business BusinessInfo => Business.Height;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}