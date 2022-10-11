using databaskonstruktion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace databaskonstruktion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ReindeerModel reindeerModel = new ReindeerModel(_configuration);
            ViewBag.ReindeerTable = reindeerModel.GetAllReindeers();
            FoodModel foodModel = new FoodModel(_configuration);
            ViewBag.FoodTable = foodModel.GetAllFood();
            return View();
        }
    }
}