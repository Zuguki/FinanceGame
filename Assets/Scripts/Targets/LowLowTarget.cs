namespace Targets
{
    public class LowLowTarget : ITarget
    {
        public int YearsTime => 3;
        public int BusinessCount => 2;
        public int RealtyCount => 2;
        public int MoodStat => 8;
        public int TimesFlow => 120_000;
        public TargetLvl Lvl => TargetLvl.Low;
    }
}