namespace DefaultNamespace
{
    public class Home : IRealtyInfo
    {
        public string Title => "Загородный дом";
        public string Details => $"Стоимость покупки недвижимости: {Price}\nПрибыль: {Income}";
        public int Price => 500_000;
        public int NeedsTime => 0;
        public int Income => 15_000;
        public Realty RealtyInfo => Realty.Low;
    }
}