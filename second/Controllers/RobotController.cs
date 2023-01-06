using Microsoft.AspNetCore.Mvc;
using second.DAL.Interfaces;

namespace second.Controllers
{
    public class RobotController : Controller
    {
        private readonly IRobotRepository _robotRepository;
        public RobotController(IRobotRepository rr)
        {
            _robotRepository = rr;
        }
        [HttpGet]
        public IActionResult GetRobots()
        {
            var resp = _robotRepository.Select();
            return View(resp);
        }
    }
}
