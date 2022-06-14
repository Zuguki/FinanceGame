namespace Feast
{
    public class IllegalRider : IFeastInfo
    {
        public string Title() => "Гонщик нелегальный";

        public string Details(int price) => $"Вам надоело каждый день передвигаться " +
                                            $"из разных точек города пешком, и вы увидели автомобиль, " +
                                            $"который давно хотели иметь у себя.\n\n" + 
        $"Вы можете сейчас купить данный автомобиль за {price}р, " +
                                            $"но если вы не совершите эту покупку, ваше настроение может ухудшиться.";
        public int ExpirationDate() => 0;

        public bool IsLiabilities() => false;
    }
}