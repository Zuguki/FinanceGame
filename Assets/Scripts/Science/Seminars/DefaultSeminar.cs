namespace DefaultNamespace.Seminars
{
    public class DefaultSeminar : IStudyCell
    {
        public string Title => "Нету";
        public string Description => "Поздравляем, вы прошли все семинары";
        public int Price => 0;
        public int ExpirationDate => 0;
        public int NeedsTime => 0;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}