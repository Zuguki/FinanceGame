namespace Targets
{
    public class LowHeightTarget : ITarget
    {
        public int YearsTime => 3;
        public int BusinessCount => 3;
        public int RealtyCount => 2;
        public int MoodStat => 8;
        public int CashFlow => 230_000;
        public TargetLvl Lvl => TargetLvl.Low;
    }
}