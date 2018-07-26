using DDD.Domain.TicketOffice;
using DDD.Domain.Train;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DDD.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        private readonly TicketOfficeService _ticketOfficeService;
        private readonly TrainService _trainService;

        public StoryController(TicketOfficeService ticketOfficeService, TrainService trainService)
        {
            _ticketOfficeService = ticketOfficeService;
            _trainService = trainService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var client1 = await _ticketOfficeService.EnregistrerClient("Sebastien", "");
            var client2 = await _ticketOfficeService.EnregistrerClient("Maxime", "");

            var train1 = await _trainService.AffreterUnTrain("489800");
            await _trainService.EmbarquerDansLeTrain(train1.Id, client1.Id);

            return Ok(await _trainService.ListerLesTrains());
        }
    }
}
