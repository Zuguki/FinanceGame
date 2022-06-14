namespace Feast
{
    public class LovelyHome : IFeastInfo
    {
        public string Title() => $"Дом милый дом";

        public string Details(int price) => $"Вам надоело жить в старой квартире и вы решили приобрести квартиру " +
                                            $"в доме, который еще только строят\n" +
                                            $"Цена: {price}р.\n" +
                                            $"Действует: {ExpirationDate()}мес.\n\n" +
                                            $"Если вы этого не сделаете, ваше настроение может ухудшиться";

        public int ExpirationDate() => 12;

        public bool IsLiabilities() => true;
    }
}