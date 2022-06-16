namespace Targets
{
    public class MiddleHeightTarget : ITarget
    {
        public int YearsTime => 8;
        public int BusinessCount => 3;
        public int RealtyCount => 1;
        public int MoodStat => 10;
        public int CashFlow => 1_600_000;
        public TargetLvl Lvl => TargetLvl.Middle;
    }
}