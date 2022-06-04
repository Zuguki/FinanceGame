namespace DefaultNamespace
{
    public class DefaultBusinessNotification : IAsset
    {
        public string Title => "Изнините";
        public string Details => "К сожалению в этой категории больше нет бизнесов для вас";
        public int Price { get; }
        public int NeedsTime { get; }
        public int Income { get; }
        public Business BusinessInfo { get; }
        public Realty RealtyInfo { get; }
    }
}