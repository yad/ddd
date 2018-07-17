namespace DDD.Domain.Train
{
    public class TrainMapper
    {
        public static TrainIdentifier ToTrainIdentifier(TrainEntity trainEntity)
        {
            return new TrainIdentifier(trainEntity.Id);
        }
    }
}
