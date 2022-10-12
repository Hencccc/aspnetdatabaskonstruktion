using databaskonstruktion.Models;
using Microsoft.AspNetCore.Mvc;

namespace databaskonstruktion.Controllers
{
    public class SearchController : Controller
    {
        private readonly IConfiguration _configuration;
        private FoodModel _foodModel;

        public SearchController(IConfiguration configuration)
        {
            _configuration = configuration;
            _foodModel = new FoodModel(_configuration);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchFood(int magic)
        {
            ViewBag.SearchFood = _foodModel.SearchFood(magic);
            return View();
        }
    }
}
