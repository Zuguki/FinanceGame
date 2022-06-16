using Main;

namespace Assets.Realty.Middle
{
    public class TerritoryNearTheReservoir : IAsset
    {
        public string Title => "Территория у водоема";
        public string Details => $"Вы можете приобрести несколько квадратных метров для сдачи в аренду.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 6_500_000;
        public int NeedsTime => 1;
        public int Income => 50_000;
        public Realty RealtyInfo => Realty.Middle;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}