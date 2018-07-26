using CSharpFunctionalExtensions;
using DDD.Domain.Passenger;
using System.Collections.Generic;

namespace DDD.Domain.Train
{
    public partial class TrainEntity
    {
        private const int TrainLimit = 50;

        public static TrainEntity Affreter(string numero)
        {
            return new TrainEntity()
            {
                _Number = numero,
                _Limit = TrainLimit
            };
        }

        private TrainEntity()
        {
            _Passengers = new List<PassengerEntity>();
        }

        private int _Id;
        public int Id => _Id;

        private string _Number;
        public string Number => _Number;

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
