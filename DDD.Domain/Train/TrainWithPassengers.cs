using System;
using System.Collections.Generic;

namespace DDD.Domain.Train
{
    public class TrainWithPassengers
    {
        public static TrainWithPassengers Lister(string number, IEnumerable<string> passengers)
        {
            var trainWithPassengers = new TrainWithPassengers()
            {
                _Number = number
            };

            trainWithPassengers._Passengers.AddRange(passengers);

            return trainWithPassengers;
        }
        private TrainWithPassengers()
        {
            _Passengers = new List<string>();
        }

        private List<string> _Passengers;
        public IReadOnlyCollection<string> Passengers => _Passengers;


        private string _Number;
        public string Number => _Number;
    }
}
