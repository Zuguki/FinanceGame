namespace Feast
{
    public class SomeFood : IFeastInfo
    {
        public string Title() => "Вы хотите кушать";

        public string Details(int price) => $"Вам очень хочется сходить в ресторан, цена вашего похода: {price}\n\n" +
                                            $"**Отказ от покупки может ухудшить настроение";

        public bool IsLiabilities() => false;
    }
}