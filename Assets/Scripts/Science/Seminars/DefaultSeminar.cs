namespace Science.Seminars
{
    public class DefaultSeminar : IStudyCell
    {
        public string Title => "Нету";
        public string Description => "К сожалению, пока вы не можете проходить семинары. \n\n" +
                                     "Возможны 2 причины:\n" +
                                     "1. Вы уже проходите семинар\n" +
                                     "2. Вы уже прошли все семинары";
        public int Price => 0;
        public int ExpirationDate => 1;
        public int NeedsTime => 0;
        public int RatioOfUpgrade => 0;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}