using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EntityPresentor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoordinatesController : Controller
    {
        private readonly IHubContext<MyHub> _hubContext;

        public CoordinatesController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult trythis([FromBody] CoordinatesEntity choosenCoordinates)
        {
            CoordinatesEntity newCoordinates = new CoordinatesEntity
            {
                Name = choosenCoordinates.Name,
                Latitude = choosenCoordinates.Latitude,
                Longitude = choosenCoordinates.Longitude
            };

            _hubContext.Clients.All.SendAsync("broadcastMessage", newCoordinates);

            return Ok(new { message = "Success", data = "Your response data" });
        }
    }
}