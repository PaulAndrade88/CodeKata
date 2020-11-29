using System;
using System.Collections.Generic;
using System.Text;

namespace DriverTrip.Command
{
    class StandarTravelCalculator : Register
    {
        private Actions _actions;
        private string[] _input;

        public StandarTravelCalculator(Actions actions, string[] input)
        {
            _actions = actions;
            _input = input;
        }

        public override List<People> RegisterDriver()
        {
            return _actions.RegisterPeople(_input);
        }

        public override List<Trip> RegisterTrip()
        {
            return _actions.RegisterTrip(_input);
        }
    }
}
