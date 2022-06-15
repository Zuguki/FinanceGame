namespace Feast
{
    public class MusicConnectMe : IFeastInfo
    {
        public string Title() => $"Музыка меня связала";

        public string Details(string price) => $"Вы любите постоянно слушать музыку и захотели оформить подписку на " +
                                            $"музыку, чтобы ваша жизнь была веселее\n" +
                                            $"Цена: {price}р.\n" +
                                            $"Действует: {ExpirationDate()}мес.\n\n" +
                                            $"Если вы этого не сделаете, ваше настроение может ухудшиться";

        public int ExpirationDate() => 6;

        public bool IsLiabilities() => true;
    }
}