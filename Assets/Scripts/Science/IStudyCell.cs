namespace Science
{
    public interface IStudyCell
    {
        public string Title { get; }
        public string Description { get; }
        public int Price { get; }
        public int ExpirationDate { get; }
        public int NeedsTime { get; }
        public StudyTrack Track {get;}
    }
}