using DDD.Domain.Train;

namespace DDD.Domain.Passenger
{
    public partial class PassengerEntity
    {
        public static PassengerEntity NouveauClient(string nom, string prenom)
        {
            return new PassengerEntity()
            {
                _Name = nom
            };
        }

        private PassengerEntity()
        {
        }

        private int _Id;
        public int Id => _Id;
        

        private string _Name;
        public string Name => _Name;


        private int _TrainId;
        public int TrainId => _TrainId;

        private TrainEntity _Train;
        public TrainEntity Train => _Train;
    }
}
