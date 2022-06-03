namespace DefaultNamespace
{
    public class Pivovarnya : IBusinessInfo
    {
        public string Title => "Пивоварня";

        public string Details => $"Вы можете приобрести пивоварню за: {Price}р и получать за нее {Income}р/мес\n\n" +
                                 $"Требуется: \n\n" +
                                 $"{Price}р\n{NeedsTime} часов/мес";

        public int Price => 100_000;
        public int NeedsTime => 25;
        public int Income => 50_000;
        public Business BusinessInfo => Business.Low;
    }
}