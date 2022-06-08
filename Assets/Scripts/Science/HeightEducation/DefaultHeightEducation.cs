namespace Science.HeightEducation
{
    public class DefaultHeightEducation : IStudyCell
    {
        public string Title => "Поздравляю";
        public string Description => "Поздравляем, вы получили всевозможное высшее образование";
        public int Price => 0;
        public int ExpirationDate => 1;
        public int NeedsTime => 0;
        public int RatioOfUpgrade => 0;
        public StudyTrack Track => StudyTrack.HigherEducation;
    }
}