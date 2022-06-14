namespace Feast
{
    public class FixLaptop : IFeastInfo
    {
        public string Title() => $"Ваш ноутбук сломался";

        public string Details(int price) => $"Вам стоит заменить ноутбук, стоимость: {price}\n\n" +
                                            $"**Отказ от покупки может ухудшить настроение";

        public int ExpirationDate() => 4;

        public bool IsLiabilities() => true;
    }
}