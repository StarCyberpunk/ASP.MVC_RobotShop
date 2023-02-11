using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using second.DAL.Interfaces;
using second.Domain.Entity;
using second.Domain.Response;
using second.Domain.ViewModels;
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
                if (res.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View(res.Data);
                }
                return RedirectToAction("Error");
            
            
            
        }
        [HttpPost]
        public async Task<IActionResult> GetRobots(string input2)
        {

            var res = await _RobotService.Search(input2);
            if (res.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(res.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetRobot(int id)
        {
            var res = await _RobotService.GetRobotById(id);
            if (res.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(res.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRobot(int id)
        {
            var res = await _RobotService.DeleteRobot(id);
            if (res.Data)
            {
                return RedirectToAction("GetRobots");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRobot(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _RobotService.GetRobotById(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                RobotViewModel rrr = _RobotService.RobotToRWM(response.Data);
                return View(rrr);
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRobot(RobotViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                
                if (rvm.Id == 0)
                {
                     await _RobotService.CreateRobot(rvm);
                }
                else
                {
                     await _RobotService.EditRobot(rvm.Id, rvm);
                }

                return Redirect(String.Format( "/Robot/GetRobot/{0}",rvm.Id));
            }
            return RedirectToAction("Error");
        }

    }
}


