namespace Targets
{
    public class HeightLowTarget : ITarget
    {
        public int YearsTime => 12;
        public int BusinessCount => 1;
        public int RealtyCount => 3;
        public int MoodStat => 10;
        public int CashFlow => 6_000_000;
        public TargetLvl Lvl => TargetLvl.Height;
    }
}