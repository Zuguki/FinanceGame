namespace Main
{
    public class Passive
    {
        public string Title { get; }
        public int Price { get; private set; }
        public int ExpirationDate { get; set; }

        public Passive(string title, int price, int expirationDate)
        {
            Title = title;
            Price = price;
            ExpirationDate = expirationDate;
        }
    }
}