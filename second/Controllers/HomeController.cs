using Microsoft.AspNetCore.Mvc;
using second.DAL.Interfaces;
using second.Domain.Entity;
using second.Models;
using System.Diagnostics;


namespace second.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRobotRepository _robotRepository;
        public HomeController(IRobotRepository rr)
        {
            _robotRepository = rr;
        }


        public  IActionResult Index()
        {
            var resp = _robotRepository.Select();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}