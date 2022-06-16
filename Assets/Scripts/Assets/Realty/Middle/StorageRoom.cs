using Main;

namespace Assets.Realty.Middle
{
    public class StorageRoom : IAsset
    {
        public string Title => "Складское помещение";
        public string Details => $"Вы можете приобрести помещение, под склад.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 3_800_000;
        public int NeedsTime => 1;
        public int Income => 30_000;
        public Realty RealtyInfo => Realty.Middle;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}