using DDD.Domain.Passenger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Domain.Train
{
    public class TrainService
    {
        private readonly TrainRepository _trainRepository;
        private readonly PassengerRepository _passengerRepository;

        public TrainService(TrainRepository trainRepository, PassengerRepository passengerRepository)
        {
            _trainRepository = trainRepository;
            _passengerRepository = passengerRepository;
        }

        public async Task<TrainEntity> EmbarquerDansLeTrain(int trainId, int passengerId)
        {
            var train = await _trainRepository.GetById(trainId);
            var passenger = await _passengerRepository.GetById(passengerId);
            train.EmbarquerPassager(passenger);
            await _trainRepository.Update(train);
            return train;
        }

        public async Task<IReadOnlyList<TrainWithPassengers>> ListerLesTrains()
        {
            return await _trainRepository.GetAll();
        }

        public async Task<TrainEntity> AffreterUnTrain(string numero)
        {
            TrainEntity train = TrainEntity.Affreter(numero);
            await _trainRepository.Add(train);
            return train;
        }
    }
}
