using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DDD.Domain.Train
{
    public class TrainRepository
    {
        private readonly TrainStationContext context;

        public TrainRepository(TrainStationContext context)
        {
            this.context = context;
        }

        internal async Task<TrainEntity> GetById(int trainId)
        {
            return await context.Set<TrainEntity>().FirstOrDefaultAsync(p => p.Id == trainId);
        }

        internal async Task Add(TrainEntity train)
        {
            context.Set<TrainEntity>().Add(train);
            await context.SaveChangesAsync();
        }

        internal async Task<IReadOnlyList<TrainIdentifier>> GetAll()
        {
            return await (from entity in context.Set<TrainEntity>() select TrainMapper.ToTrainIdentifier(entity)).ToArrayAsync();
        }
    }
}
