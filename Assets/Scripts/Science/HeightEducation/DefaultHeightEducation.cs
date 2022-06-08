namespace Science.HeightEducation
{
    public class DefaultHeightEducation : IStudyCell
    {
        public string Title => "Нету";
        public string Description => "К сожалению, вы пока что не можете получить высшее образование\n\n" +
                                     "Возможны 2 причины:\n" +
                                     "1. На данный момент вы уже получаете высшее образование\n" +
                                     "2. Вы больше не можете получить высшее образование.";
        public int Price => 0;
        public int ExpirationDate => 1;
        public int NeedsTime => 0;
        public int RatioOfUpgrade => 0;
        public StudyTrack Track => StudyTrack.HigherEducation;
    }
}