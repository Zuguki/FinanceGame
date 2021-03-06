namespace Targets
{
    public class LowMiddleTarget : ITarget
    {
        public int YearsTime => 3;
        public int BusinessCount => 3;
        public int RealtyCount => 1;
        public int MoodStat => 8;
        public int CashFlow => 180_000;
        public TargetLvl Lvl => TargetLvl.Low;
    }
}