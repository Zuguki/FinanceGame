using Main;

namespace Science.HeightEducation
{
    public class EconomicEducation : IStudyCell
    {
        public string Title => "Экономическое образование";
        
        public string Description => $"Вы можете приобрести экономическое образование.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 180_000;
        public int ExpirationDate => 12;
        public int NeedsTime => 40;
        public int RatioOfUpgrade => 30;
        public StudyTrack Track => StudyTrack.HigherEducation;
    }
}