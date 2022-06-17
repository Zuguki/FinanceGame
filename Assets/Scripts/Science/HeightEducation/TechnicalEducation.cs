using Main;

namespace Science.HeightEducation
{
    public class TechnicalEducation : IStudyCell
    {
        public string Title => "Техническое образование";
        
        public string Description => $"Вы можете приобрести техническое образование.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 600_000;
        public int ExpirationDate => 36;
        public int NeedsTime => 60;
        public int RatioOfUpgrade => 50;
        public StudyTrack Track => StudyTrack.HigherEducation;
    }
}