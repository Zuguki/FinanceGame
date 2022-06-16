namespace Science.HeightEducation
{
    public class Test : IStudyCell
    {
        public string Title => "Тест";
        public string Description => "Тест";
        public int Price => 100;
        public int ExpirationDate => 2;
        public int NeedsTime => 1;
        public int RatioOfUpgrade => 10000;
        public StudyTrack Track => StudyTrack.HigherEducation;
    }
}