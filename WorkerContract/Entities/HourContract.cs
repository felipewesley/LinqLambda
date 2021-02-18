using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerContract.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        private double ValuePerHour { get; set; }
        private int Hours { get; set; }

        public HourContract(DateTime date, double value, int hours)
        {
            Date = date;
            ValuePerHour = value;
            Hours = hours;
        }

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }

    }
}
