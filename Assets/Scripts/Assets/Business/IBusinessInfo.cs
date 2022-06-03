namespace DefaultNamespace
{
    public interface IBusinessInfo
    {
        public string Title { get; }
        
        public string Details { get; }
        
        public int Price { get; }
        
        public int NeedsTime { get; }
        
        public int Income { get; }
        
        public Business BusinessInfo { get; }
    }
}