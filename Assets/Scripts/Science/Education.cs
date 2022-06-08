namespace Science
{
    public class Education
    {
        public string Title { get; }
        public string Description { get; }
        public int Price { get; }
        public int ExpirationDate { get; set; }
        public int NeedsTime { get; set; }
        public int RatioOfUpgrade { get; }
        public StudyTrack Track { get; }

        public Education(string title, string description, int price, int expirationDate, int needsTime,
            int ratioOfUpgrade, StudyTrack track)

        {
            Title = title;
            Description = description;
            Price = price;
            ExpirationDate = expirationDate;
            NeedsTime = needsTime;
            RatioOfUpgrade = ratioOfUpgrade;
            Track = track;
        }
    }
}