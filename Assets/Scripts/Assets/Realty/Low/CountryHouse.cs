﻿using Main;

namespace Assets.Realty.Low
{
    public class CountryHouse : IAsset
    {
        public string Title => "Загородный домик";
        public string Details => $"Вы можете приобрести загородный дом в деревне.\n" +
                                 "Для покупки необходимо:\n\n" +
                                 $"Свободное время: {NeedsTime}ч.\n" +
                                 $"Цена: {Converter.ConvertToString(Price.ToString())}р.\n" +
                                 $"Прибыль: {Converter.ConvertToString(Income.ToString())}р.\n";

        public int Price => 800_000;
        public int NeedsTime => 1;
        public int Income => 20_000;
        public Realty RealtyInfo => Realty.Low;
        public Business.Business BusinessInfo => Business.Business.None;
    }
}