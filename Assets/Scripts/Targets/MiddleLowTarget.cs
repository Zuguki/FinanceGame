namespace Targets
{
    public class MiddleLowTarget : ITarget
    {
        public int YearsTime => 6;
        public int BusinessCount => 1;
        public int RealtyCount => 2;
        public int MoodStat => 10;
        public int CashFlow => 650_000;
        public TargetLvl Lvl => TargetLvl.Middle;
    }
}