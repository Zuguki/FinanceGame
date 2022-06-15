namespace Feast
{
    public class Default : IFeastInfo
    {
        public string Title() => $"Закончелись ивенты";

        public string Details(string price) => $"К сожалению у нас закончились для вас ивенты";

        public int ExpirationDate() => 5;

        public bool IsLiabilities() => false;
    }
}