using Microsoft.AspNetCore.Mvc;
using second.Domain.ViewModels;
using second.Service.Implementations;
using second.Service.Interfaces;

namespace second.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _ps;
        private readonly IAccountService _ac;
        public ProfileController(IProfileService _p, IAccountService _a)
        {
            _ps = _p;
            _ac = _a;
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile(string UserName)
        {
            var ress = await _ac.GetUser(UserName);
            var res = await _ps.GetProfileByUserId((int)ress.Data.Id);
            if (res.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(res.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> SaveProfile(int id) {
            return View();
                }
        [HttpPost]
        public async Task<IActionResult> SaveProfile(ProfileViewModel pvm)
        {
            return View();
         }

        public IActionResult Index()
        {
            return View();
        }
    }
}
