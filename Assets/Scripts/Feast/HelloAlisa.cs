namespace Feast
{
    public class HelloAlisa : IFeastInfo
    {
        public string Title() => "Привет, Алиса!";

        public string Details(string price) => $"Вы совсем разленились и захотели иметь у себя умную колонку со встроенным" +
                                            $" голосовым помощником за {price}р, чтобы в вашем доме было все " +
                                            $"в голосовом доступе.\n\n" +
                                            $"При отказе от такой покупки ваше настроение может ухудшиться.";
        public int ExpirationDate() => 0;

        public bool IsLiabilities() => false;
    }
}