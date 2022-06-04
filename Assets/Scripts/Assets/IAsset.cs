namespace DefaultNamespace
{
    public interface IAsset
    {
        public string Title { get; }
        
        public string Details { get; }
        
        public int Price { get; }
        
        public int Income { get; }
        
        public int NeedsTime { get; }
        
        public Business BusinessInfo { get; }
        
        public Realty RealtyInfo { get; }
    }
}