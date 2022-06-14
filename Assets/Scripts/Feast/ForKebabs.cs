namespace Feast
{
    public class ForKebabs : IFeastInfo
    {
        public string Title() => "На шашлыки";

        public string Details(int price) => $"Недавно вы увидели в магазине новое устройство для барбекю со " +
                                            $"встроенным камином для ног, которая может работать в любое время года. " +
                                            $"Цена покупки: {price}р";
        public int ExpirationDate() => 0;

        public bool IsLiabilities() => false;
    }
}