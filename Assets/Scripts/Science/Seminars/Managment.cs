namespace Science.Seminars
{
    public class Managment : IStudyCell
    {
        public string Title => "Менеджмент";

        public string Description => $"Вы можете изучить основы менеджмента, для этого вам потребуется:\n\n" +
                                     $"{ExpirationDate} месяцев\n" +
                                     $"{NeedsTime} часов свободного времени\n" +
                                     $"{Price} руб";

        public int Price => 100_000;
        public int ExpirationDate => 5;
        public int NeedsTime => 15;
        public StudyTrack Track => StudyTrack.Seminar;
    }
}