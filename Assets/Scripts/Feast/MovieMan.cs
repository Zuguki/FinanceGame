namespace Feast
{
    public class MovieMan : IFeastInfo
    {
        public string Title() => $"Киноман";

        public string Details(string price) => $"Вы захотели приобрести себе подписку на одну платформу, чтобы смотреть " +
                                            $"самые свежие новинки в мире кино у себя дома\n" +
                                            $"Цена: {price}р.\n" +
                                            $"Действует: {ExpirationDate()}мес.\n\n" +
                                            $"Если вы этого не сделаете, ваше настроение может ухудшиться";

        public int ExpirationDate() => 9;

        public bool IsLiabilities() => true;
    }
}