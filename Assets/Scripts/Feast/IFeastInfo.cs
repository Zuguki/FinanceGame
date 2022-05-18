namespace DefaultNamespace.Feast
{
    public interface IFeastInfo
    {
        public string Title();
        public string Details(int price);

        public bool IsLiabilities();
    }
}