using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverTrip.Command
{
    public class Requester //Invoker
    {
        private Actions _actions = new Actions();
        private List<People> _driversList = new List<People>();
        private List<Trip> _tripsList = new List<Trip>();

        public void RegisterDriver(string[] input)
        {
            _driversList = _actions.RegisterPeople(input);
        }

        public void RegisterTrip(string[] input)
        {
            _tripsList = _actions.RegisterTrip(input);
        }

        public string[] GetReport(string[] input)
        {
            RegisterDriver(input);
            RegisterTrip(input);

            var groupedDriversList = _driversList.GroupBy(x => x.Name).Select(x => x.Key).ToList();


            foreach (var trip in _tripsList.ToList())
            {
                bool exists = false; string name = string.Empty;
                for (int i = 0; i < groupedDriversList.Count; i++)
                {
                    exists = trip.Name == groupedDriversList[i];
                    name = exists ? string.Empty : groupedDriversList[i];
                }

                if (!exists)
                {
                    _tripsList.Add(new Standar
                    {
                        Name = name,
                        MilesDriven = 0
                    });

                }
            }

            _tripsList = _actions.ValidateTrips(_tripsList); //Sort and remove duplicates

            string[] report = new string[_tripsList.Count];

            for (int ii = 0; ii < _tripsList.Count; ii++)
            {
                report[ii] = _tripsList[ii].Mph > 0 ?
                    report[ii] = _tripsList[ii].Name + ": " + _tripsList[ii].MilesDriven + " miles " + "@ " + _tripsList[ii].Mph + " mph"
                :
                    report[ii] = _tripsList[ii].Name + ": " + _tripsList[ii].MilesDriven + " miles ";

            }


            return report;
        }
    }
}
