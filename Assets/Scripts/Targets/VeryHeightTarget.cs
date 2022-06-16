namespace Targets
{
    public class VeryHeightTarget : ITarget
    {
        public int YearsTime => 100000;
        public int BusinessCount => 1;
        public int RealtyCount => 1;
        public int MoodStat => 0;
        public int CashFlow => 0;
        public TargetLvl Lvl => TargetLvl.VeryHeight;
    }
}