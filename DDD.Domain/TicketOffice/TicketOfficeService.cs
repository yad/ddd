using DDD.Domain.Passenger;
using System.Threading.Tasks;

namespace DDD.Domain.TicketOffice
{
    public class TicketOfficeService
    {
        private readonly PassengerRepository _passengerRepository;

        public TicketOfficeService(PassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<PassengerEntity> EnregistrerClient(string nom, string prenom)
        {
            PassengerEntity passenger = PassengerEntity.NouveauClient(nom, prenom);
            await _passengerRepository.Add(passenger);
            return passenger;
        }
    }
}
