using Main;

namespace Science.HeightEducation
{
    public class HumanitarianEducation : IStudyCell
    {
        public string Title => "Гуманитарное образование";
        
        public string Description => $"Вы можете приобрести гуманитарное образование.\n" +
                                     $"Для этого необходимо:\n\n" +
                                     $"Свободное время: {NeedsTime}ч.\n" +
                                     $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                     $"Доход от бизнесов увеличится на: {RatioOfUpgrade}%\n" +
                                     $"Учеба длится: {ExpirationDate} месяцев.";

        public int Price => 240_000;
        public int ExpirationDate => 24;
        public int NeedsTime => 50;
        public int RatioOfUpgrade => 40;
        public StudyTrack Track => StudyTrack.HigherEducation;
    }
}