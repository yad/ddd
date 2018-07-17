using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DDD.Domain.Passenger
{
    public class PassengerRepository
    {
        private readonly TrainStationContext context;

        public PassengerRepository(TrainStationContext context)
        {
            this.context = context;
        }

        internal async Task<PassengerEntity> GetById(int passengerId)
        {
            return await context.Set<PassengerEntity>().FirstOrDefaultAsync(p => p.Id == passengerId);
        }
    }
}
