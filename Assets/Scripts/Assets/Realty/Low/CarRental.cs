using Main;

namespace Assets.Realty.Low
{
    public class CarRental : IAsset
    {
        public string Title => "Аренда автомобиля";
        public string Details => $"Вы можете приобрести автомобиль для сдачи его в аренду.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 1_500_000;
        public int NeedsTime => 1;
        public int Income => 10_000;
        public Realty RealtyInfo => Realty.Low;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}