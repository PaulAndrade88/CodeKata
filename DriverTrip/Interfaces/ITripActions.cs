using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip
{
    interface ITripActions
    {
        public List<Trip> RegisterTrip(string[] input);
        public List<Trip> GetTrips(string[] input);
        public List<Trip> ValidateTrips(List<Trip> list);
        public Trip ValidateDates(Trip trip);
    }
}
