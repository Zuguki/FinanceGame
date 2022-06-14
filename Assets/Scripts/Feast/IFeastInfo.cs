namespace Feast
{
    public interface IFeastInfo
    {
        public string Title();
        public string Details(int price);
        public int ExpirationDate();

        public bool IsLiabilities();
    }
}