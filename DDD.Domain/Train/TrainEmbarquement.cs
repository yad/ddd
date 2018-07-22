using DDD.Domain.Passenger;

namespace DDD.Domain.Train
{
    public static class TrainEmbarquementSpecification
    {
        public static bool IsSatisfiedBy(TrainEntity train, PassengerEntity passenger)
        {
            return train.Passengers.Count < train.Limit;
        }
    }
}

