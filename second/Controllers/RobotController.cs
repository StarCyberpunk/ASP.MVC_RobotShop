using Microsoft.AspNetCore.Mvc;
using second.DAL.Interfaces;
using second.Domain.Entity;
using second.Service.Interfaces;

namespace second.Controllers
{
    public class RobotController : Controller
    {
        private readonly IRobotService _RobotService;
        public RobotController(IRobotService robotSevice)
        {
            _RobotService = robotSevice;
        }

        [HttpGet]
        public async Task<IActionResult> GetRobots()
        {
            var res = await _RobotService.GetAllRobots();
            return View(res.Data);
        }
    }
}
