using CSharpFunctionalExtensions;
using DDD.Domain.Passenger;
using System.Collections.Generic;

namespace DDD.Domain.Train
{
    public partial class TrainEntity
    {
        public TrainEntity(int trainId, int limit)
            : this()
        {
            _Id = trainId;
            _Limit = limit;
        }

        public TrainEntity()
        {
            _Passengers = new List<PassengerEntity>();
        }

        private int _Id;
        public int Id => _Id;


        private string _Name;
        public string Name => _Name;

        private int _Limit;
        public int Limit => _Limit;

        private readonly List<PassengerEntity> _Passengers;
        public IReadOnlyList<PassengerEntity> Passengers => _Passengers;
        
        public Result<TrainEntity> EmbarquerPassager(PassengerEntity passenger)
        {
            return Result.Ok(this)
                .Ensure(train => TrainEmbarquementSpecification.IsSatisfiedBy(train, passenger), "La limite d'embarquement est atteinte")
                .OnSuccess(train => train._Passengers.Add(passenger));
        }
    }
}
