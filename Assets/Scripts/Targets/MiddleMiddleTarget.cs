namespace Targets
{
    public class MiddleMiddleTarget : ITarget
    {
        public int YearsTime => 7;
        public int BusinessCount => 2;
        public int RealtyCount => 2;
        public int MoodStat => 10;
        public int TimesFlow => 1_200_000;
        public TargetLvl Lvl => TargetLvl.Middle;
    }
}