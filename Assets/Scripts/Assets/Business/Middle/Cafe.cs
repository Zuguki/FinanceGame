using Main;

namespace Assets.Business.Middle
{
    public class Cafe : IAsset
    {
        public string Title => "Кафе";

        public string Details => $"Вы можете приобрести кафе-ресторан мировой азиатской кухни.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 2_200_000;

        public int NeedsTime => 70;
        public int Income => 350_000;
        public Business BusinessInfo => Business.Middle;
        public Realty.Realty RealtyInfo => Realty.Realty.None;
    }
}