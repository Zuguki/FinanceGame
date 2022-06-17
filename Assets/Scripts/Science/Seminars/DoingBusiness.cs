using Main;

namespace Science.Seminars
{
    public class DoingBusiness : IStudyCell
    {
        public string Title => "Ведение бизнеса";

        public string Description => $"Вы можете приобрести семинар по ведению бизнеса.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 65_000;
        public int ExpirationDate => 5;
        public int NeedsTime => 30;
        public int RatioOfUpgrade => 10;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}