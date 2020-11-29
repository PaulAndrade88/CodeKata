using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip
{
    abstract class People
    {
        private string age;

        public string Name { get; set; }
        
        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        //public virtual void Register(People people) { }
    }

    class Driver : People
    {
        
    }    

    class CoDriver : People
    {

    }

    class Passenger1 : People
    {

    }

    class Passenger2 : People
    {

    }

    class Chalan : People
    {

    }


}
