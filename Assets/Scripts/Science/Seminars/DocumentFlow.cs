namespace Science.Seminars
{
    public class DocumentFlow : IStudyCell
    {
        public string Title => "Документооборот";

        public string Description => $"Вы можете приобрести семинар по документообороту.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Price}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 55_000;
        public int ExpirationDate => 5;
        public int NeedsTime => 20;
        public int RatioOfUpgrade => 10;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}