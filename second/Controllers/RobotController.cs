using Microsoft.AspNetCore.Mvc;
using second.DAL.Interfaces;
using second.Domain.Entity;

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
        public async Task<IActionResult> GetRobots()
        {
            var resp = await _robotRepository.Select();
            var resp2 = await _robotRepository.GetByName("Test");
            var resp3 = await _robotRepository.Get(2);

            var robot = new Robot()
            {
                Name = "Manipul",
                Model = "A123",
                Speed = 0,
                Price = 230000,
                Description = "Top",
                DateCreate = DateTime.Now,
                TypeRobot = Domain.Enum.TypeRobot.PromshRobot
            };
            await _robotRepository.Create(robot);
            await _robotRepository.Delete(robot);
            return View(resp);
        }
    }
}
