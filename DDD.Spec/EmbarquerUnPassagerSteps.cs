using CSharpFunctionalExtensions;
using DDD.Domain.Passenger;
using DDD.Domain.Train;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace DDD.Spec
{
    [Binding]
    public class EmbarquerUnPassagerSteps
    {
        private EmbarquerUnPassagerContext _context = new EmbarquerUnPassagerContext();

        [Given(@"Un train est limite a (.*) places")]
        public void GivenUnTrainEstLimiteAPlaces(int maxPlaces)
        {
            _context.MaxPlaces = maxPlaces;
        }

        [Given(@"Le train (.*) est en gare")]
        public void GivenLeTrainEstEnGare(int trainId)
        {
            _context.Train = new TrainEntity(trainId, _context.MaxPlaces);
        }

        [Given(@"Le train contient (.*) passagers")]
        public void GivenLeTrainContientPassagers(int currentPassengerNumber)
        {
            for (int i = 0; i < currentPassengerNumber; i++)
            {
                _context.Train.EmbarquerPassager(new PassengerEntity());
            }
        }

        [Given(@"Le passager (.*) est a quai")]
        public void GivenLePassagerEstAQuai(int idPassenger)
        {
            _context.Passenger = new PassengerEntity(idPassenger);
        }

        [When(@"Le passager monte dans le train")]
        public void WhenLePassagerMonteDansLeTrain()
        {
            _context.TrainResult = _context.Train.EmbarquerPassager(_context.Passenger);
        }

        [Then(@"Le nombre de passager est de (.*)")]
        public void ThenLeNombreDePassagerEstDe(int expectedPassengerNumber)
        {
            Assert.AreEqual(expectedPassengerNumber, _context.Train.Passengers.Count);
        }
        
        [Then(@"Le passager est dans le train")]
        public void ThenLePassagerEstDansLeTrain()
        {
            Assert.IsTrue(_context.TrainResult.IsSuccess);
            Assert.IsTrue(_context.Train.Passengers.Any(p => p.Id == _context.Passenger.Id));
        }
        
        [Then(@"Le passager ne peut pas monter")]
        public void ThenLePassagerNePeutPasMonter()
        {
            Assert.IsTrue(_context.TrainResult.IsFailure);
            Assert.AreEqual("La limite d'embarquement est atteinte", _context.TrainResult.Error);
            Assert.IsFalse(_context.Train.Passengers.Any(p => p.Id == _context.Passenger.Id));
        }
    }

    internal class EmbarquerUnPassagerContext
    {
        public EmbarquerUnPassagerContext()
        {
        }

        public int MaxPlaces { get; internal set; }
        public TrainEntity Train { get; internal set; }
        public Result<TrainEntity> TrainResult { get; internal set; }
        public PassengerEntity Passenger { get; internal set; }
    }
}
