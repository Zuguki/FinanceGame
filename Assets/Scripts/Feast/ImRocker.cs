namespace Feast
{
    public class ImRocker : IFeastInfo
    {
        public string Title() => "Я у мамы рокер";

        public string Details(string price) => $"Недавно вы были на рок-концерте, и вы захотели сами играть на " +
                                            $"электрогитаре с хорошими колонками. У вас ничего из этого оборудования " +
                                            $"нет, но вам очень хочется играть на гитаре, Цена которой: {price}р.\n\n" +
                                            $"При отказе от данной покупки ваше настроение может ухудшиться.";
        public int ExpirationDate() => 0;

        public bool IsLiabilities() => false;
    }
}