using Microsoft.AspNetCore.Mvc;

namespace second.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
