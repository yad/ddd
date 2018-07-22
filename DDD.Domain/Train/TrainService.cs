using CSharpFunctionalExtensions;
using DDD.Domain.Passenger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Domain.Train
{
    public class TrainService
    {
        private readonly TrainRepository trainRepository;
        private readonly PassengerRepository passengerRepository;

        public TrainService(TrainRepository trainRepository, PassengerRepository passengerRepository)
        {
            this.trainRepository = trainRepository;
            this.passengerRepository = passengerRepository;
        }

        public async Task<TrainEntity> EmbarquerDansLeTrain(int trainId, int passengerId)
        {
            var train = await trainRepository.GetById(trainId);
            if (train == null)
            {
                train = await AffreterUnTrain(trainId);
            }
            var passenger = await passengerRepository.GetById(passengerId) ?? new PassengerEntity(passengerId);
            train.EmbarquerPassager(passenger);
            return train;
        }

        public async Task<IReadOnlyList<TrainIdentifier>> ListerLesTrains()
        {
            return await trainRepository.GetAll();
        }

        public async Task<TrainEntity> AffreterUnTrain(int trainId)
        {
            TrainEntity train = new TrainEntity(trainId, 50);
            await trainRepository.Add(train);
            return train;
        }
    }
}
