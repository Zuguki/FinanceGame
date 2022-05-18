namespace DefaultNamespace
{
    public class Income
    {
        public int IncomeTitle { get; }
        public int IncomeValue { get; }

        public Income(int incomeTitle, int incomeValue)
        {
            IncomeTitle = incomeTitle;
            IncomeValue = incomeValue;
        }
    }
}