﻿namespace Feast
{
    public class ElectricScooter : IFeastInfo
    {
        public string Title() => $"Электросамокат";

        public string Details(int price) => $"На улицах вашего города появились электросамокаты и вам очень " +
                                            $"понравилось на них кататься. Вы решили приобрести себе подписку, " +
                                            $"чтобы меньше тратить денег за поездки\n" +
                                            $"Цена: {price}р.\n" +
                                            $"Действует: {ExpirationDate()}мес.\n\n" +
                                            $"Если вы этого не сделаете, ваше настроение может ухудшиться";

        public int ExpirationDate() => 5;

        public bool IsLiabilities() => true;
    }
}