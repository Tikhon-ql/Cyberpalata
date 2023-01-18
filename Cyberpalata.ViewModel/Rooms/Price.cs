﻿namespace Cyberpalata.ViewModel.Rooms
{
    public class Price
    {
        public Price(int hours, decimal cost)
        {
            Hours = hours;
            Cost = cost;
        }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
