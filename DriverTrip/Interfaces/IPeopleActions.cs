using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip
{
    interface IPeopleActions
    {
        public List<People> RegisterPeople(string[] input);
        public List<People> GetDrivers(string[] input);
        
    }
}
