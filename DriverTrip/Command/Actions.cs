using System;
using System.Collections.Generic;
using System.Linq;

namespace DriverTrip.Command
{
    class Actions : IPeopleActions, ITripActions
    {
        public List<People> RegisterPeople(string[] input)
        {
            return GetDrivers(input);
        }

        public List<Trip> RegisterTrip(string[] input)
        {
            List<Trip> tripsList = GetTrips(input);
            return ValidateTrips(tripsList);
        }

        public List<People> GetDrivers(string[] input)
        {
            List<People> lPerson = new List<People>();

            foreach (string line in input)
            {
                People driver = new Driver();

                if (line.Contains("Driver"))
                {
                    driver.Name = line.Substring(line.IndexOf(" ") + 1);
                    lPerson.Add(driver);
                }
            }

            return lPerson;
        }

        public List<Trip> GetTrips(string[] input)
        {
            List<Trip> lTrip = new List<Trip>();

            foreach (string line in input)
            {
                Trip trip = new Standar();

                if (line.Contains("Trip"))
                {
                    string[] tripData = line.Split(' ');

                    trip.Name = tripData[1];

                    trip.StartTime = DateTime.Parse(tripData[2].ToString());
                    _ = trip.StartTime.ToString("HH:mm"); //We'll use a 24-hour clock //Times will be given in the format of hours:minutes. 

                    trip.StopTime = DateTime.Parse(tripData[3].ToString());
                    _ = trip.StopTime.ToString("HH:mm"); //We'll use a 24-hour clock //Times will be given in the format of hours:minutes. 

                    trip.MilesDriven = decimal.Round(Convert.ToDecimal(tripData[4]));

                    TimeSpan ts = trip.StopTime - trip.StartTime;
                    decimal hours = (decimal)ts.TotalMinutes / 60;

                    trip.Mph = decimal.Round(trip.MilesDriven / hours); //Round miles and miles per hour to the nearest integer.

                    trip = ValidateDates(trip);

                    if (trip.StartTime != DateTime.MinValue)
                        lTrip.Add(trip);
                }
            }

            return lTrip;
        }

        public List<Trip> ValidateTrips(List<Trip> list)
        {
            List<Trip> response = new List<Trip>();

            var sortedSumList = list.AsEnumerable()
                .Select(x =>
                new
                {
                    x.Name,
                    x.StartTime,
                    x.StopTime,
                    x.MilesDriven,
                    x.Mph
                }
                )
                .GroupBy(s => new { s.Name })
                .Select(g =>
                new
                {
                    g.Key.Name,
                    MilesDriven = g.Sum(x => x.MilesDriven),
                    Mph = g.Average(x => x.Mph) //average speed. 
                })
                .OrderByDescending(g => g.MilesDriven) //Sort the output by most miles driven to least. 
                .ToList();

            foreach (var trip in sortedSumList)
            {
                response.Add(
                    new Standar
                    {
                        Name = trip.Name,
                        MilesDriven = trip.MilesDriven,
                        Mph = trip.Mph > 4 && trip.Mph < 101 ? trip.Mph : 0 //Average speed limits check
                    });
            }


            return response;
        }

        public Trip ValidateDates(Trip trip)
        {
            bool datesOk = trip.StartTime.CompareTo(trip.StopTime) == (int)CompareTimeEnum.Before; //the start time will always be before the end time //drivers never drive past midnight.

            if (!datesOk)
                trip.StartTime = trip.StopTime = DateTime.MinValue;



            return trip;
        }
    }
}
