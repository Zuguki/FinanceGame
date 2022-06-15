namespace Feast
{
    public class ShifterMachine : IFeastInfo
    {
        public string Title() => $"Машина-перевертыш";

        public string Details(string price) => $"Ваш автомобиль попал в аварию и чтобы его починить, " +
                                            $"вам нужно отдать его в автосервис\n" +
                                            $"Цена: {price}р.\n" +
                                            $"Действует: {ExpirationDate()}мес.\n\n" +
                                            $"Если вы этого не сделаете, ваше настроение может ухудшиться";

        public int ExpirationDate() => 3;

        public bool IsLiabilities() => true;
    }
}