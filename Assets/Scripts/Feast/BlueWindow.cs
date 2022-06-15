namespace Feast
{
    public class BlueWindow : IFeastInfo
    {
        public string Title() => "Синий экран";

        public string Details(string price) => $"Упс! Ваш ноутбук перестал функционировать так, как раньше," +
                                            $" он постоянно выключается и тормозит." +
                                            $" Вы не можете так продолжать работать и вам необходимо обновить ноутбук\n\n" +
                                            $"Если вы не совершите разовую покупку за {price}р." +
                                            $" Ваше настроение может ухудшиться.";

        public int ExpirationDate() => 0;

        public bool IsLiabilities() => false;
    }
}