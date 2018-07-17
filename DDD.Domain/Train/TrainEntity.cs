using DDD.Domain.Passenger;
using System.Collections.Generic;

namespace DDD.Domain.Train
{
    public partial class TrainEntity
    {
        public TrainEntity(int trainId)
            : this()
        {
            _Id = trainId;
        }

        public TrainEntity()
        {
            _Passengers = new List<PassengerEntity>();
        }

        private int _Id;
        public int Id => _Id;


        private string _Name;
        public string Name => _Name;


        private readonly List<PassengerEntity> _Passengers;
        public IReadOnlyList<PassengerEntity> Passengers => _Passengers;

        internal void EmbarquerPassager(PassengerEntity passenger)
        {
            _Passengers.Add(passenger);
        }
    }
}
