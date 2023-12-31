using Microsoft.AspNetCore.Mvc;
using LAB9.Models;

namespace LAB9.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;

        public HomeController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _weatherService.GetWeatherAsync("Mykolaiv");

            var products = new List<ProductModel>
        {
            new ProductModel { ID = 1, Name = "Зонт", Price = 299.99 },
            new ProductModel { ID = 2, Name = "Дощовик", Price = 69.99 },
            new ProductModel { ID = 3, Name = "Окуляри", Price = 99.99 }
        };

            var homeViewModel = new HomeViewModel
            {
                Weather = weather,
                Products = products
            };

            return View("~/Views/Shared/Components/Weather/Default.cshtml", homeViewModel);
        }
    }
}

