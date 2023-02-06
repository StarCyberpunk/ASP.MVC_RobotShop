using Azure;
using Microsoft.AspNetCore.Mvc;
using second.Domain.Entity;
using second.Service.Interfaces;

namespace second.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService; 
        public BasketController(IBasketService basketservice)
        {
            _basketService = basketservice;
        }
        public async Task<IActionResult> Detail()
        {
            var response = await _basketService.GetItems(User.Identity.Name);
           
            return View(response.Data);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int id)
        {
            var response = await _basketService.AddToBasket(id, User.Identity.Name);
            return RedirectToAction("Detail");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            var response = await _basketService.DeleteFromBasket(id, User.Identity.Name);
            return RedirectToAction("Detail");
        }
    }
}
