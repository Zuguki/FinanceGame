namespace Assets.Realty
{
    public class DefaultRealtyNotification : IAsset
    {
        public string Title => "Извините";
        public string Details => "К сожалению, в этой категории больше нет недвижимости для вас";
        public int Price { get; }
        public int NeedsTime { get; }
        public Business.Business BusinessInfo { get; }
        public int Income { get; }
        public Realty RealtyInfo { get; }
    }
}