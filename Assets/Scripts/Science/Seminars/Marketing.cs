namespace Science.Seminars
{
    public class Marketing : IStudyCell
    {
        public string Title => "Маркетинг";

        public string Description => $"Вы можете приобрести семинар по маркетингу.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Price}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 60_000;
        public int ExpirationDate => 6;
        public int NeedsTime => 20;
        public int RatioOfUpgrade => 10;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}