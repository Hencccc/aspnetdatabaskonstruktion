using databaskonstruktion.Models;
using Microsoft.AspNetCore.Mvc;

namespace databaskonstruktion.Controllers
{
    public class ManipulateController : Controller
    {
        private readonly IConfiguration _configuration;
        private SpannModel _spannModel;

        public ManipulateController(IConfiguration configuration)
        {
            _configuration = configuration;
            _spannModel = new SpannModel(_configuration);
        }

        public IActionResult Index()
        {
            ViewBag.SpannTable = _spannModel.GetAllSpann();
            return View();
        }

        public IActionResult InsertSpann(string name, int capacity)
        {
            _spannModel.InsertSpann(name, capacity);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSpann(string spann)
        {
            _spannModel.DeleteSpann(spann);
            return RedirectToAction("Index");
        }
    }
}
