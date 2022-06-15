namespace Main
{
    public class Passive
    {
        public string Title { get; }
        public int Price { get; private set; }
        public int ExpirationDate { get; set; }
        public int IncomeValue { get; }

        public Passive(string title, int price, int expirationDate, int incomeValue = 0)
        {
            Title = title;
            Price = price;
            ExpirationDate = expirationDate;

            if (incomeValue != 0)
                IncomeValue = incomeValue;
            else
                IncomeValue = Price / ExpirationDate;
        }
    }
}