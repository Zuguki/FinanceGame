namespace Feast
{
    public interface IFeastInfo
    {
        public string Title();
        public string Details(string price);
        public int ExpirationDate();

        public bool IsLiabilities();
    }
}