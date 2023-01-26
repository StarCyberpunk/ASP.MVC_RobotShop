using Microsoft.AspNetCore.Mvc;
using second.Domain.ViewModels;
using second.Service.Implementations;
using second.Service.Interfaces;
using System.Runtime.Intrinsics.Arm;

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
            else
            {
                return View();
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> SaveProfile(int Userid) {
            if (Userid == 0 )
            {
                return View();
            }
            var response = await _ps.GetProfileByUserId(Userid);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                ProfileViewModel rrr = _ps.ProfileToPWM(response.Data);
                return View(rrr);
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> SaveProfile(ProfileViewModel pvm)
        {
            //Профилю присваивается юзер
            if (ModelState.IsValid)
            {
                var ress = await _ac.GetUser(pvm.UserName);
                pvm.UserId = ress.Data.Id;
                if (pvm.Id == 0){
                    
                    await _ps.CreateProfile(pvm);
                }
                else
                {
                    await _ps.EditProfile( pvm);
                }
            }
            return RedirectToAction("GetProfile",new { @UserName = pvm.UserName } );
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
