using System.Threading.Tasks;
using DDD.Domain.Train;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Api.Controllers
{
    [Route("api/[controller]")]
    public class TrainController : Controller
    {
        private readonly TrainService _trainService;

        public TrainController(TrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet("{trainId}/passenger/{passengerId}")]
        public async Task<IActionResult> Get(int trainId, int passengerId)
        {
            return Ok(await _trainService.EmbarquerDansLeTrain(trainId, passengerId));
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trainService.ListerLesTrains());
        }
    }
}
