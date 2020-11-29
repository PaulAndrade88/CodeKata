using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip
{
    abstract class Trip
    {
        private string destination;

        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public decimal MilesDriven { get; set; }
        public decimal Mph { get; set; }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        //public virtual void Register(Trip trip) { }
    }

    class Standar : Trip
    {

    }

    class Vip : Trip 
    {
        
    }

    class Deluxe : Trip
    {

    }
}
