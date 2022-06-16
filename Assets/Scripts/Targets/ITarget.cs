namespace Targets
{
    public interface ITarget
    {
        public int YearsTime { get; }
        public int BusinessCount { get; }
        public int RealtyCount { get; }
        public int MoodStat { get; }
        public int TimesFlow { get; }
        public TargetLvl Lvl { get; }
    }
}