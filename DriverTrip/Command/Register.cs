using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverTrip
{
    abstract class Register 
    {
        public abstract List<People> RegisterDriver();
        public abstract List<Trip> RegisterTrip();
    }
}
