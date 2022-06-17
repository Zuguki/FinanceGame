using Main;

namespace Science.Seminars
{
    public class Freelance : IStudyCell
    {
        public string Title => "Фриланс";

        public string Description => $"Вы можете приобрести семинар по фрилансу.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 70_000;
        public int ExpirationDate => 6;
        public int NeedsTime => 25;
        public int RatioOfUpgrade => 10;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}