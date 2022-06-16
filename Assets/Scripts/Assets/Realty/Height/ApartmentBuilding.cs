using Main;

namespace Assets.Realty.Height
{
    public class ApartmentBuilding : IAsset
    {
        public string Title => "Многоквартирный дом";
        public string Details => $"Вы можете приобрести многоквартирный дом для продажи квартир.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 100_000_000;
        public int NeedsTime => 1;
        public int Income => 5_000_000;
        public Realty RealtyInfo => Realty.Height;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}